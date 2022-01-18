using MTTools.Obb.GenericObb;

namespace AceAttoney.Android.MTSuite.GUI.Views
{
    public partial class ZipObb : Form
    {
        private const string _unzipSuccessMsg = "Descompactado com sucesso!";
        private const string _unzipFailMsg = "Este não é um obb de vídeo válido.";
        private const string _zipSucessMsg = "Compactado com sucesso!";
        public ZipObb()
        {
            InitializeComponent();
        }

        private async void UnzipObbClick(object sender, EventArgs e)
        {
            using OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Obb files|*.obb";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                EnableOrDisableButtons(false);
                if (GenericObbTool.IsValidZip(opf.FileName)) {
                    await Task.Run(() => GenericObbTool.UnzipObbAchive(opf.FileName));
                    MessageBox.Show(_unzipSuccessMsg);
                }
                else
                    MessageBox.Show(_unzipFailMsg);

                EnableOrDisableButtons(true);
            }
        }

        private async void ZipObbClick(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                EnableOrDisableButtons(false);
                await Task.Run(() => GenericObbTool.ZipObbArchive(dialog.SelectedPath));
                EnableOrDisableButtons(true);
                MessageBox.Show($"{_zipSucessMsg}");
            }
        }


        private void EnableOrDisableButtons(bool isEnabled) 
        {
            ButtonZip.Enabled = isEnabled;
            ButtonUnzip.Enabled = isEnabled;
        }
    }
}
