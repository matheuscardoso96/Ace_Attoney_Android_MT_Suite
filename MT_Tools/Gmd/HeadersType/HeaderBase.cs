using BinaryUtils.Attributes;
using System.Text;

namespace MTTools.Gmd.HeadersType
{
    internal abstract class HeaderBase
    {
        public uint Magic { get; set; }
        public uint Version { get; set; }
        public uint LanguageId { get; set; }
        public ulong Hash { get; set; }
        public uint KeyCount { get; set; }
        public uint SectionCount { get; set; }
        public uint KeyAreaSize { get; set; }
        public uint SectionAreaSize { get; set; }
        public uint GmdStrNameSize { get; set; }
        [IgnoreAtReading(true)]
        public string GmdInternalName { get; set; }

        public void SetGmdInternalName(BinaryReader reader)
        {
            GmdInternalName = Encoding.ASCII.GetString(reader.ReadBytes((int)GmdStrNameSize + 1)).TrimEnd('\0');
        }

        public abstract HeaderBase CreateHeader();
    }
}
