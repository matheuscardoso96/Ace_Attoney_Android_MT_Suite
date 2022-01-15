namespace Ace_Attoney_Android_MT_Suite.Views
{
    partial class ZipObb
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
            this.ButtonUnzip = new System.Windows.Forms.Button();
            this.ButtonZip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonUnzip
            // 
            this.ButtonUnzip.Location = new System.Drawing.Point(12, 12);
            this.ButtonUnzip.Name = "ButtonUnzip";
            this.ButtonUnzip.Size = new System.Drawing.Size(99, 23);
            this.ButtonUnzip.TabIndex = 0;
            this.ButtonUnzip.Text = "Descompactar";
            this.ButtonUnzip.UseVisualStyleBackColor = true;
            this.ButtonUnzip.Click += new System.EventHandler(this.UnzipObbClick);
            // 
            // ButtonZip
            // 
            this.ButtonZip.Location = new System.Drawing.Point(140, 12);
            this.ButtonZip.Name = "ButtonZip";
            this.ButtonZip.Size = new System.Drawing.Size(99, 23);
            this.ButtonZip.TabIndex = 1;
            this.ButtonZip.Text = "Compactar";
            this.ButtonZip.UseVisualStyleBackColor = true;
            this.ButtonZip.Click += new System.EventHandler(this.ZipObbClick);
            // 
            // ZipObb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 66);
            this.Controls.Add(this.ButtonZip);
            this.Controls.Add(this.ButtonUnzip);
            this.Name = "ZipObb";
            this.Text = "Obb de vídeos";
            this.ResumeLayout(false);

        }

        #endregion

        private Button ButtonUnzip;
        private Button ButtonZip;
    }
}