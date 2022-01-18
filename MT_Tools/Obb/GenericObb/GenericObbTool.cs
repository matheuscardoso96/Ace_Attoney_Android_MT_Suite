using System.IO.Compression;

namespace MTTools.Obb.GenericObb
{
    public static class GenericObbTool
    {
        public static void UnzipObbAchive(string dir)
        {
            ZipFile.ExtractToDirectory(dir, Path.GetFileNameWithoutExtension(dir), overwriteFiles: true);
        }

        public static void ZipObbArchive(string path)
        {
            if (File.Exists($"{path}.obb"))
                File.Delete($"{path}.obb");

            ZipFile.CreateFromDirectory(
                path, $"{path}.obb",
                CompressionLevel.NoCompression,
                includeBaseDirectory: !path.Split("\\").Last().Contains('.'));
        }

        public static bool IsValidZip(string dir)
        {
            using BinaryReader reader = new(File.OpenRead(dir));
            return reader.ReadInt16() == 0x4B50;
        }
    }
}
