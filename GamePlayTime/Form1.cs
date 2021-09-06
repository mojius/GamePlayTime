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

namespace GamePlayTime
{
    using KeyValueList = List<KeyValuePair<DateTime, TimeSpan>>;

    public partial class Form1 : Form
    {

        
        string TrackedFileJsonPath { get; set; }
        string HiddenFileJsonPath { get; set; }
        static DateTime InitTime { get; set; }

        public static List<Executable> AllExecutable = new List<Executable>();
        public static List<Executable> TrackedExecutable = new List<Executable>();
        public static List<Executable> HiddenExecutable = new List<Executable>();

        bool usrPrf_showOfflineTrackedExecutables { get; set; } = true;

        private Form2 form2;

        [Serializable()]
        public class Executable : ISerializable
        {
            public Process Process { get; set; }
            public string WindowTitle { get; }
            public string ExecutableName { get; }
            public string Path { get; }
            public KeyValueList DateandDuration { get; }

            public Stopwatch session { get; set; } = new Stopwatch();


            public Executable(Process _process, string _windowTitle, string _executableName, string _path, KeyValueList _dateAndDuration = null)
            {
                Process = _process;
                WindowTitle = _windowTitle;
                ExecutableName = _executableName;
                Path = _path;
                if (_dateAndDuration != null)
                {
                    DateandDuration = _dateAndDuration;
                }
                else
                {
                    DateandDuration = new KeyValueList();
                }

            }

            public Executable(SerializationInfo info, StreamingContext context)
            {
                Process = null;
                WindowTitle = (string)info.GetValue("WindowTitle", typeof(string));
                ExecutableName = (string)info.GetValue("ExecutableName", typeof(string));
                Path = (string)info.GetValue("Path", typeof(string));
                var dnd = (KeyValueList)info.GetValue("DateAndDuration", typeof(KeyValueList));
                DateandDuration = (dnd == null) ? dnd : new KeyValueList();

            }

            //Our serialization function. Stores object data in a file.
            //Serialization info holds key-value pairs for the data.
            //StreamingContext is used to hold additional information.
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("WindowTitle", WindowTitle);
                info.AddValue("ExecutableName", ExecutableName);
                info.AddValue("Path", Path);
                info.AddValue("DateAndDuration", DateandDuration);
            }


        }

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = notifyIconContextMenuStrip;

            TrackedFileJsonPath = "trackedexe.json";
            HiddenFileJsonPath = "hiddenexe.json";

            ReadFromJson(TrackedFileJsonPath, out TrackedExecutable);
            ReadFromJson(HiddenFileJsonPath, out HiddenExecutable);


            RefreshAllWindows();



        }



            
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshAllWindows();
        }

        //Find a way to minimize the app.


        private bool IsNotHidden(Executable ex)
        {
            return (!HiddenExecutable.Any(t => t.Path == ex.Path));
        }
        
        //This function finds all the matching paths between the all-executable and tracked-executable list, and transfers processes if they need transferring.
        private void ReSortTracked()
        {
            for(int i = 0; i < AllExecutable.Count; i++)
            {
                for (int j = 0; j < TrackedExecutable.Count; j++)
                {
                    if (AllExecutable[i].Path == TrackedExecutable[j].Path)
                    {
                        TrackedExecutable[j].Process = AllExecutable[i].Process;
                        AllExecutable.RemoveAt(i);
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
            AllProcessesBox.Items.Clear();
            TrackedProcessesBox.Items.Clear();
            EnumDesktopWindows();

            
            if (HiddenExecutable != null)
            {
                AllExecutable = AllExecutable.Where(IsNotHidden).ToList();
            }

            ReSortTracked();

            AddListToListbox(AllProcessesBox, AllExecutable);
            AddListToListbox(TrackedProcessesBox, TrackedExecutable);

            ProcessTimeCheck();

        }



        public static void ProcessTimeCheck()
        {
            foreach (var tE in TrackedExecutable)
            {
                foreach (var aE in AllExecutable)
                {
                    if (tE.Process != null)
                    {
                        //If the process has not exited, and the stopwatch hasn't started, then start it.
                        if (!tE.Process.HasExited && !tE.session.IsRunning)
                        {
                            tE.session.Start();
                        }
                        else if (tE.Process.HasExited && tE.session.IsRunning)
                        {
                            tE.session.Stop();
                            TimeSpan t = tE.session.Elapsed;
                            //Look for an existing key/value pair based on the current date and time. If there isn't one...
                            KeyValuePair<DateTime, TimeSpan> kvTime = tE.DateandDuration.Find(kv => kv.Key.Date == DateTime.Today);
                            if (tE.DateandDuration.Where(kv => kv.Key.Date == DateTime.Today).Any())
                            {
                                var t2 = kvTime.Value.Add(t);
                                tE.DateandDuration.Add(new KeyValuePair<DateTime, TimeSpan>(DateTime.Today, t2));
                                tE.DateandDuration.Remove(kvTime);
                            }
                            else 
                            {
                                //Add the current time to whatever's in the value of kvTime.
                                tE.DateandDuration.Add(new KeyValuePair<DateTime, TimeSpan>(DateTime.Today, t));
                            }
                            tE.session.Reset();
                        }
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


        public static void EnumDesktopWindows()
        {
            User32.EnumDesktopWindows(User32.SafeDesktopHandle.Null, EnumCallback, IntPtr.Zero);
        }

        private static bool EnumCallback(IntPtr windowHandle, IntPtr lParam)
        {
            if (User32.IsWindowVisible(windowHandle))
            {
                User32.GetWindowThreadProcessId(windowHandle, out int pid);

                try
                {
                    var process = Process.GetProcessById(pid);

                    if (!string.IsNullOrWhiteSpace(process.MainWindowTitle) && !AllExecutable.Where(e => process.MainWindowTitle == e.WindowTitle).Any())
                    {
                        AllExecutable.Add(new Executable(process, process.MainWindowTitle, process.MainModule.ModuleName, process.MainModule.FileName));
                        
                    }
                        
                }
                catch (Win32Exception w)
                {
                    MessageBox.Show(w.Message);
                    Console.WriteLine(w.Message);
                    Console.WriteLine(w.ErrorCode.ToString());
                    Console.WriteLine(w.NativeErrorCode.ToString());
                    Console.WriteLine(w.StackTrace);
                    Console.WriteLine(w.Source);
                    Exception e = w.GetBaseException();
                    Console.WriteLine(e.Message);
                }
            }
            return true;
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
                    if (cursorPointIndex == -1 && listBox == TrackedProcessesBox)
                    {
                        TrackedExecutableContextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
                    }
                }

                var focusedItem = listBox.SelectedItem;

                if (focusedItem != null && listBox.SelectedIndex == cursorPointIndex && !(cursorPointIndex == -1) && listBox.SelectedIndex != -1)
                {

                    c.Show(Cursor.Position);
                }
            }
        }

        private void trackProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var focusedItem = AllProcessesBox.SelectedItem;
            var focusedIndex = AllProcessesBox.SelectedIndex;
            var matchingItem = AllExecutable.ElementAt(focusedIndex);

            AllProcessesBox.Items.Remove(focusedItem);
            TrackedExecutable.Add(matchingItem);
            AllExecutable.Remove(matchingItem);
            TrackedProcessesBox.Items.Add(focusedItem);
            Console.WriteLine("Just removed index " + focusedIndex + ", matching program " + matchingItem.ExecutableName);
        }

        private void hideProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var focusedItem = AllProcessesBox.SelectedItem;
            var focusedIndex = AllProcessesBox.SelectedIndex;
            var matchingItem = AllExecutable.ElementAt(focusedIndex);

            AllProcessesBox.Items.Remove(focusedItem);
            HiddenExecutable.Add(matchingItem);

            if (form2 != null)
                form2.AddHiddenToList(focusedItem);

            AllExecutable.Remove(matchingItem);
            Console.WriteLine("Just removed index " + focusedIndex + ", matching program " + matchingItem.ExecutableName);
            RefreshAllWindows();
        }


        private void LogToFile()
        {



        }

        private void LogToJson(string filePath, List<Executable> list)
        {

            JsonSerializer js = new JsonSerializer();

            //if (File.Exists(_filePath))
            {
                StreamWriter sw = new StreamWriter(filePath);
                JsonWriter jsonWriter = new JsonTextWriter(sw);
                jsonWriter.Formatting = Formatting.Indented;

                js.Serialize(jsonWriter, list);
                sw.Close();
                jsonWriter.Close();
            }
            //https://www.youtube.com/watch?v=Ib3jnD158NI

            //https://discord.com/channels/303217943234215948/311917081086001152/875477446248521728





        }

        private void ReadFromJson(string filePath, out List<Executable> list)
        {
            //check if file is empty
            if (File.Exists(filePath) && File.ReadAllBytes(filePath).Length  != 0)
            {
                list = JsonConvert.DeserializeObject<List<Executable>>(File.ReadAllText(filePath)).ToList();
                    
            }
            else
            {
                list = new List<Executable>();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
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

        private void stopTrackingProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var focusedItem = TrackedProcessesBox.SelectedItem;
            var focusedIndex = TrackedProcessesBox.SelectedIndex;
            var matchingItem = TrackedExecutable.ElementAt(focusedIndex);

            if (matchingItem.Process != null & !matchingItem.Process.HasExited)
            {
                AllExecutable.Add(matchingItem);
                AllProcessesBox.Items.Add(focusedItem);
            }
            TrackedProcessesBox.Items.Remove(focusedItem);
            TrackedExecutable.Remove(matchingItem);
            Console.WriteLine("Just removed index " + focusedIndex + ", matching program " + matchingItem.ExecutableName);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                if (form2 != null)
                    form2.Hide();

                Hide();
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
            timer1.Stop();
            ProcessTimeCheck();
            LogToJson(TrackedFileJsonPath, TrackedExecutable);
            LogToJson(HiddenFileJsonPath, HiddenExecutable);
            notifyIcon1.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "Application Minimized.";
            notifyIcon1.BalloonTipTitle = "Game Play Time";
            notifyIcon1.ShowBalloonTip(2000);
        }
        
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Show();
            else if (e.Button == MouseButtons.Right)
                notifyIcon1.ContextMenuStrip.Show();
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
            var contextMenu = (ToolStripMenuItem)TrackedExecutableContextMenuStrip2.Items[0];
            if (contextMenu.Checked)
            {
                contextMenu.Checked = false;
                usrPrf_showOfflineTrackedExecutables = false;
            }
            else if (!contextMenu.Checked)
            {
                contextMenu.Checked = true;
                usrPrf_showOfflineTrackedExecutables = true;
            }
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

        private void hideProcessToolStripMenuItem2_Click(object sender, EventArgs e)
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
    }
}


//--Fix up the menustrip controls -- make them do stuff. (Almost done: gotta do the second menu stuff).--
//Figure out how to handle a program if you remove it from the list of tracked processes.
//--Fix the icon not going away on close.--
//--Fix the program failing to actually close.--
//--Name the notify icon.--
//--Fix the annoying shit with the dateTimes not working.--
//--Add a control to show tracked but offline processes.--

//Make opening and closing all forms stop/start the timer, and get rid of the controls that close the context menu windows.
//https://foxlearn.com/windows-forms/minimize-application-to-system-tray-in-csharp-523.html
//https://stackoverflow.com/questions/995195/how-can-i-make-a-net-windows-forms-application-that-only-runs-in-the-system-tra





