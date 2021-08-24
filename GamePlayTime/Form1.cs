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
    public partial class Form1 : Form
    {
        
        public string TrackedFileJsonPath { get; set; }
        public string HiddenFileJsonPath { get; set; }
        public static DateTime InitTime { get; set; }

        public static List<Executable> AllExecutable = new List<Executable>();
        public static List<Executable> TrackedExecutable = new List<Executable>();
        public static List<Executable> HiddenExecutable = new List<Executable>();


        private Form2 form2;

        [Serializable()]
        public class Executable : ISerializable
        {
            public Process Process { get; }
            public string WindowTitle { get; }
            public string ExecutableName { get; }
            public string Path { get; }

            public TimeSpan HoursDaily { get; set; }
            public TimeSpan HoursWeekly { get; set; }
            public TimeSpan HoursMonthly { get; set; }
            public TimeSpan SessionHours { get; set; }
            public DateTime SessionStart { get; set; }
            public DateTime SessionEnd { get; set; }


            public Executable(Process _process, string _windowTitle, string _executableName, string _path)
            {
                Process = _process;
                WindowTitle = _windowTitle;
                ExecutableName = _executableName;
                Path = _path;
            }

            public Executable(SerializationInfo info, StreamingContext context)
            {
                Process = null;
                WindowTitle = (string)info.GetValue("WindowTitle", typeof(string));
                ExecutableName = (string)info.GetValue("ExecutableName", typeof(string));
                Path = (string)info.GetValue("Path", typeof(string));
            }

            //Our serialization function. Stores object data in a file.
            //Serialization info holds key-value pairs for the data.
            //StreamingContext is used to hold additional information.
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("WindowTitle", WindowTitle);
                info.AddValue("ExecutableName", ExecutableName);
                info.AddValue("Path", Path);
            }


        }

        public Form1()
        {
            InitializeComponent();

            TrackedFileJsonPath = "trackedexe.json";
            HiddenFileJsonPath = "hiddenexe.json";

            ReadFromJson(TrackedFileJsonPath, out TrackedExecutable);
            ReadFromJson(HiddenFileJsonPath, out HiddenExecutable);


            RefreshAllWindows();



        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogToJson(TrackedFileJsonPath, TrackedExecutable);
            LogToJson(HiddenFileJsonPath, HiddenExecutable);

        }
            
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshAllWindows();
        }

        //Enum all the VISIBLE windows.
        //Make a list of Process objects with all of their PIDs.
        //Have that in one list. 
        //And you can double-click the name of the process in the list to have it added to the list of tracked programs.

        //Todo: make a list of hidden windows.
        //Find a way to minimize the app.
        //Begin a way to track time based on the app, using its path as the identity.
        //Find a way to serialize the data.


        private bool IsNotHiddenOrTracked(Executable ex)
        {
            return (!HiddenExecutable.Any(h => h.Path == ex.Path) && (!TrackedExecutable.Any(t => t.Path == ex.Path)));
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
                AllExecutable = AllExecutable.Where(IsNotHiddenOrTracked).ToList();
            }


            AddListToListbox(AllProcessesBox, AllExecutable);
            AddListToListbox(TrackedProcessesBox, TrackedExecutable);

        }
        
        public static void AddListToListbox(ListBox lB, List<Executable> lEx)
        {
            var strings = new List<string>();
            foreach (var exe in lEx)
            {
                strings.Add(exe.WindowTitle + " (" + exe.ExecutableName + ")");
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

                    bool Test1(Executable e)
                    {
                        return e.WindowTitle == "";
                    }
                    IEnumerable<Executable> stuff = AllExecutable.Where(Test1);
                    bool xO = stuff.Any();

                    if (!string.IsNullOrWhiteSpace(process.MainWindowTitle) && (!AllExecutable.Where(e => process.MainWindowTitle == e.WindowTitle).Any()))
                        AllExecutable.Add(new Executable(process, process.MainWindowTitle, process.MainModule.ModuleName, process.MainModule.FileName));
                }
                catch
                {
                    //SystemSounds.Hand.Play();
                    //MessageBox.Show("Something went wrong!");
                }
            }
            return true;
        }


        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            RightClickGenericListBox(sender, e, AllExecutableContextMenuStrip);
        }


        public static void RightClickGenericListBox(object sender, MouseEventArgs e, ContextMenuStrip c)
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
                    MessageBox.Show("This is still an issue LOL");
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

            if (form2.Visible)
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
                //if (list == null)
                //{
                //    list = new List<Executable>();
                //}
                    
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

            TrackedProcessesBox.Items.Remove(focusedItem);
            TrackedExecutable.Remove(matchingItem);
            Console.WriteLine("Just removed index " + focusedIndex + ", matching program " + matchingItem.ExecutableName);
        }

        private void showHiddenProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
        }
    }
}





   
