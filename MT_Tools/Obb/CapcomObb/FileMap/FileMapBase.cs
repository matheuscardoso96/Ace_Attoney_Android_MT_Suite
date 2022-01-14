using MTTols.Utils;
using System.Text;

namespace MTTools.Obb.CapcomObb.FileMap
{
    public abstract class FileMapBase
    {
        public Dictionary<uint, string> DiretoriosObb { get; set; }

        public FileMapBase()
        {
            DiretoriosObb = new Dictionary<uint, string>();
        }

        public void Initialize(string[] paths)
        {
            foreach (var path in paths)
                DiretoriosObb.Add(JamCrcCalculator.GetJamCrc32(Encoding.ASCII.GetBytes(path)), path);
        }

        public string? GetFileName(int jamCrc32) 
        {
            DiretoriosObb.TryGetValue((uint)jamCrc32, out string? path);
            if (path is null)
            {
                return $"_notInTheList\\0x{jamCrc32:X}";
            }
            return path;
        }
    }
}
