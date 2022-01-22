using MTTools.Apk;
using System.Data;

namespace AceAttoney.Android.MTSuite.GUI.Views
{
    public partial class ApkView : Form
    {
        private readonly ApkTool _apkTool;
        private readonly string _workDirectory;
        public ApkView(string workDirectory)
        {
            InitializeComponent();
            _apkTool= new ApkTool(workDirectory);
            _workDirectory = workDirectory;
            GetDecompiledApks();
        }

        private async void TMSIDecompApkClick(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Arquivos apk|*.apk";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetEnableStatus(false);
                TbxStatus.Text = "Exportando apk...";
                await Task.Run(() => DecompileApk(openFileDialog.FileName, SelectAGame()));
                SetEnableStatus(true);
                TbxStatus.Text = "Apk exportado com sucesso.";
            }

            GetDecompiledApks();
        }

        private async void TMSICompileApkClick(object sender, EventArgs e)
        {
            if (LBDecApks.SelectedItem is not null) 
            {
                SetEnableStatus(false);
                var apkName = LBDecApks.SelectedItem.ToString();
                TbxStatus.Text = $"Compilando {apkName}...";
                await Task.Run(() => CompileApk($"{_workDirectory}\\{_apkExportPath}", apkName));
                SetEnableStatus(true);
                MessageBox.Show($"{apkName} compilado com sucesso!");
                TbxStatus.Text = "";
            }
                

        }

        private void LBDecApks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LBDecApks.SelectedIndex != -1)
                {
                    CMSCompile.Show(Cursor.Position);
                }

            }
        }

        private async void TMSIMovieObbSizeFixClick(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "path obb file|*.obb";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetEnableStatus(false);
                string? gameName = LBDecApks.SelectedItem.ToString();
                ArgumentNullException.ThrowIfNull(gameName);
                await Task.Run(() => MovieObbSizeFix.FixSize(gameName, openFileDialog.FileName));
                SetEnableStatus(true);
                TbxStatus.Text = "Tamanho corrigido!";
            }
        }

        private static string SelectAGame() 
        {
            using SelectGameView selectGame = new();
            if (selectGame.ShowDialog() == DialogResult.Cancel)
            {
              return selectGame.GameNameAbbreviation;
            }

            return "AA5";
        }

        private void DecompileApk(string apkPath, string? gameName) 
        {
            ArgumentNullException.ThrowIfNull(gameName);
            _apkTool.DecompileApk(apkPath, gameName);
        }

        public void CompileApk(string apkExportedPath, string? apkName) 
        {
            ArgumentNullException.ThrowIfNull(apkName);
            _apkTool.CompileApk($"{apkExportedPath}{apkName}", $"{apkName}");
        }

        private void SetEnableStatus(bool isEnable) 
        {
            TMSIDecompApk.Enabled = isEnable;
        }

        private const string _apkExportPath = "APK\\Exported\\";

        private void GetDecompiledApks() 
        {
            LBDecApks.Items.Clear();
            if (Directory.Exists($"{_workDirectory}\\{_apkExportPath}"))
            {
                var paths = Directory.GetDirectories($"{_workDirectory}\\{_apkExportPath}").Select(d => d.Split('\\').Last()).ToList();
                paths.ForEach(x => LBDecApks.Items.Add(x));
                LBDecApks.Refresh();

            }
            
        }

    }
}
