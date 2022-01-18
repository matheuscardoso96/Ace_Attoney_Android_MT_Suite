namespace AceAttoney.Android.MTSuite.GUI.Views
{
    partial class CapcomObbView
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
            this.MenuCapcomObb = new System.Windows.Forms.MenuStrip();
            this.openMainobbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenObbMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseObbMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TVObbArchive = new System.Windows.Forms.TreeView();
            this.CmsObbOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TbxStatus = new System.Windows.Forms.TextBox();
            this.SaveIconButton = new System.Windows.Forms.Label();
            this.CmsMultipleImport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmsOptionImportMultiple = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsOptionExportObb = new System.Windows.Forms.ToolStripMenuItem();
            this.LBReplacedFiles = new System.Windows.Forms.ListBox();
            this.LbReplaced = new System.Windows.Forms.Label();
            this.MenuCapcomObb.SuspendLayout();
            this.CmsObbOptions.SuspendLayout();
            this.CmsMultipleImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuCapcomObb
            // 
            this.MenuCapcomObb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMainobbToolStripMenuItem});
            this.MenuCapcomObb.Location = new System.Drawing.Point(0, 0);
            this.MenuCapcomObb.Name = "MenuCapcomObb";
            this.MenuCapcomObb.Size = new System.Drawing.Size(794, 24);
            this.MenuCapcomObb.TabIndex = 0;
            this.MenuCapcomObb.Text = "menuStrip1";
            // 
            // openMainobbToolStripMenuItem
            // 
            this.openMainobbToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenObbMenuItem,
            this.CloseObbMenuItem});
            this.openMainobbToolStripMenuItem.Name = "openMainobbToolStripMenuItem";
            this.openMainobbToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.openMainobbToolStripMenuItem.Text = " Main .obb";
            // 
            // OpenObbMenuItem
            // 
            this.OpenObbMenuItem.Name = "OpenObbMenuItem";
            this.OpenObbMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenObbMenuItem.Text = "Open";
            this.OpenObbMenuItem.Click += new System.EventHandler(this.OpenObbClick);
            // 
            // CloseObbMenuItem
            // 
            this.CloseObbMenuItem.Name = "CloseObbMenuItem";
            this.CloseObbMenuItem.Size = new System.Drawing.Size(103, 22);
            this.CloseObbMenuItem.Text = "Close";
            this.CloseObbMenuItem.Click += new System.EventHandler(this.CloseObbClick);
            // 
            // TVObbArchive
            // 
            this.TVObbArchive.Location = new System.Drawing.Point(12, 49);
            this.TVObbArchive.Name = "TVObbArchive";
            this.TVObbArchive.Size = new System.Drawing.Size(485, 575);
            this.TVObbArchive.TabIndex = 1;
            this.TVObbArchive.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVObbArchive_AfterSelect);
            this.TVObbArchive.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TVObbArchive_NodeMouseClick);
            // 
            // CmsObbOptions
            // 
            this.CmsObbOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem,
            this.importarToolStripMenuItem});
            this.CmsObbOptions.Name = "contextMenuStrip1";
            this.CmsObbOptions.Size = new System.Drawing.Size(121, 48);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exportarToolStripMenuItem.Text = "Exportar";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.CmsObbOptionExport);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importarToolStripMenuItem.Text = "Importar";
            this.importarToolStripMenuItem.Click += new System.EventHandler(this.CmsObbOptionImport);
            // 
            // TbxStatus
            // 
            this.TbxStatus.Location = new System.Drawing.Point(12, 646);
            this.TbxStatus.Name = "TbxStatus";
            this.TbxStatus.ReadOnly = true;
            this.TbxStatus.Size = new System.Drawing.Size(485, 23);
            this.TbxStatus.TabIndex = 2;
            // 
            // SaveIconButton
            // 
            this.SaveIconButton.AutoSize = true;
            this.SaveIconButton.Image = global::AceAttoney.Android.MTSuite.GUI.Properties.Resources.SaveIcon;
            this.SaveIconButton.Location = new System.Drawing.Point(14, 31);
            this.SaveIconButton.Name = "SaveIconButton";
            this.SaveIconButton.Size = new System.Drawing.Size(13, 15);
            this.SaveIconButton.TabIndex = 3;
            this.SaveIconButton.Text = "  ";
            this.SaveIconButton.Click += new System.EventHandler(this.SaveIconClick);
            // 
            // CmsMultipleImport
            // 
            this.CmsMultipleImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsOptionExportObb,
            this.CmsOptionImportMultiple});
            this.CmsMultipleImport.Name = "CmsMultipleImport";
            this.CmsMultipleImport.Size = new System.Drawing.Size(181, 70);
            // 
            // CmsOptionImportMultiple
            // 
            this.CmsOptionImportMultiple.Name = "CmsOptionImportMultiple";
            this.CmsOptionImportMultiple.Size = new System.Drawing.Size(180, 22);
            this.CmsOptionImportMultiple.Text = "Importar de pasta";
            this.CmsOptionImportMultiple.Click += new System.EventHandler(this.CmsOptionImportMultipleClick);
            // 
            // CmsOptionExportObb
            // 
            this.CmsOptionExportObb.Name = "CmsOptionExportObb";
            this.CmsOptionExportObb.Size = new System.Drawing.Size(180, 22);
            this.CmsOptionExportObb.Text = "Exportar para pasta";
            this.CmsOptionExportObb.Click += new System.EventHandler(this.CmsOptionExportAllObbFilesClick);
            // 
            // LBReplacedFiles
            // 
            this.LBReplacedFiles.FormattingEnabled = true;
            this.LBReplacedFiles.ItemHeight = 15;
            this.LBReplacedFiles.Location = new System.Drawing.Point(515, 49);
            this.LBReplacedFiles.Name = "LBReplacedFiles";
            this.LBReplacedFiles.Size = new System.Drawing.Size(267, 574);
            this.LBReplacedFiles.TabIndex = 4;
            // 
            // LbReplaced
            // 
            this.LbReplaced.AutoSize = true;
            this.LbReplaced.Location = new System.Drawing.Point(577, 31);
            this.LbReplaced.Name = "LbReplaced";
            this.LbReplaced.Size = new System.Drawing.Size(121, 15);
            this.LbReplaced.TabIndex = 5;
            this.LbReplaced.Text = "Arquivos substítuidos";
            // 
            // CapcomObbView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 681);
            this.Controls.Add(this.LbReplaced);
            this.Controls.Add(this.LBReplacedFiles);
            this.Controls.Add(this.SaveIconButton);
            this.Controls.Add(this.TbxStatus);
            this.Controls.Add(this.TVObbArchive);
            this.Controls.Add(this.MenuCapcomObb);
            this.MainMenuStrip = this.MenuCapcomObb;
            this.Name = "CapcomObbView";
            this.Text = "Obb principal";
            this.MenuCapcomObb.ResumeLayout(false);
            this.MenuCapcomObb.PerformLayout();
            this.CmsObbOptions.ResumeLayout(false);
            this.CmsMultipleImport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MenuCapcomObb;
        private ToolStripMenuItem openMainobbToolStripMenuItem;
        private ToolStripMenuItem OpenObbMenuItem;
        private TreeView TVObbArchive;
        private ContextMenuStrip CmsObbOptions;
        private ToolStripMenuItem exportarToolStripMenuItem;
        private ToolStripMenuItem importarToolStripMenuItem;
        private TextBox TbxStatus;
        private Label SaveIconButton;
        private ToolStripMenuItem CloseObbMenuItem;
        private ContextMenuStrip CmsMultipleImport;
        private ToolStripMenuItem CmsOptionImportMultiple;
        private ListBox LBReplacedFiles;
        private Label LbReplaced;
        private ToolStripMenuItem CmsOptionExportObb;
    }
}