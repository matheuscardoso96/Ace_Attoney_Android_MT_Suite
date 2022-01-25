using MTTools.Gmd.GmdType;

namespace AceAttoney.Android.MTSuite.GUI.Views
{
    public partial class GmdView : Form
    {
        public GmdView()
        {
            InitializeComponent();
        }

        private void OpenGmdClick(object sender, EventArgs e)
        {
            var gmd = new GmdDualDestinies3DS(@"C:\Users\djmat\Desktop\DGS_Android\_sce04_c200_0002_eng.gmd");
        }
    }
}
