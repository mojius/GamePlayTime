
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AllExecutableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trackProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TrackedExecutableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopTrackingProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTrackedProcessesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHiddenProcessesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.processesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackProcessToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hideProcessToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showHiddenProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewActivityCalendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrackedExecutableContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showOfflineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTrackedProcessFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenHiddenProcessFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.AllProcessesBox = new System.Windows.Forms.ListBox();
            this.TrackedProcessesBox = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.AllExecutableContextMenuStrip.SuspendLayout();
            this.TrackedExecutableContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.notifyIconContextMenuStrip.SuspendLayout();
            this.TrackedExecutableContextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllExecutableContextMenuStrip
            // 
            this.AllExecutableContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AllExecutableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackProcessToolStripMenuItem,
            this.hideProcessToolStripMenuItem});
            this.AllExecutableContextMenuStrip.Name = "contextMenuStrip1";
            this.AllExecutableContextMenuStrip.Size = new System.Drawing.Size(145, 48);
            // 
            // trackProcessToolStripMenuItem
            // 
            this.trackProcessToolStripMenuItem.Name = "trackProcessToolStripMenuItem";
            this.trackProcessToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.trackProcessToolStripMenuItem.Text = "Track Process";
            this.trackProcessToolStripMenuItem.Click += new System.EventHandler(this.trackProcessToolStripMenuItem_Click);
            // 
            // hideProcessToolStripMenuItem
            // 
            this.hideProcessToolStripMenuItem.Name = "hideProcessToolStripMenuItem";
            this.hideProcessToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.hideProcessToolStripMenuItem.Text = "Hide Process";
            this.hideProcessToolStripMenuItem.Click += new System.EventHandler(this.hideProcessToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TrackedExecutableContextMenuStrip
            // 
            this.TrackedExecutableContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TrackedExecutableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopTrackingProcessToolStripMenuItem});
            this.TrackedExecutableContextMenuStrip.Name = "TrackedExecutableContextMenuStrip";
            this.TrackedExecutableContextMenuStrip.Size = new System.Drawing.Size(189, 26);
            // 
            // stopTrackingProcessToolStripMenuItem
            // 
            this.stopTrackingProcessToolStripMenuItem.Name = "stopTrackingProcessToolStripMenuItem";
            this.stopTrackingProcessToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.stopTrackingProcessToolStripMenuItem.Text = "Stop Tracking Process";
            this.stopTrackingProcessToolStripMenuItem.Click += new System.EventHandler(this.stopTrackingProcessToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "All Processes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tracked Processes";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processesToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTrackedProcessesFileToolStripMenuItem,
            this.openHiddenProcessesFileToolStripMenuItem,
            this.runOnStartupToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownClosed += new System.EventHandler(this.fileToolStripMenuItem_DropDownClosed);
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // openTrackedProcessesFileToolStripMenuItem
            // 
            this.openTrackedProcessesFileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openTrackedProcessesFileToolStripMenuItem.Name = "openTrackedProcessesFileToolStripMenuItem";
            this.openTrackedProcessesFileToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.openTrackedProcessesFileToolStripMenuItem.Text = "Open Tracked Processes File...";
            this.openTrackedProcessesFileToolStripMenuItem.Click += new System.EventHandler(this.OpenTrackedProcessesFileToolStripMenuItem_Click);
            // 
            // openHiddenProcessesFileToolStripMenuItem
            // 
            this.openHiddenProcessesFileToolStripMenuItem.Name = "openHiddenProcessesFileToolStripMenuItem";
            this.openHiddenProcessesFileToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.openHiddenProcessesFileToolStripMenuItem.Text = "Open Hidden Processes File...";
            this.openHiddenProcessesFileToolStripMenuItem.Click += new System.EventHandler(this.OpenHiddenProcessesFileToolStripMenuItem_Click);
            // 
            // runOnStartupToolStripMenuItem
            // 
            this.runOnStartupToolStripMenuItem.CheckOnClick = true;
            this.runOnStartupToolStripMenuItem.Name = "runOnStartupToolStripMenuItem";
            this.runOnStartupToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.runOnStartupToolStripMenuItem.Text = "Run On Startup";
            this.runOnStartupToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.runOnStartupToolStripMenuItem_CheckStateChanged);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(230, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // processesToolStripMenuItem
            // 
            this.processesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackProcessToolStripMenuItem1,
            this.hideProcessToolStripMenuItem2,
            this.showHiddenProcessesToolStripMenuItem});
            this.processesToolStripMenuItem.Name = "processesToolStripMenuItem";
            this.processesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.processesToolStripMenuItem.Text = "Processes";
            this.processesToolStripMenuItem.DropDownClosed += new System.EventHandler(this.processesToolStripMenuItem_DropDownClosed);
            this.processesToolStripMenuItem.DropDownOpening += new System.EventHandler(this.processesToolStripMenuItem_DropDownOpening);
            // 
            // trackProcessToolStripMenuItem1
            // 
            this.trackProcessToolStripMenuItem1.Name = "trackProcessToolStripMenuItem1";
            this.trackProcessToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this.trackProcessToolStripMenuItem1.Text = "Track Process...";
            this.trackProcessToolStripMenuItem1.Click += new System.EventHandler(this.trackProcessToolStripMenuItem1_Click);
            // 
            // hideProcessToolStripMenuItem2
            // 
            this.hideProcessToolStripMenuItem2.Name = "hideProcessToolStripMenuItem2";
            this.hideProcessToolStripMenuItem2.Size = new System.Drawing.Size(208, 22);
            this.hideProcessToolStripMenuItem2.Text = "Hide Process...";
            this.hideProcessToolStripMenuItem2.Click += new System.EventHandler(this.hideProcessToolStripMenuItem2_Click);
            // 
            // showHiddenProcessesToolStripMenuItem
            // 
            this.showHiddenProcessesToolStripMenuItem.Name = "showHiddenProcessesToolStripMenuItem";
            this.showHiddenProcessesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.showHiddenProcessesToolStripMenuItem.Text = "Show Hidden Processes...";
            this.showHiddenProcessesToolStripMenuItem.Click += new System.EventHandler(this.showHiddenProcessesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewActivityCalendarToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewActivityCalendarToolStripMenuItem
            // 
            this.viewActivityCalendarToolStripMenuItem.Name = "viewActivityCalendarToolStripMenuItem";
            this.viewActivityCalendarToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.viewActivityCalendarToolStripMenuItem.Text = "View Activity Calendar...";
            this.viewActivityCalendarToolStripMenuItem.Click += new System.EventHandler(this.viewActivityCalendarToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Game Play Time";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // TrackedExecutableContextMenuStrip2
            // 
            this.TrackedExecutableContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TrackedExecutableContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOfflineToolStripMenuItem});
            this.TrackedExecutableContextMenuStrip2.Name = "TrackedExecutableContextMenuStrip2";
            this.TrackedExecutableContextMenuStrip2.Size = new System.Drawing.Size(240, 26);
            // 
            // showOfflineToolStripMenuItem
            // 
            this.showOfflineToolStripMenuItem.Checked = true;
            this.showOfflineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOfflineToolStripMenuItem.Name = "showOfflineToolStripMenuItem";
            this.showOfflineToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.showOfflineToolStripMenuItem.Text = "Show Offline Tracked Processes";
            this.showOfflineToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.showOfflineToolStripMenuItem_CheckStateChanged);
            this.showOfflineToolStripMenuItem.Click += new System.EventHandler(this.showOfflineToolStripMenuItem_Click);
            // 
            // OpenTrackedProcessFileDialog
            // 
            this.OpenTrackedProcessFileDialog.FileName = "trackedexe.json";
            this.OpenTrackedProcessFileDialog.Title = "Open Tracked Processes File (.json)...";
            // 
            // OpenHiddenProcessFileDialog
            // 
            this.OpenHiddenProcessFileDialog.FileName = "hiddenexe.json";
            this.OpenHiddenProcessFileDialog.Title = "Open Hidden Processes File (.json)...";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.AllProcessesBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TrackedProcessesBox);
            this.splitContainer1.Size = new System.Drawing.Size(1056, 518);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 6;
            this.splitContainer1.TabStop = false;
            // 
            // AllProcessesBox
            // 
            this.AllProcessesBox.CausesValidation = false;
            this.AllProcessesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllProcessesBox.FormattingEnabled = true;
            this.AllProcessesBox.HorizontalScrollbar = true;
            this.AllProcessesBox.Location = new System.Drawing.Point(0, 0);
            this.AllProcessesBox.Name = "AllProcessesBox";
            this.AllProcessesBox.Size = new System.Drawing.Size(486, 518);
            this.AllProcessesBox.TabIndex = 0;
            this.AllProcessesBox.TabStop = false;
            this.AllProcessesBox.Leave += new System.EventHandler(this.AllProcessesBox_Leave);
            this.AllProcessesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // TrackedProcessesBox
            // 
            this.TrackedProcessesBox.CausesValidation = false;
            this.TrackedProcessesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackedProcessesBox.FormattingEnabled = true;
            this.TrackedProcessesBox.HorizontalScrollbar = true;
            this.TrackedProcessesBox.Location = new System.Drawing.Point(0, 0);
            this.TrackedProcessesBox.Name = "TrackedProcessesBox";
            this.TrackedProcessesBox.Size = new System.Drawing.Size(566, 518);
            this.TrackedProcessesBox.TabIndex = 1;
            this.TrackedProcessesBox.TabStop = false;
            this.TrackedProcessesBox.Leave += new System.EventHandler(this.TrackedProcessesBox_Leave);
            this.TrackedProcessesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrackedProcessesBox_MouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(1056, 17);
            this.splitContainer2.SplitterDistance = 486;
            this.splitContainer2.TabIndex = 7;
            this.splitContainer2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1056, 559);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Play Time";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.AllExecutableContextMenuStrip.ResumeLayout(false);
            this.TrackedExecutableContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.TrackedExecutableContextMenuStrip2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip AllExecutableContextMenuStrip;
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
        private System.Windows.Forms.ToolStripMenuItem trackProcessToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideProcessToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showHiddenProcessesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TrackedExecutableContextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showOfflineToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenTrackedProcessFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenHiddenProcessFileDialog;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runOnStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewActivityCalendarToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox AllProcessesBox;
        private System.Windows.Forms.ListBox TrackedProcessesBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

