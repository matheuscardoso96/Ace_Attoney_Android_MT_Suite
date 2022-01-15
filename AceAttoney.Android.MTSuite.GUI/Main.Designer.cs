namespace AceAttoney.Android.MTSuite.GUI
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
            this.OpenMovieObbOMS = new System.Windows.Forms.ToolStripMenuItem();
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
            this.OpenCapcomObbToolMenu,
            this.OpenMovieObbOMS});
            this.obbToolStripMenuItem.Name = "obbToolStripMenuItem";
            this.obbToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.obbToolStripMenuItem.Text = "Obb";
            // 
            // OpenCapcomObbToolMenu
            // 
            this.OpenCapcomObbToolMenu.Name = "OpenCapcomObbToolMenu";
            this.OpenCapcomObbToolMenu.Size = new System.Drawing.Size(184, 22);
            this.OpenCapcomObbToolMenu.Text = "Tool de main obb";
            this.OpenCapcomObbToolMenu.Click += new System.EventHandler(this.OpenCapcomObbTool);
            // 
            // OpenMovieObbOMS
            // 
            this.OpenMovieObbOMS.Name = "OpenMovieObbOMS";
            this.OpenMovieObbOMS.Size = new System.Drawing.Size(184, 22);
            this.OpenMovieObbOMS.Text = "Tool de obb de vídeo";
            this.OpenMovieObbOMS.Click += new System.EventHandler(this.OpenMovieObbToolClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private ToolStripMenuItem OpenMovieObbOMS;
    }
}