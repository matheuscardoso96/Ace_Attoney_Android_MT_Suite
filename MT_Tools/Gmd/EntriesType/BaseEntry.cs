using MTTols.Utils;

namespace MTTools.Gmd.EntriesType
{
    internal class BaseEntry
    {
        public uint SectionIndex { get; set; }
        public int KeyConcat2xHash { get; set; }

        public BaseEntry()
        {

        }

        public BaseEntry(uint sectionIndex, string key)
        {
            SectionIndex = sectionIndex;
            KeyConcat2xHash = (int)CRC32.ComputeHash($"{key}{key}");
        }
    }
}
