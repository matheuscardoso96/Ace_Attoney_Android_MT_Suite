using MTTols.Utils;

namespace MTTools.Gmd.EntriesType
{
    internal class TheGreatAceAttorneyPCEntry : BaseEntry
    {
        public int KeyConcat3xHash { get; set; }
        public uint Padding { get; set; }
        public long KeyAddress { get; set; }
        public long BucketIndex { get; set; }

        public TheGreatAceAttorneyPCEntry() {    }
        public TheGreatAceAttorneyPCEntry(long keyAddress, uint sectionIndex, string key, long bucketIndex):base(sectionIndex, key)
        {
            KeyAddress = keyAddress;
            KeyConcat3xHash = (int)CRC32.ComputeHash($"{key}{key}{key}");
            Padding = 0xCDCDCDCD;
            BucketIndex = bucketIndex;
        }

    }
 
}
