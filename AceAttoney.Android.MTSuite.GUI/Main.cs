using AceAttoney.Android.MTSuite.GUI.Views;

namespace AceAttoney.Android.MTSuite.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void OpenCapcomObbTool(object sender, EventArgs e)
        {
            CapcomObbView capcomObbView = new();
            capcomObbView.ShowDialog();
        }

        private void OpenMovieObbToolClick(object sender, EventArgs e)
        {
            ZipObb zipObb = new();
            zipObb.ShowDialog();
        }

        private void MSIToolApkClick(object sender, EventArgs e)
        {
            ApkView apkView = new();
            apkView.ShowDialog();
        }
    }
}
