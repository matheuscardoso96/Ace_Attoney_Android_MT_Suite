using MTTools.Obb.CapcomObb.FileMap;

namespace MTTools.Utils
{
    public static class FileMapIdentifier
    {
        public static FileMapBase GetFilemap(string path) 
        {

            if (path.Contains("gyakusai5en")) 
            {
                return new DualDestiniesEN();
            }
            else if(path.Contains("gyakusai6en"))
            {
                return new SpiritOfJusticeEN();
            }
            else if (path.Contains("daigyakusai2jp"))
            {
                return new DaiGyakutenSaiban();
            }
            else if (path.Contains("daigyakusai"))
            {
                return new DaiGyakutenSaiban();
            }
            else
            {
                return new DualDestiniesEN();
            }
        }
    }
}
