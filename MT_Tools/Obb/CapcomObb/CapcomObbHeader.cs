using MTTols.Utils;

namespace MTTools.Obb.CapcomObb
{
    public class CapcomObbHeader
    {
        public int Magic { get; set; }
        public int Version { get; set; }
        public int FileCount { get; set; }
        public int EntrySectionJamCrc32 { get; set; }
        public CapcomObbHeader()
        {

        }

        public void CalculateEntrySectionJamCrc32(string path) 
        {
            byte[] entrySection;
            using BinaryReader reader = new(File.OpenRead(path));
            {
                reader.BaseStream.Position = 16;
                entrySection = reader.ReadBytes(FileCount * 16);
                reader.Close();
            }
            
            using BinaryWriter writer = new(File.OpenWrite(path));
            EntrySectionJamCrc32 = (int)JamCrcCalculator.GetJamCrc32(entrySection);
            writer.BaseStream.Position = 12;
        }
    }
}
