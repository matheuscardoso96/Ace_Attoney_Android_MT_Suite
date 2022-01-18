namespace AceAttoney.Android.MTSuite.GUI.Views
{
    partial class ApkView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.decompilarApkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TMSIDecompApk = new System.Windows.Forms.ToolStripMenuItem();
            this.TbxStatus = new System.Windows.Forms.TextBox();
            this.LBDecApks = new System.Windows.Forms.ListBox();
            this.CMSCompile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TMSICompileApk = new System.Windows.Forms.ToolStripMenuItem();
            this.TMSIMovieObbSizeFix = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.CMSCompile.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decompilarApkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(333, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // decompilarApkToolStripMenuItem
            // 
            this.decompilarApkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TMSIDecompApk});
            this.decompilarApkToolStripMenuItem.Name = "decompilarApkToolStripMenuItem";
            this.decompilarApkToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.decompilarApkToolStripMenuItem.Text = "Opções";
            // 
            // TMSIDecompApk
            // 
            this.TMSIDecompApk.Name = "TMSIDecompApk";
            this.TMSIDecompApk.Size = new System.Drawing.Size(180, 22);
            this.TMSIDecompApk.Text = "Decompilar apk";
            this.TMSIDecompApk.Click += new System.EventHandler(this.TMSIDecompApkClick);
            // 
            // TbxStatus
            // 
            this.TbxStatus.Location = new System.Drawing.Point(12, 284);
            this.TbxStatus.Multiline = true;
            this.TbxStatus.Name = "TbxStatus";
            this.TbxStatus.ReadOnly = true;
            this.TbxStatus.Size = new System.Drawing.Size(280, 36);
            this.TbxStatus.TabIndex = 1;
            // 
            // LBDecApks
            // 
            this.LBDecApks.FormattingEnabled = true;
            this.LBDecApks.ItemHeight = 15;
            this.LBDecApks.Location = new System.Drawing.Point(12, 49);
            this.LBDecApks.Name = "LBDecApks";
            this.LBDecApks.Size = new System.Drawing.Size(280, 229);
            this.LBDecApks.TabIndex = 2;
            this.LBDecApks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LBDecApks_MouseDown);
            // 
            // CMSCompile
            // 
            this.CMSCompile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TMSICompileApk,
            this.TMSIMovieObbSizeFix});
            this.CMSCompile.Name = "CMSCompile";
            this.CMSCompile.Size = new System.Drawing.Size(213, 48);
            // 
            // TMSICompileApk
            // 
            this.TMSICompileApk.Name = "TMSICompileApk";
            this.TMSICompileApk.Size = new System.Drawing.Size(212, 22);
            this.TMSICompileApk.Text = "Compilar Apk";
            this.TMSICompileApk.Click += new System.EventHandler(this.TMSICompileApkClick);
            // 
            // TMSIMovieObbSizeFix
            // 
            this.TMSIMovieObbSizeFix.Name = "TMSIMovieObbSizeFix";
            this.TMSIMovieObbSizeFix.Size = new System.Drawing.Size(212, 22);
            this.TMSIMovieObbSizeFix.Text = "Fix tamanho obb de vídeo";
            this.TMSIMovieObbSizeFix.Click += new System.EventHandler(this.TMSIMovieObbSizeFixClick);
            // 
            // ApkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 332);
            this.Controls.Add(this.LBDecApks);
            this.Controls.Add(this.TbxStatus);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ApkView";
            this.Text = "Apk";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.CMSCompile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem decompilarApkToolStripMenuItem;
        private ToolStripMenuItem TMSIDecompApk;
        private TextBox TbxStatus;
        private ListBox LBDecApks;
        private ContextMenuStrip CMSCompile;
        private ToolStripMenuItem TMSICompileApk;
        private ToolStripMenuItem TMSIMovieObbSizeFix;
    }
}