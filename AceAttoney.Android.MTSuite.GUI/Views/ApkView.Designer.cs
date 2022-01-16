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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.decompilarApkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TMSIDecompApk = new System.Windows.Forms.ToolStripMenuItem();
            this.TMSICompApk = new System.Windows.Forms.ToolStripMenuItem();
            this.TbxStatus = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decompilarApkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(304, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // decompilarApkToolStripMenuItem
            // 
            this.decompilarApkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TMSIDecompApk,
            this.TMSICompApk});
            this.decompilarApkToolStripMenuItem.Name = "decompilarApkToolStripMenuItem";
            this.decompilarApkToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.decompilarApkToolStripMenuItem.Text = "Apk";
            // 
            // TMSIDecompApk
            // 
            this.TMSIDecompApk.Name = "TMSIDecompApk";
            this.TMSIDecompApk.Size = new System.Drawing.Size(180, 22);
            this.TMSIDecompApk.Text = "Decompilar apk";
            this.TMSIDecompApk.Click += new System.EventHandler(this.TMSIDecompApkClick);
            // 
            // TMSICompApk
            // 
            this.TMSICompApk.Name = "TMSICompApk";
            this.TMSICompApk.Size = new System.Drawing.Size(180, 22);
            this.TMSICompApk.Text = "Compilar apk";
            // 
            // TbxStatus
            // 
            this.TbxStatus.Location = new System.Drawing.Point(12, 37);
            this.TbxStatus.Multiline = true;
            this.TbxStatus.Name = "TbxStatus";
            this.TbxStatus.ReadOnly = true;
            this.TbxStatus.Size = new System.Drawing.Size(280, 80);
            this.TbxStatus.TabIndex = 1;
            // 
            // ApkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 192);
            this.Controls.Add(this.TbxStatus);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ApkView";
            this.Text = "ApkView";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem decompilarApkToolStripMenuItem;
        private ToolStripMenuItem TMSICompApk;
        private ToolStripMenuItem TMSIDecompApk;
        private TextBox TbxStatus;
    }
}