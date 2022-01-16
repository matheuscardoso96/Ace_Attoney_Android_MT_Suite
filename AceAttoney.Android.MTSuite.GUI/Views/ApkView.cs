using MTTools.Apk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AceAttoney.Android.MTSuite.GUI.Views
{
    public partial class ApkView : Form
    {
        public ApkView()
        {
            InitializeComponent();
        }

        private async void TMSIDecompApkClick(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Arquivos apk|*.apk";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TMSICompApk.Enabled = false;
                TMSIDecompApk.Enabled = false;
                TbxStatus.Text = "Exportando apk...";
                await Task.Run(() => DecompApk(openFileDialog.FileName,"dgs1"));
                TMSICompApk.Enabled = true;
                TMSIDecompApk.Enabled = true;
                TbxStatus.Text = "Apk exportado com sucesso.";
            }

        }

        private static void DecompApk(string apkPath, string gameName) 
        {
            ApkTool.DecompileApk(apkPath, gameName);
        }
    }
}
