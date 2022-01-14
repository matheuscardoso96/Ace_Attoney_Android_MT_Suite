namespace Ace_Attoney_Android_MT_Suite
{
    partial class Main
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
            this.obbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenCapcomObbToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelProgress = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obbToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // obbToolStripMenuItem
            // 
            this.obbToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenCapcomObbToolMenu});
            this.obbToolStripMenuItem.Name = "obbToolStripMenuItem";
            this.obbToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.obbToolStripMenuItem.Text = "Obb";
            // 
            // OpenCapcomObbToolMenu
            // 
            this.OpenCapcomObbToolMenu.Name = "OpenCapcomObbToolMenu";
            this.OpenCapcomObbToolMenu.Size = new System.Drawing.Size(180, 22);
            this.OpenCapcomObbToolMenu.Text = "Open Tool";
            this.OpenCapcomObbToolMenu.Click += new System.EventHandler(this.OpenCapcomObbTool);
            // 
            // LabelProgress
            // 
            this.LabelProgress.AutoSize = true;
            this.LabelProgress.Location = new System.Drawing.Point(16, 56);
            this.LabelProgress.Name = "LabelProgress";
            this.LabelProgress.Size = new System.Drawing.Size(33, 15);
            this.LabelProgress.TabIndex = 1;
            this.LabelProgress.Text = "Teste";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LabelProgress);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem obbToolStripMenuItem;
        private ToolStripMenuItem OpenCapcomObbToolMenu;
        private Label LabelProgress;
    }
}