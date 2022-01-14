using Ace_Attoney_Android_MT_Suite.Views;
using MTTools.Obb.CapcomObb;
using MTTools.Obb.CapcomObb.FileMap;

namespace Ace_Attoney_Android_MT_Suite
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
    }
}
