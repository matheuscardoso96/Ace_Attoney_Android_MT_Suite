namespace AceAttoney.Android.MTSuite.GUI.Views
{
    public partial class SelectGameView : Form
    {
        public string GameNameAbbreviation { get; private set; } = "AA5";
        public SelectGameView()
        {
            InitializeComponent();
            PopulateCombo();
        }

        private void PopulateCombo() 
        {
            CBGames.Items.AddRange(new string[] {"AA5","AA6","DGS1","DGS2"});
        }

        private void SetGameAbbreviation(string abbreviation) 
        {
            GameNameAbbreviation = abbreviation;
        }

        private void BtnSelectClick(object sender, EventArgs e)
        {
            SetGameAbbreviation(CBGames.Text);
            this.Close();
        }
    }
}
