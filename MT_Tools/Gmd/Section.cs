using MTTools.Utils.Helpers;
using System.Text;

namespace MTTools.Gmd
{
    public class Section 
    {
        public int Id { get; set; }
        public string Raw { get; set; } = "";
        public List<string> Dialogs { get; set; }
        public Section(int id, string raw)
        {
            Id = id;
            Dialogs = new List<string>();
            Raw = raw;
            GetDialogs(raw);

        }

        private void GetDialogs(string raw) 
        {
           

            
            
        }
    }
 
}
