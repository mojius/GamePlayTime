
namespace GamePlayTime
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.AllProcessesBox = new System.Windows.Forms.ListBox();
            this.AllExecutableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trackProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TrackedProcessesBox = new System.Windows.Forms.ListBox();
            this.TrackedExecutableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopTrackingProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideProcessToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hideProcessToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showHiddenProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTrackedProcessesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHiddenProcessesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllExecutableContextMenuStrip.SuspendLayout();
            this.TrackedExecutableContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllProcessesBox
            // 
            this.AllProcessesBox.CausesValidation = false;
            this.AllProcessesBox.FormattingEnabled = true;
            this.AllProcessesBox.ItemHeight = 16;
            this.AllProcessesBox.Location = new System.Drawing.Point(16, 79);
            this.AllProcessesBox.Margin = new System.Windows.Forms.Padding(4);
            this.AllProcessesBox.MaximumSize = new System.Drawing.Size(333, 388);
            this.AllProcessesBox.MinimumSize = new System.Drawing.Size(333, 48);
            this.AllProcessesBox.Name = "AllProcessesBox";
            this.AllProcessesBox.Size = new System.Drawing.Size(333, 388);
            this.AllProcessesBox.TabIndex = 0;
            this.AllProcessesBox.TabStop = false;
            this.AllProcessesBox.Leave += new System.EventHandler(this.AllProcessesBox_Leave);
            this.AllProcessesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // AllExecutableContextMenuStrip
            // 
            this.AllExecutableContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AllExecutableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackProcessToolStripMenuItem,
            this.hideProcessToolStripMenuItem});
            this.AllExecutableContextMenuStrip.Name = "contextMenuStrip1";
            this.AllExecutableContextMenuStrip.Size = new System.Drawing.Size(166, 52);
            // 
            // trackProcessToolStripMenuItem
            // 
            this.trackProcessToolStripMenuItem.Name = "trackProcessToolStripMenuItem";
            this.trackProcessToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.trackProcessToolStripMenuItem.Text = "Track Process";
            this.trackProcessToolStripMenuItem.Click += new System.EventHandler(this.trackProcessToolStripMenuItem_Click);
            // 
            // hideProcessToolStripMenuItem
            // 
            this.hideProcessToolStripMenuItem.Name = "hideProcessToolStripMenuItem";
            this.hideProcessToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.hideProcessToolStripMenuItem.Text = "Hide Process";
            this.hideProcessToolStripMenuItem.Click += new System.EventHandler(this.hideProcessToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TrackedProcessesBox
            // 
            this.TrackedProcessesBox.FormattingEnabled = true;
            this.TrackedProcessesBox.ItemHeight = 16;
            this.TrackedProcessesBox.Location = new System.Drawing.Point(359, 79);
            this.TrackedProcessesBox.Margin = new System.Windows.Forms.Padding(4);
            this.TrackedProcessesBox.MaximumSize = new System.Drawing.Size(333, 388);
            this.TrackedProcessesBox.MinimumSize = new System.Drawing.Size(333, 48);
            this.TrackedProcessesBox.Name = "TrackedProcessesBox";
            this.TrackedProcessesBox.Size = new System.Drawing.Size(333, 388);
            this.TrackedProcessesBox.TabIndex = 1;
            this.TrackedProcessesBox.TabStop = false;
            this.TrackedProcessesBox.Leave += new System.EventHandler(this.TrackedProcessesBox_Leave);
            this.TrackedProcessesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrackedProcessesBox_MouseDown);
            // 
            // TrackedExecutableContextMenuStrip
            // 
            this.TrackedExecutableContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TrackedExecutableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopTrackingProcessToolStripMenuItem});
            this.TrackedExecutableContextMenuStrip.Name = "TrackedExecutableContextMenuStrip";
            this.TrackedExecutableContextMenuStrip.Size = new System.Drawing.Size(222, 28);
            // 
            // stopTrackingProcessToolStripMenuItem
            // 
            this.stopTrackingProcessToolStripMenuItem.Name = "stopTrackingProcessToolStripMenuItem";
            this.stopTrackingProcessToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.stopTrackingProcessToolStripMenuItem.Text = "Stop Tracking Process";
            this.stopTrackingProcessToolStripMenuItem.Click += new System.EventHandler(this.stopTrackingProcessToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "All Processes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tracked Processes";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTrackedProcessesFileToolStripMenuItem,
            this.openHiddenProcessesFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // processesToolStripMenuItem
            // 
            this.processesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideProcessToolStripMenuItem1,
            this.hideProcessToolStripMenuItem2,
            this.showHiddenProcessesToolStripMenuItem});
            this.processesToolStripMenuItem.Name = "processesToolStripMenuItem";
            this.processesToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.processesToolStripMenuItem.Text = "Processes";
            // 
            // hideProcessToolStripMenuItem1
            // 
            this.hideProcessToolStripMenuItem1.Name = "hideProcessToolStripMenuItem1";
            this.hideProcessToolStripMenuItem1.Size = new System.Drawing.Size(257, 26);
            this.hideProcessToolStripMenuItem1.Text = "Track Process";
            // 
            // hideProcessToolStripMenuItem2
            // 
            this.hideProcessToolStripMenuItem2.Name = "hideProcessToolStripMenuItem2";
            this.hideProcessToolStripMenuItem2.Size = new System.Drawing.Size(257, 26);
            this.hideProcessToolStripMenuItem2.Text = "Hide Process";
            // 
            // showHiddenProcessesToolStripMenuItem
            // 
            this.showHiddenProcessesToolStripMenuItem.Name = "showHiddenProcessesToolStripMenuItem";
            this.showHiddenProcessesToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.showHiddenProcessesToolStripMenuItem.Text = "Show Hidden Processes...";
            this.showHiddenProcessesToolStripMenuItem.Click += new System.EventHandler(this.showHiddenProcessesToolStripMenuItem_Click);
            // 
            // openTrackedProcessesFileToolStripMenuItem
            // 
            this.openTrackedProcessesFileToolStripMenuItem.Name = "openTrackedProcessesFileToolStripMenuItem";
            this.openTrackedProcessesFileToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.openTrackedProcessesFileToolStripMenuItem.Text = "Open Tracked Processes File...";
            // 
            // openHiddenProcessesFileToolStripMenuItem
            // 
            this.openHiddenProcessesFileToolStripMenuItem.Name = "openHiddenProcessesFileToolStripMenuItem";
            this.openHiddenProcessesFileToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.openHiddenProcessesFileToolStripMenuItem.Text = "Open Hidden Processes File...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 480);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TrackedProcessesBox);
            this.Controls.Add(this.AllProcessesBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Game Play Time";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.AllExecutableContextMenuStrip.ResumeLayout(false);
            this.TrackedExecutableContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AllProcessesBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip AllExecutableContextMenuStrip;
        private System.Windows.Forms.ListBox TrackedProcessesBox;
        private System.Windows.Forms.ToolStripMenuItem hideProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackProcessToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip TrackedExecutableContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem stopTrackingProcessToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTrackedProcessesFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openHiddenProcessesFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideProcessToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideProcessToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showHiddenProcessesToolStripMenuItem;
    }
}

