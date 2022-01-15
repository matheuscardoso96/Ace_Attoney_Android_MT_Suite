using MTTools.Obb.CapcomObb;
using MTTools.Utils;
using System.Data;

namespace AceAttoney.Android.MTSuite.GUI.Views
{
    public partial class CapcomObbView : Form
    {
        private CapcomObbArchive? _obbArchive;
        private TreeNode? _selectedNode;

        public CapcomObbView()
        {
            InitializeComponent();
            SaveIconButton.Enabled = false;
            CloseObbMenuItem.Enabled = false;
        }

        private async void OpenObbClick(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Obb files|*.obb";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenObbMenuItem.Enabled = false;
                TbxStatus.Text = "Carregando informações...";
                await Task.Run(() => LoadObb(openFileDialog.FileName));
                ArgumentNullException.ThrowIfNull(_obbArchive);
                PopulateTreeView(TVObbArchive, _obbArchive);
                TbxStatus.Text = "Obb carregado.";
            }

            CloseObbMenuItem.Enabled = true;
        }

        private void CloseObbClick(object sender, EventArgs e)
        {
            CloseObb();
        }

        private void TVObbArchive_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedNode = e.Node;
        }

        private void TVObbArchive_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TVObbArchive.SelectedNode = e.Node;
                if (e.Node.Name.Contains('.') && !e.Node.Name.Contains("capcom"))
                    CmsObbOptions.Show(Cursor.Position);
                else
                    CmsMultipleImport.Show(Cursor.Position);

            }

        }

        private async void CmsObbOptionExport(object sender, EventArgs e)
        {
            Progress<CapcomObbFileProperties>? progress = new(fp => TbxStatus.Text = fp.FilePath);
            await ExportFileFromObb(progress);

            ArgumentNullException.ThrowIfNull(_selectedNode);
            _selectedNode.ForeColor = Color.Yellow;
            MessageBox.Show($"Exportado: {Path.GetFileName(_selectedNode?.FullPath)}");
        }

        private async void CmsObbOptionImport(object sender, EventArgs e)
        {
            ArgumentNullException.ThrowIfNull(_obbArchive);
            ArgumentNullException.ThrowIfNull(_selectedNode);

            using OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await ImportFileToObb(dialog.FileName, _selectedNode);
                SaveIconButton.Enabled = true;
                CloseObbMenuItem.Enabled = false;
                MessageBox.Show("Arquivo substituído.");
                CloseObbMenuItem.Enabled = true;
            }
        }

        private async void CmsOptionImportMultipleClick(object sender, EventArgs e)
        {
            ArgumentNullException.ThrowIfNull(_obbArchive);
            ArgumentNullException.ThrowIfNull(_selectedNode);

            using FolderBrowserDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await ImportMultipleFilesToObb(dialog.SelectedPath, _selectedNode);
                SaveIconButton.Enabled = true;
                CloseObbMenuItem.Enabled = false;
                MessageBox.Show("Arquivos substituídos.");
                CloseObbMenuItem.Enabled = true;
            }

            
        }

        private async void SaveIconClick(object sender, EventArgs e)
        {
            SaveIconButton.Enabled = false;
            CloseObbMenuItem.Enabled = false;
            Progress<string>? progress = new(fp => TbxStatus.Text = fp);
            await SaveNewObb(progress);
            LBReplacedFiles.DataSource = null;
            LBReplacedFiles.Refresh();
            MessageBox.Show("Salvo com sucesso");
            CloseObbMenuItem.Enabled = true;

        }

        private void PopulateTreeView(TreeView tree, CapcomObbArchive obbArchive)
        {
            ArgumentNullException.ThrowIfNull(_obbArchive);
            foreach (var prop in obbArchive.FilesProperties)
            {
                TreeNodeCollection? nodes = tree.Nodes;

                ArgumentNullException.ThrowIfNull(prop.Value.FilePath);
                foreach (string path_part in prop.Value.FilePath.Split('\\'))
                {
                    if (!nodes.ContainsKey(path_part))
                        nodes.Add(path_part, path_part);


                    nodes = nodes[path_part].Nodes;
                }
            }
        }

        private void LoadObb(string path)
        {
            _obbArchive = new CapcomObbArchive(path, FileMapIdentifier.GetFilemap(path));
            _obbArchive.ReadObb();
        }

        private void CloseObb()
        {
            TVObbArchive.Nodes.Clear();
            TVObbArchive.Update();
            _selectedNode = null;
            _obbArchive = null;
            OpenObbMenuItem.Enabled = true;
            CloseObbMenuItem.Enabled = false;
            SaveIconButton.Enabled = false;
        }

        private async Task ExportFileFromObb(IProgress<CapcomObbFileProperties> progress)
        {
            ArgumentNullException.ThrowIfNull(_obbArchive);
            ArgumentNullException.ThrowIfNull(_selectedNode);

            if (_selectedNode.FullPath.Split("\\").Last().Contains('.'))
                await Task.Run(() => _obbArchive.ExportFile(_obbArchive.FilesProperties[_selectedNode.FullPath]));
            else
                await Task.Run(() => { foreach (var fp in _obbArchive.ExportAllFiles(_selectedNode.FullPath)) progress.Report(fp); });
        }
        private async Task ImportFileToObb(string path, TreeNode selectedNode) 
        {
            ArgumentNullException.ThrowIfNull(_obbArchive);
            await Task.Run(() => _obbArchive.ImportFile(path, _obbArchive.FilesProperties[selectedNode.FullPath]));
        }

        private async Task ImportMultipleFilesToObb(string path, TreeNode selectedNode)
        {
            ArgumentNullException.ThrowIfNull(_obbArchive);
            await Task.Run(() => _obbArchive.ImportMultipleFiles(path, selectedNode.FullPath));
            LBReplacedFiles.DataSource = _obbArchive.FilesProperties
                .Where(f => f.Value.WasModified)
                .Select(f => Path.GetFileName(f.Value.FilePath)).ToList();
        }

        private async Task SaveNewObb(IProgress<string> progress)
        {
            ArgumentNullException.ThrowIfNull(_obbArchive);
            ArgumentNullException.ThrowIfNull(_obbArchive.Header);

            await Task.Run(() =>
            {
                string total = _obbArchive.Header.FileCount.ToString();
                foreach (var count in _obbArchive.SaveObbArchive())
                {
                    progress.Report($"Salvando obb... {count}\\{total}");
                }
            });

            progress.Report($"Obb salvo com sucesso!");

        }

 
    }
}
