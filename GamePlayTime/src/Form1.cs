using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using PInvoke;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace GamePlayTime
{
    using KeyValueList = List<KeyValuePair<DateTime, TimeSpan>>;

    public partial class Form1 : Form
    {
        private static string TrackedFileJsonPath { get; set; }
        private static string HiddenFileJsonPath { get; set; }

        public static List<Executable> AllExecutable = new List<Executable>();
        public static List<Executable> TrackedExecutable = new List<Executable>();
        public static List<Executable> HiddenExecutable = new List<Executable>();

        bool usrPrf_showOfflineTrackedExecutables { get; set; } = true;
        bool usrPrf_runOnStartUp { get; set; } = false;

        private Form2 form2;
        private Form3 form3;

        [Serializable()]
        public class Executable : ISerializable
        {
            public Process Process { get; set; }
            public string WindowTitle { get; }
            public string ExecutableName { get; }
            public string Path { get; }
            public KeyValueList DateAndDuration { get; }
            public Stopwatch session { get; set; } = new Stopwatch();
            public Executable(Process _process, string _windowTitle, string _executableName, string _path, KeyValueList _dateAndDuration = null)
            {
                Process = _process;
                WindowTitle = _windowTitle;
                ExecutableName = _executableName;
                Path = _path;
                DateAndDuration = (_dateAndDuration != null) ? _dateAndDuration : new KeyValueList();
            }

            public Executable(SerializationInfo info, StreamingContext context)
            {
                Process = null;
                WindowTitle = (string)info.GetValue("WindowTitle", typeof(string));
                ExecutableName = (string)info.GetValue("ExecutableName", typeof(string));
                Path = (string)info.GetValue("Path", typeof(string));
                var dnd = (KeyValueList)info.GetValue("DateAndDuration", typeof(KeyValueList));
                DateAndDuration = (dnd != null) ? dnd : new KeyValueList();
            }

            //Our serialization function. Stores object data in a file.
            //Serialization info holds key-value pairs for the data.
            //StreamingContext is used to hold additional information.
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("WindowTitle", WindowTitle);
                info.AddValue("ExecutableName", ExecutableName);
                info.AddValue("Path", Path);
                info.AddValue("DateAndDuration", DateAndDuration);
            }

        }

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = notifyIconContextMenuStrip;
            TrackedFileJsonPath = "trackedexe.json";
            HiddenFileJsonPath = "hiddenexe.json";

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            runOnStartupToolStripMenuItem.Checked = (rk.GetValue("GamePlayTime") != null);

            ReadFromJson(TrackedFileJsonPath, out TrackedExecutable);
            ReadFromJson(HiddenFileJsonPath, out HiddenExecutable);
            RefreshAllWindows();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshAllWindows();
        }

        //
        //
        //UTILITY FUNCTIONS
        //
        //

        private static void EnumDesktopWindows()
        {
            foreach (var proc in Process.GetProcesses())
            {
                if (proc.MainWindowHandle != null && User32.IsWindowVisible(proc.MainWindowHandle) && !string.IsNullOrEmpty(proc.MainWindowTitle) && !AllExecutable.Where(e => proc.MainWindowTitle == e.WindowTitle).Any())
                {
                    try
                    {
                        AllExecutable.Add(new Executable(proc, proc.MainWindowTitle, proc.MainModule.ModuleName, proc.MainModule.FileName));
                    }
                    catch
                    {
                        AllExecutable.Add(new Executable(proc, proc.MainWindowTitle, "path not available", "filename not available"));
                    }
                }

            }
        }

        //This function finds all the matching paths between the all-executable and tracked-executable list, and transfers processes if they need transferring.
        private void ReSortTracked()
        {
            for(int i = 0; i < AllExecutable.Count; i++)
            {
                for (int j = 0; j < TrackedExecutable.Count; j++)
                {   
                    try
                    {
                        //First try to match exe paths, then if that fails, try to match window titles
                        if (TrackedExecutable[j].Path != "path not available")
                        {
                            if (AllExecutable[i].Path == TrackedExecutable[j].Path)
                            {
                                TrackedExecutable[j].Process = AllExecutable[i].Process;
                                AllExecutable.RemoveAt(i);
                            }
                        }
                        else if (AllExecutable[i].WindowTitle == TrackedExecutable[j].WindowTitle)
                        {
                            TrackedExecutable[j].Process = AllExecutable[i].Process;
                            AllExecutable.RemoveAt(i);
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }

        private void CloseContextMenus()
        {
            AllExecutableContextMenuStrip.Close();
            TrackedExecutableContextMenuStrip.Close();
            if (form2 != null)
                form2.CloseForm2ContextMenus();
        }

        public void RefreshAllWindows()
        {
            CloseContextMenus();
            AllExecutable.Clear();
            EnumDesktopWindows();

            if (HiddenExecutable != null)
            {
                AllExecutable = AllExecutable.Where(ex => !HiddenExecutable.Any(t => t.Path == ex.Path)).ToList();
            }

            ReSortTracked();
            AllProcessesBox.Items.Clear();
            TrackedProcessesBox.Items.Clear();
            AddListToListbox(AllProcessesBox, AllExecutable);
            AddListToListbox(TrackedProcessesBox, TrackedExecutable);
            ProcessTimeCheck();
            if (form3 != null)
                form3.UpdateCalendarDate();

                
        }

        private static void ProcessTimeCheck()
        {
            foreach (var tE in TrackedExecutable)
            {
                if (tE.Process != null)
                {
                    //If the stopwatch hasn't started...
                    //Has the process exited? If it has, then don't start the stopwatch.
                    //If it hasn't, start the stopwatch.
                    if (!tE.session.IsRunning)
                    {
                        if (tE.Process.HasExited) continue;
                        else tE.session.Start();
                        return;
                    }
                    //If the stopwatch has started...
                    //Has the process exited? if it has, then stop the stopwatch.
                    //Update the keyvalue stuff.
                    else if (tE.session.IsRunning)
                    {
                        if (tE.Process.HasExited) tE.session.Reset();
                        
                        TimeSpan t = tE.session.Elapsed;
                        //Look for an existing key/value pair based on the current date and time. If there isn't one...
                        KeyValuePair<DateTime, TimeSpan> kvTime = tE.DateAndDuration.Find(kv => kv.Key.Date == DateTime.Today);
                        if (tE.DateAndDuration.Where(kv => kv.Key.Date == DateTime.Today).Any())
                        {
                            var t2 = kvTime.Value.Add(t);
                            tE.DateAndDuration.Add(new KeyValuePair<DateTime, TimeSpan>(DateTime.Today, t2));
                            tE.DateAndDuration.Remove(kvTime);
                        }
                        else
                        {
                            //Add the current time to whatever's in the value of kvTime.
                            tE.DateAndDuration.Add(new KeyValuePair<DateTime, TimeSpan>(DateTime.Today, t));
                        }
                        tE.session.Restart();
                        
                    }

                }
            }
        }

        public void AddListToListbox(ListBox lB, List<Executable> lEx)
        {
            var strings = new List<string>();
            foreach (var exe in lEx)
            {
                if (exe.Process != null)
                {
                    if (exe.Process.HasExited && usrPrf_showOfflineTrackedExecutables)
                        strings.Add(exe.WindowTitle + " (" + exe.ExecutableName + ") {Offline}");
                    else if (!exe.Process.HasExited)
                        strings.Add(exe.WindowTitle + " (" + exe.ExecutableName + ")");
                }
                else if (usrPrf_showOfflineTrackedExecutables)
                    strings.Add(exe.WindowTitle + " (" + exe.ExecutableName + ") {Offline}");

            }
            lB.Items.AddRange(strings.ToArray());
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            RightClickGenericListBox(sender, e, AllExecutableContextMenuStrip);
        }

        public void RightClickGenericListBox(object sender, MouseEventArgs e, ContextMenuStrip c)
        {
            if (e.Button == MouseButtons.Right)
            {
                var listBox = (ListBox)sender;
                var cursorPointIndex = listBox.IndexFromPoint(e.Location);

                listBox.Focus();

                try
                {
                    listBox.SetSelected(cursorPointIndex, true);
                }
                catch
                {
                    if (cursorPointIndex == -1 && listBox == TrackedProcessesBox) TrackedExecutableContextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
                }

                var focusedItem = listBox.SelectedItem;

                if (focusedItem != null && listBox.SelectedIndex == cursorPointIndex && !(cursorPointIndex == -1) && listBox.SelectedIndex != -1) c.Show(Cursor.Position);

            }
        }

        private void TrackedProcessesBox_MouseDown(object sender, MouseEventArgs e)
        {
            RightClickGenericListBox(sender, e, TrackedExecutableContextMenuStrip);
        }

        private void AllProcessesBox_Leave(object sender, EventArgs e)
        {
            ListBox lB = (ListBox)sender;
            lB.ClearSelected();
        }

        private void TrackedProcessesBox_Leave(object sender, EventArgs e)
        {
            ListBox lB = (ListBox)sender;
            lB.ClearSelected();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                if (form2 != null)
                    form2.Hide();
                return;
            }

            timer1.Stop();
            ProcessTimeCheck();
            LogToJson(TrackedFileJsonPath, TrackedExecutable);
            LogToJson(HiddenFileJsonPath, HiddenExecutable);
            notifyIcon1.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Show();
            else if (e.Button == MouseButtons.Right)
                notifyIcon1.ContextMenuStrip.Show();
        }

        private static void LogToJson(string filePath, List<Executable> list)
        {
            JsonSerializer js = new JsonSerializer();
            if (!File.Exists(filePath))
            {
                var fs = File.Create(filePath);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);
            jsonWriter.Formatting = Formatting.Indented;

            js.Serialize(jsonWriter, list);
            sw.Close();
            jsonWriter.Close();
        
        }

        private static void ReadFromJson(string filePath, out List<Executable> list)
        {
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                JsonReader jr = new JsonTextReader(sr);
                JsonSerializer js = new JsonSerializer();
                list = (List<Executable>)js.Deserialize(jr, typeof(List<Executable>));
                if (list == null) list = new List<Executable>();

            }
            else
            {
                File.Create(filePath);
                list = new List<Executable>();
            }

        }

        private void TrackProcess()
        {
            var focusedItem = AllProcessesBox.SelectedItem;
            var focusedIndex = AllProcessesBox.SelectedIndex;

            if (focusedIndex != -1)
            {
                var matchingItem = AllExecutable.ElementAt(focusedIndex);
                AllProcessesBox.Items.Remove(focusedItem);
                TrackedExecutable.Add(matchingItem);
                AllExecutable.Remove(matchingItem);
                TrackedProcessesBox.Items.Add(focusedItem);
                Console.WriteLine("Just removed index " + focusedIndex + ", matching program " + matchingItem.ExecutableName);
            }
        }

        private void StopTrackingProcess()
        {
            var focusedItem = TrackedProcessesBox.SelectedItem;
            var focusedIndex = TrackedProcessesBox.SelectedIndex;
            var matchingItem = TrackedExecutable.ElementAt(focusedIndex);

            
            if (matchingItem.DateAndDuration.Count > 2)
            {
                DialogResult dr = MessageBox.Show(this, "The program you are un-tracking has 3 or more days on which it is tracked.\n" +
                    "Untracking it will erase this history when you next close the program! Do you want to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                    return;
            }
            //These are on separate lines because I can't get short-circuit evaluation to work.
            if (matchingItem.Process != null)
            {
                if (!matchingItem.Process.HasExited)
                {
                    AllExecutable.Add(matchingItem);
                    AllProcessesBox.Items.Add(focusedItem);
                }
            }
            TrackedProcessesBox.Items.Remove(focusedItem);
            TrackedExecutable.Remove(matchingItem);
        }

        private void HideProcess()
        {
            var focusedItem = AllProcessesBox.SelectedItem;
            var focusedIndex = AllProcessesBox.SelectedIndex;

            if (focusedIndex != -1)
            {
                var matchingItem = AllExecutable.ElementAt(focusedIndex);

                AllProcessesBox.Items.Remove(focusedItem);
                HiddenExecutable.Add(matchingItem);

                if (form2 != null)
                    form2.AddHiddenToList(focusedItem);

                AllExecutable.Remove(matchingItem);
                Console.WriteLine("Just removed index " + focusedIndex + ", matching program " + matchingItem.ExecutableName);
                RefreshAllWindows();
            }
        }

        //
        //
        //TOOLSTRIP FUNCTIONS
        //
        //
        private void stopTrackingProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopTrackingProcess();
        }

        private void showHiddenProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void processesToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void processesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showOfflineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenTrackedProcessesFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenTrackedProcessFileDialog.ShowDialog();
            string path = OpenTrackedProcessFileDialog.FileName;
            if (dr == DialogResult.OK)
            {
                TrackedFileJsonPath = path;
                RefreshAllWindows();
            }
        }

        private void OpenHiddenProcessesFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenHiddenProcessFileDialog.ShowDialog();
            string path = OpenHiddenProcessFileDialog.FileName;
            if (dr == DialogResult.OK)
            {
                HiddenFileJsonPath = path;
                RefreshAllWindows();
            }    
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trackProcessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TrackProcess();
        }

        private void hideProcessToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            HideProcess();
        }

        private void trackProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrackProcess();
        }

        private void hideProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideProcess();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game Play Time v1.0\nCreated by @mojius on github :)", "About");
        }

        private void runOnStartupToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            usrPrf_runOnStartUp = runOnStartupToolStripMenuItem.Checked;

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (usrPrf_runOnStartUp ^ rk.GetValue("GamePlayTime") != null)
                rk.SetValue("GamePlayTime", Application.ExecutablePath);
            else
                rk.DeleteValue("GamePlayTime", false);
        }

        private void showOfflineToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            usrPrf_showOfflineTrackedExecutables = showOfflineToolStripMenuItem.Checked;
            RefreshAllWindows();
        }

        private void viewActivityCalendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //AllProcessesBox.Size = new System.Drawing.Size(Size.Width - 30, Size.Height - 30);
            //TrackedProcessesBox.Size = new System.Drawing.Size(Size.Width - 30, Size.Height - 30);
        }
    }
}

//Figure out some async shit.
//Have someone test the program. 
//Optimize.
//https://stackoverflow.com/questions/972039/is-there-a-system-event-when-processes-are-created

//Make opening and closing all forms stop/start the timer, and get rid of the controls that close the context menu windows.
//https://foxlearn.com/windows-forms/minimize-application-to-system-tray-in-csharp-523.html
//https://stackoverflow.com/questions/995195/how-can-i-make-a-net-windows-forms-application-that-only-runs-in-the-system-tra