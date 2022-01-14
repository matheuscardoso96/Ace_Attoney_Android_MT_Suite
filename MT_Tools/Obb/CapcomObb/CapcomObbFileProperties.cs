using BinaryUtils.Attributes;

namespace MTTools.Obb.CapcomObb
{
    public class CapcomObbFileProperties
    {
        public int PathJamCrc32 { get; set; }
        public int Offset { get; set; }
        public int Size { get; set; }
        public int ContentJamCrc32 { get; set; }
        [IgnoreAtWriting(true)]
        [IgnoreAtReading(true)]
        public string? FilePath { get; set; } = "";
        [IgnoreAtWriting(true)]
        [IgnoreAtReading(true)]
        public bool WasModified { get; set; } = false;
        [IgnoreAtWriting(true)]
        [IgnoreAtReading(true)]
        public int Index { get; set; } = 0;

        public CapcomObbFileProperties()
        {

        }
    }
}
