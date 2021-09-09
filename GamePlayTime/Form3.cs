using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void playTimeCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date == e.End.Date)
            {            
                foreach (var ex in Form1.TrackedExecutable)
                {
                    foreach (var dt in ex.DateAndDuration)
                    {
                        if (e.Start == dt.Key)
                        {
                            activityLogLabel1.Text += string.Format("{0}: {1}\n", ex.WindowTitle, dt.Value.ToString());
                        }
                    }
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            form1 = Application.OpenForms.OfType<Form1>().First();
        }
    }
}
