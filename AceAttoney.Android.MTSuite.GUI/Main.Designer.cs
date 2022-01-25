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
            this.MSICapcomObbTool = new System.Windows.Forms.ToolStripMenuItem();
            this.MSIMovieObb = new System.Windows.Forms.ToolStripMenuItem();
            this.MSIToolApk = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TMSIWorkPath = new System.Windows.Forms.ToolStripMenuItem();
            this.gmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gmdToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obbToolStripMenuItem,
            this.gmdToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // obbToolStripMenuItem
            // 
            this.obbToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MSICapcomObbTool,
            this.MSIMovieObb,
            this.MSIToolApk});
            this.obbToolStripMenuItem.Name = "obbToolStripMenuItem";
            this.obbToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.obbToolStripMenuItem.Text = "Obb";
            // 
            // MSICapcomObbTool
            // 
            this.MSICapcomObbTool.Name = "MSICapcomObbTool";
            this.MSICapcomObbTool.Size = new System.Drawing.Size(184, 22);
            this.MSICapcomObbTool.Text = "Tool de main obb";
            this.MSICapcomObbTool.Click += new System.EventHandler(this.OpenCapcomObbTool);
            // 
            // MSIMovieObb
            // 
            this.MSIMovieObb.Name = "MSIMovieObb";
            this.MSIMovieObb.Size = new System.Drawing.Size(184, 22);
            this.MSIMovieObb.Text = "Tool de obb de vídeo";
            this.MSIMovieObb.Click += new System.EventHandler(this.OpenMovieObbToolClick);
            // 
            // MSIToolApk
            // 
            this.MSIToolApk.Name = "MSIToolApk";
            this.MSIToolApk.Size = new System.Drawing.Size(184, 22);
            this.MSIToolApk.Text = "Tool de apk";
            this.MSIToolApk.Click += new System.EventHandler(this.MSIToolApkClick);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TMSIWorkPath});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // TMSIWorkPath
            // 
            this.TMSIWorkPath.Name = "TMSIWorkPath";
            this.TMSIWorkPath.Size = new System.Drawing.Size(169, 22);
            this.TMSIWorkPath.Text = "Pastra de trabalho";
            this.TMSIWorkPath.Click += new System.EventHandler(this.TMSIWorkPathClick);
            // 
            // gmdToolStripMenuItem
            // 
            this.gmdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gmdToolToolStripMenuItem});
            this.gmdToolStripMenuItem.Name = "gmdToolStripMenuItem";
            this.gmdToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.gmdToolStripMenuItem.Text = "Gmd";
            // 
            // gmdToolToolStripMenuItem
            // 
            this.gmdToolToolStripMenuItem.Name = "gmdToolToolStripMenuItem";
            this.gmdToolToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gmdToolToolStripMenuItem.Text = "Gmd tool";
            this.gmdToolToolStripMenuItem.Click += new System.EventHandler(this.GmdToolClick);
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
        private ToolStripMenuItem MSICapcomObbTool;
        private ToolStripMenuItem MSIMovieObb;
        private ToolStripMenuItem MSIToolApk;
        private ToolStripMenuItem configuraçõesToolStripMenuItem;
        private ToolStripMenuItem TMSIWorkPath;
        private ToolStripMenuItem gmdToolStripMenuItem;
        private ToolStripMenuItem gmdToolToolStripMenuItem;
    }
}