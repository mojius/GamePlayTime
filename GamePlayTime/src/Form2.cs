using System;
using System.Linq;
using System.Windows.Forms;

namespace GamePlayTime
{
    public partial class Form2 : Form
    {
        private Form1 form1;

        public Form2()
        {
            InitializeComponent();

        }




        private void unhideProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var focusedItem = HiddenProcessesBox.SelectedItem;
            var focusedIndex = HiddenProcessesBox.SelectedIndex;
            var matchingItem = Form1.HiddenExecutable.ElementAt(focusedIndex);

            HiddenProcessesBox.Items.Remove(focusedItem);
            Form1.HiddenExecutable.Remove(matchingItem);
            Console.WriteLine("Just removed index " + focusedIndex + ", matching program " + matchingItem.ExecutableName);
            form1.RefreshAllWindows();
        }

        private void HiddenProcessesBox_MouseDown(object sender, MouseEventArgs e)
        {
            form1.RightClickGenericListBox(sender, e, HiddenExecutableContextMenuStrip);
        }

        public void CloseForm2ContextMenus()
        {
            HiddenExecutableContextMenuStrip.Close();
        }

        public void AddHiddenToList(object o)
        {
            HiddenProcessesBox.Items.Add(o);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            form1 = Application.OpenForms.OfType<Form1>().First();
            HiddenProcessesBox.Items.Clear();
            form1.AddListToListbox(HiddenProcessesBox, Form1.HiddenExecutable);
        }
    }
}
