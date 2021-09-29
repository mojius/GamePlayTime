using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GamePlayTime
{
    public partial class Form3 : Form
    {
        private List<Label> labels = new List<Label>();
        public Form3() => InitializeComponent();
        private void Form3_Load(object sender, EventArgs e) => UpdateCalendarDate();
        private void PlayTimeCalendar_DateChanged(object sender, DateRangeEventArgs e) => UpdateCalendarDate();


        public void UpdateCalendarDate()
        {
            labels.Clear();
            activityLogPanel1.Controls.Clear();
            if (playTimeCalendar.SelectionStart.Date == playTimeCalendar.SelectionEnd.Date)
            {
                foreach (var ex in Form1.TrackedExecutable)
                {
                    foreach (var dt in ex.DateAndDuration)
                    {
                        if (playTimeCalendar.SelectionStart == dt.Key)
                        {
                            string s = "";
                            Label l = new Label
                            {
                                AutoSize = true,
                                Parent = activityLogPanel1
                            };
                            System.Drawing.Point p = new System.Drawing.Point
                            {
                                //Okay, so if this label is not the first label in the list, then put it 14 pixels after
                                //the position of the LAST label in the index
                                //Otherwise, just put it 14 pixels down 
                                Y = (labels.Count == 0 ? 14 : labels.Last().Location.Y + labels.Last().Size.Height + 14),
                                X = 14
                            };
                            l.Location = p;

                            if (dt.Value.Hours != 0) s += string.Format("{0} hours\n", dt.Value.Hours);
                            if (dt.Value.Minutes != 0) s += string.Format("{0} minutes\n", dt.Value.Minutes);
                            if (dt.Value.Seconds != 0) s += string.Format("{0} seconds\n", dt.Value.Seconds);
                            l.Text += string.Format("{0}:\n{1}", ex.WindowTitle, s);
                            labels.Add(l);

                        }
                    }
                }
            }
        }
    }
}
