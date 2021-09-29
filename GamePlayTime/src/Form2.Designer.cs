
namespace GamePlayTime
{
    partial class Form2
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
            this.HiddenProcessesBox = new System.Windows.Forms.ListBox();
            this.HiddenExecutableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unhideProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HiddenExecutableContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // HiddenProcessesBox
            // 
            this.HiddenProcessesBox.FormattingEnabled = true;
            this.HiddenProcessesBox.ItemHeight = 16;
            this.HiddenProcessesBox.Location = new System.Drawing.Point(12, 12);
            this.HiddenProcessesBox.Name = "HiddenProcessesBox";
            this.HiddenProcessesBox.Size = new System.Drawing.Size(314, 388);
            this.HiddenProcessesBox.TabIndex = 0;
            this.HiddenProcessesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HiddenProcessesBox_MouseDown);
            // 
            // HiddenExecutableContextMenuStrip
            // 
            this.HiddenExecutableContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.HiddenExecutableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unhideProcessToolStripMenuItem});
            this.HiddenExecutableContextMenuStrip.Name = "HiddenExecutableContextMenuStrip";
            this.HiddenExecutableContextMenuStrip.Size = new System.Drawing.Size(179, 28);
            // 
            // unhideProcessToolStripMenuItem
            // 
            this.unhideProcessToolStripMenuItem.Name = "unhideProcessToolStripMenuItem";
            this.unhideProcessToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.unhideProcessToolStripMenuItem.Text = "Unhide Process";
            this.unhideProcessToolStripMenuItem.Click += new System.EventHandler(this.unhideProcessToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 414);
            this.Controls.Add(this.HiddenProcessesBox);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Hidden Processes";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.HiddenExecutableContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox HiddenProcessesBox;
        private System.Windows.Forms.ContextMenuStrip HiddenExecutableContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem unhideProcessToolStripMenuItem;
    }
}