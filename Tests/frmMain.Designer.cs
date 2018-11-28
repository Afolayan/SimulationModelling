namespace Tests
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lCGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test_LCG_mixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.gFSRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalizedFeedbackShiftRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lCGToolStripMenuItem,
            this.gFSRToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // lCGToolStripMenuItem
            // 
            this.lCGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test_LCG_mixedToolStripMenuItem});
            this.lCGToolStripMenuItem.Name = "lCGToolStripMenuItem";
            this.lCGToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lCGToolStripMenuItem.Text = "LCG";
            // 
            // test_LCG_mixedToolStripMenuItem
            // 
            this.test_LCG_mixedToolStripMenuItem.Name = "test_LCG_mixedToolStripMenuItem";
            this.test_LCG_mixedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.test_LCG_mixedToolStripMenuItem.Text = "Mixed";
            this.test_LCG_mixedToolStripMenuItem.Click += new System.EventHandler(this.test_LCG_mixedToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // richTextBox
            // 
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(0, 24);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(740, 319);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // gFSRToolStripMenuItem
            // 
            this.gFSRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalizedFeedbackShiftRegisterToolStripMenuItem});
            this.gFSRToolStripMenuItem.Name = "gFSRToolStripMenuItem";
            this.gFSRToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gFSRToolStripMenuItem.Text = "GFSR";
            // 
            // generalizedFeedbackShiftRegisterToolStripMenuItem
            // 
            this.generalizedFeedbackShiftRegisterToolStripMenuItem.Name = "generalizedFeedbackShiftRegisterToolStripMenuItem";
            this.generalizedFeedbackShiftRegisterToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.generalizedFeedbackShiftRegisterToolStripMenuItem.Text = "Generalized Feedback Shift Register";
            this.generalizedFeedbackShiftRegisterToolStripMenuItem.Click += new System.EventHandler(this.generalizedFeedbackShiftRegisterToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 343);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ToolStripMenuItem lCGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test_LCG_mixedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gFSRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalizedFeedbackShiftRegisterToolStripMenuItem;
    }
}

