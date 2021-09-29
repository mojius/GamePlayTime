
namespace GamePlayTime
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playTimeCalendar = new System.Windows.Forms.MonthCalendar();
            this.activityLogPanel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // playTimeCalendar
            // 
            this.playTimeCalendar.BackColor = System.Drawing.SystemColors.Control;
            this.playTimeCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Tuesday;
            this.playTimeCalendar.Location = new System.Drawing.Point(14, 15);
            this.playTimeCalendar.Margin = new System.Windows.Forms.Padding(7);
            this.playTimeCalendar.MaxSelectionCount = 1;
            this.playTimeCalendar.Name = "playTimeCalendar";
            this.playTimeCalendar.ShowToday = false;
            this.playTimeCalendar.TabIndex = 0;
            this.playTimeCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.PlayTimeCalendar_DateChanged);
            // 
            // activityLogPanel1
            // 
            this.activityLogPanel1.AutoScroll = true;
            this.activityLogPanel1.Location = new System.Drawing.Point(14, 192);
            this.activityLogPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.activityLogPanel1.Name = "activityLogPanel1";
            this.activityLogPanel1.Size = new System.Drawing.Size(227, 164);
            this.activityLogPanel1.TabIndex = 1;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(260, 366);
            this.Controls.Add(this.activityLogPanel1);
            this.Controls.Add(this.playTimeCalendar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Activity Calendar";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar playTimeCalendar;
        private System.Windows.Forms.Panel activityLogPanel1;
    }
}