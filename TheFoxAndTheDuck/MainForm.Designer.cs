namespace TheFoxAndTheDuck {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ProblemTextPanel = new System.Windows.Forms.Panel();
            this.ProblemTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.HelpTextStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProblemDisplayPanel = new TheFoxAndTheDuck.DrawingPanel();
            this.ProblemTextPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProblemTextPanel
            // 
            this.ProblemTextPanel.Controls.Add(this.ProblemTextBox);
            this.ProblemTextPanel.Location = new System.Drawing.Point(13, 13);
            this.ProblemTextPanel.Name = "ProblemTextPanel";
            this.ProblemTextPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ProblemTextPanel.Size = new System.Drawing.Size(669, 65);
            this.ProblemTextPanel.TabIndex = 0;
            this.ProblemTextPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ProblemTextPanel_Paint);
            // 
            // ProblemTextBox
            // 
            this.ProblemTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProblemTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProblemTextBox.Enabled = false;
            this.ProblemTextBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProblemTextBox.Location = new System.Drawing.Point(5, 5);
            this.ProblemTextBox.Multiline = true;
            this.ProblemTextBox.Name = "ProblemTextBox";
            this.ProblemTextBox.ReadOnly = true;
            this.ProblemTextBox.Size = new System.Drawing.Size(659, 55);
            this.ProblemTextBox.TabIndex = 0;
            this.ProblemTextBox.Text = resources.GetString("ProblemTextBox.Text");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpTextStatusLabel,
            this.GameStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // HelpTextStatusLabel
            // 
            this.HelpTextStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.HelpTextStatusLabel.Name = "HelpTextStatusLabel";
            this.HelpTextStatusLabel.Size = new System.Drawing.Size(339, 19);
            this.HelpTextStatusLabel.Text = "Use arrow keys (←, ↑, ↓, →) to move the duck. Press R to restart";
            // 
            // GameStatusLabel
            // 
            this.GameStatusLabel.Name = "GameStatusLabel";
            this.GameStatusLabel.Size = new System.Drawing.Size(152, 19);
            this.GameStatusLabel.Text = "The duck is still in the pond";
            this.GameStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProblemDisplayPanel
            // 
            this.ProblemDisplayPanel.Location = new System.Drawing.Point(13, 84);
            this.ProblemDisplayPanel.Name = "ProblemDisplayPanel";
            this.ProblemDisplayPanel.Size = new System.Drawing.Size(669, 274);
            this.ProblemDisplayPanel.TabIndex = 1;
            this.ProblemDisplayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ProblemDisplayPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 383);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ProblemDisplayPanel);
            this.Controls.Add(this.ProblemTextPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Fox and The Duck";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ProblemTextPanel.ResumeLayout(false);
            this.ProblemTextPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ProblemTextPanel;
        private TheFoxAndTheDuck.DrawingPanel ProblemDisplayPanel;
        private System.Windows.Forms.TextBox ProblemTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel HelpTextStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel GameStatusLabel;
    }
}

