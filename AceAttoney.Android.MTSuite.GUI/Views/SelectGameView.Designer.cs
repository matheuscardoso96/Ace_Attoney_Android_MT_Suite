namespace AceAttoney.Android.MTSuite.GUI.Views
{
    partial class SelectGameView
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
            this.CBGames = new System.Windows.Forms.ComboBox();
            this.LBGame = new System.Windows.Forms.Label();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBGames
            // 
            this.CBGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBGames.FormattingEnabled = true;
            this.CBGames.Location = new System.Drawing.Point(12, 39);
            this.CBGames.Name = "CBGames";
            this.CBGames.Size = new System.Drawing.Size(200, 23);
            this.CBGames.TabIndex = 0;
            // 
            // LBGame
            // 
            this.LBGame.AutoSize = true;
            this.LBGame.Location = new System.Drawing.Point(17, 18);
            this.LBGame.Name = "LBGame";
            this.LBGame.Size = new System.Drawing.Size(35, 15);
            this.LBGame.TabIndex = 1;
            this.LBGame.Text = "Jogo:";
            // 
            // BtnSelect
            // 
            this.BtnSelect.Location = new System.Drawing.Point(70, 68);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(75, 23);
            this.BtnSelect.TabIndex = 2;
            this.BtnSelect.Text = "Escolher";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelectClick);
            // 
            // SelectGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 121);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.LBGame);
            this.Controls.Add(this.CBGames);
            this.MinimumSize = new System.Drawing.Size(240, 160);
            this.Name = "SelectGameView";
            this.Text = "Escolha um jogo:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox CBGames;
        private Label LBGame;
        private Button BtnSelect;
    }
}