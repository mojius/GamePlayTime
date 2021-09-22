using System;
using System.Linq;
using System.Windows.Forms;

namespace GamePlayTime
{
    public partial class Form3 : Form
    {
        private Form1 form1;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            form1 = Application.OpenForms.OfType<Form1>().First();
            UpdateCalendarDate();
        }

        private void playTimeCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateCalendarDate();
        }

        public void UpdateCalendarDate()
        {
            activityLogLabel1.Text = "";
            if (playTimeCalendar.SelectionStart.Date == playTimeCalendar.SelectionEnd.Date)
            {
                foreach (var ex in Form1.TrackedExecutable)
                {
                    foreach (var dt in ex.DateAndDuration)
                    {
                        if (playTimeCalendar.SelectionStart == dt.Key)
                        {
                            string s = "";
                            if (dt.Value.Hours != 0)
                                s += string.Format("{0} hours\n", dt.Value.Hours);
                            if (dt.Value.Minutes != 0)
                                s += string.Format("{0} minutes\n", dt.Value.Minutes);
                            if (dt.Value.Seconds != 0)
                                s += string.Format("{0} seconds\n", dt.Value.Seconds);
                            activityLogLabel1.Text += string.Format("{0}:\n{1}", ex.WindowTitle, s);
                        }
                    }
                }
            }
        }
    }
}
