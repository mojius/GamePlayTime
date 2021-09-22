
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
            this.activityLogLabel1 = new System.Windows.Forms.Label();
            this.activityLogPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playTimeCalendar
            // 
            this.playTimeCalendar.BackColor = System.Drawing.SystemColors.Control;
            this.playTimeCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Tuesday;
            this.playTimeCalendar.Location = new System.Drawing.Point(14, 15);
            this.playTimeCalendar.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.playTimeCalendar.Name = "playTimeCalendar";
            this.playTimeCalendar.ShowToday = false;
            this.playTimeCalendar.ShowTodayCircle = false;
            this.playTimeCalendar.TabIndex = 0;
            this.playTimeCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.playTimeCalendar_DateChanged);
            // 
            // activityLogPanel1
            // 
            this.activityLogPanel1.AutoScroll = true;
            this.activityLogPanel1.Controls.Add(this.activityLogLabel1);
            this.activityLogPanel1.Location = new System.Drawing.Point(14, 192);
            this.activityLogPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.activityLogPanel1.Name = "activityLogPanel1";
            this.activityLogPanel1.Size = new System.Drawing.Size(227, 164);
            this.activityLogPanel1.TabIndex = 1;
            // 
            // activityLogLabel1
            // 
            this.activityLogLabel1.AutoSize = true;
            this.activityLogLabel1.Location = new System.Drawing.Point(14, 14);
            this.activityLogLabel1.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.activityLogLabel1.MaximumSize = new System.Drawing.Size(171, 0);
            this.activityLogLabel1.Name = "activityLogLabel1";
            this.activityLogLabel1.Size = new System.Drawing.Size(0, 13);
            this.activityLogLabel1.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(260, 366);
            this.Controls.Add(this.activityLogPanel1);
            this.Controls.Add(this.playTimeCalendar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Activity Calendar";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.activityLogPanel1.ResumeLayout(false);
            this.activityLogPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar playTimeCalendar;
        private System.Windows.Forms.Panel activityLogPanel1;
        private System.Windows.Forms.Label activityLogLabel1;
    }
}