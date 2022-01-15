using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (IsValidZip(opf.FileName)) {
                    await Task.Run(() => UnzipObbAchive(opf.FileName));
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
                await Task.Run(() => ZipObbArchive(dialog.SelectedPath));
                EnableOrDisableButtons(true);
                MessageBox.Show($"{_zipSucessMsg}");
            }
        }

        private static void UnzipObbAchive(string dir) 
        {
            ZipFile.ExtractToDirectory(dir, Path.GetFileNameWithoutExtension(dir), overwriteFiles:true);
        }

        private static void ZipObbArchive(string path) 
        {
            if (File.Exists($"{path}.obb"))
                File.Delete($"{path}.obb");

            ZipFile.CreateFromDirectory(
                path, $"{path}.obb",
                CompressionLevel.NoCompression, 
                includeBaseDirectory:!path.Split("\\").Last().Contains('.'));
        }

        private static bool IsValidZip(string dir) 
        {
            using BinaryReader reader = new(File.OpenRead(dir));
            return reader.ReadInt16() == 0x4B50;
        }

        private void EnableOrDisableButtons(bool isEnabled) 
        {
            ButtonZip.Enabled = isEnabled;
            ButtonUnzip.Enabled = isEnabled;
        }
    }
}
