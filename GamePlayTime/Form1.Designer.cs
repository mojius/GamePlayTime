
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trackProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TrackedProcessesBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllProcessesBox
            // 
            this.AllProcessesBox.CausesValidation = false;
            this.AllProcessesBox.FormattingEnabled = true;
            this.AllProcessesBox.Location = new System.Drawing.Point(12, 28);
            this.AllProcessesBox.MaximumSize = new System.Drawing.Size(251, 316);
            this.AllProcessesBox.MinimumSize = new System.Drawing.Size(251, 40);
            this.AllProcessesBox.Name = "AllProcessesBox";
            this.AllProcessesBox.Size = new System.Drawing.Size(251, 316);
            this.AllProcessesBox.TabIndex = 0;
            this.AllProcessesBox.TabStop = false;
            this.AllProcessesBox.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.AllProcessesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackProcessToolStripMenuItem,
            this.hideProcessToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // trackProcessToolStripMenuItem
            // 
            this.trackProcessToolStripMenuItem.Name = "trackProcessToolStripMenuItem";
            this.trackProcessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.trackProcessToolStripMenuItem.Text = "Track Process";
            this.trackProcessToolStripMenuItem.Click += new System.EventHandler(this.trackProcessToolStripMenuItem_Click);
            // 
            // hideProcessToolStripMenuItem
            // 
            this.hideProcessToolStripMenuItem.Name = "hideProcessToolStripMenuItem";
            this.hideProcessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.TrackedProcessesBox.Location = new System.Drawing.Point(269, 28);
            this.TrackedProcessesBox.MaximumSize = new System.Drawing.Size(251, 316);
            this.TrackedProcessesBox.MinimumSize = new System.Drawing.Size(251, 40);
            this.TrackedProcessesBox.Name = "TrackedProcessesBox";
            this.TrackedProcessesBox.Size = new System.Drawing.Size(251, 316);
            this.TrackedProcessesBox.TabIndex = 1;
            this.TrackedProcessesBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 450);
            this.Controls.Add(this.TrackedProcessesBox);
            this.Controls.Add(this.AllProcessesBox);
            this.Name = "Form1";
            this.Text = "Game Play Time";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox AllProcessesBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListBox TrackedProcessesBox;
        private System.Windows.Forms.ToolStripMenuItem hideProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackProcessToolStripMenuItem;
    }
}

