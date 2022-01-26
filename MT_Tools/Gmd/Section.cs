using MTTools.Gmd.Helpers;

namespace MTTools.Gmd
{
    public class Section 
    {
        public int Id { get; set; }
        public string Raw { get; set; } = "";
        public List<string> Dialogs { get; set; } = new List<string>();
        public Section(int id, string raw)
        {
            Id = id;
            Dialogs = new List<string>();
            Raw = raw;
            GetDialogs(raw);

        }

        private void GetDialogs(string raw) 
        {
            ReadOnlySpan<char> sec = raw.AsSpan();
            const char tagStart = '<';
            for (int i = 0; i < sec.Length;)
            {
                if (sec[i] == tagStart)
                {
                  string tag =  GmdUtils.GetTag(sec, i);
                    i += tag.Length;

                    if (IsDialog(tag)) 
                    {
                        string dlg = GmdUtils.ReadDialog(sec, i);
                        Raw = raw.Replace(dlg, $"<DLG:{Dialogs.Count}>");
                        Dialogs.Add(dlg);
                        i += dlg.Length;
                    }
                        
                }
                else
                    i++;
            }
        }

        public void ReplaceDialog(int index, string dialog) 
        {
            Raw = Raw.Replace($"<DLG:{index}>", dialog);
        }

        private static bool IsDialog(string tag) 
        {
            if (
                tag == "<E041>"
                || tag == "<E103>"
                || tag == "<E260>"
                || tag == "<E195>"
                || tag == "<E205>"
                ) 
            {
                return true;
            }
            return false;
        }
    }

}
