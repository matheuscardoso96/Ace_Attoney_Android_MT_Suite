using BinaryUtils.Extensions.Reader;
using BinaryUtils.Extensions.Writer;
using MTTols.Utils;
using MTTools.Obb.CapcomObb.FileMap;
using System.Text;

namespace MTTools.Obb.CapcomObb
{
    public class CapcomObbArchive
    {
        public FileInfo ObbInfo { get; private set; }
        public string ExportPath { get; private set; }
        public CapcomObbHeader? Header { get; private set; }
        public Dictionary<string, CapcomObbFileProperties> FilesProperties { get; private set; }
        private BinaryReader _reader;
        private readonly FileMapBase _fileMap;

        public CapcomObbArchive(string path, FileMapBase fileMap)
        {
            ObbInfo = new FileInfo(path);
            ExportPath = Path.GetFileNameWithoutExtension(path);
            _fileMap = fileMap;
            FilesProperties = new Dictionary<string, CapcomObbFileProperties>();
            _reader = new BinaryReader(new MemoryStream());
            if (!Directory.Exists($"_temp\\{Path.GetFileNameWithoutExtension(ObbInfo.Name)}"))
            {
                Directory.CreateDirectory($"_temp\\{Path.GetFileNameWithoutExtension(ObbInfo.Name)}");
            }
        }

        public void ReadObb()
        {
            _reader = new(File.OpenRead(ObbInfo.FullName));
            Header = _reader.ReadPrimitiveProps<CapcomObbHeader>();
            FilesProperties = ReadObbFilePropertiesAsync();
        }

        private Dictionary<string, CapcomObbFileProperties> ReadObbFilePropertiesAsync()
        {
            var list = new Dictionary<string, CapcomObbFileProperties>();
            for (int count = 0; count < Header?.FileCount; count++)
            {
                var fp = _reader.ReadPrimitiveProps<CapcomObbFileProperties>();
                string path = $"{ExportPath}\\{_fileMap.GetFileName(fp.PathJamCrc32)}";

                if (path.Contains("_notInTheList"))
                    path += GetExtension(_reader, fp.Offset);

                fp.FilePath = path;
                fp.Index = count;
                list.Add(path, fp);
            }

            return list.OrderBy(x => x.Value.FilePath).ToDictionary(x => x.Key, x => x.Value);
        }


        public void ExportFile(CapcomObbFileProperties fileProperty)
        {
            _reader.BaseStream.Position = fileProperty.Offset;
            string? directory = Path.GetDirectoryName(fileProperty.FilePath);

            ArgumentNullException.ThrowIfNull(directory);
            if (Directory.Exists(directory))
            {
                _ = Directory.CreateDirectory(directory);
            }

            ArgumentNullException.ThrowIfNull(fileProperty.FilePath);
            File.WriteAllBytes(fileProperty.FilePath, _reader.ReadBytes(fileProperty.Size));
        }

        public IEnumerable<CapcomObbFileProperties> ExportAllFiles(string parant)
        {

            foreach (var fp in FilesProperties)
            {
                if (fp.Value.FilePath != null && fp.Value.FilePath.Contains(parant))
                {
                    ExportFile(fp.Value);
                    yield return fp.Value;
                }
            }
        }

        public void ImportFile(string path, CapcomObbFileProperties fileProperties)
        {
            string? filePath = fileProperties.FilePath;
            ArgumentNullException.ThrowIfNull(filePath);
            string? directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists($"_temp\\{directory}"))
            {
                Directory.CreateDirectory($"_temp\\{directory}");
            }

            
            FileInfo fileF = new (filePath);
            File.Copy(path, $"_temp\\{filePath}", true);
            
            fileProperties.WasModified = true;
            fileProperties.ContentJamCrc32 = (int)JamCrcCalculator.GetJamCrc32FromFile(fileF);
            fileProperties.Size = (int)fileF.Length;
        }

        public void ImportMultipleFiles(string path, string virtualPath)
        {
            var properties = FilesProperties.Where(kp => kp.Value.FilePath is not null 
            && kp.Value.FilePath.Contains(virtualPath)).ToList();

            var filesToImport = Directory.GetFiles(path);

            foreach (var filePath in filesToImport)
            {
                string justPath = "main" + filePath.Split(new string[]{"main"}, StringSplitOptions.RemoveEmptyEntries)[1];
                ImportFile(justPath, FilesProperties[justPath]);
            }

        }

        public IEnumerable<int> SaveObbArchive()
        {
            string obbName = Path.GetFileNameWithoutExtension(ObbInfo.FullName);
            using (BinaryWriter writer = new(File.Open($"{obbName}_new.obb", FileMode.Create)))
            {
                int endOfEntryArea = FilesProperties.Count * 16 + 16;
                writer.BaseStream.Position = endOfEntryArea;
                var orderedProperties = FilesProperties.OrderBy(x => x.Value.Index).ToDictionary(x => x.Key, x => x.Value);

                foreach (var fp in orderedProperties)
                {
                    fp.Value.Offset = (int)writer.BaseStream.Position;

                    if (fp.Value.WasModified)
                    {
                        foreach (var buffer in YieldReadFromExternalFile($"_temp\\{fp.Value.FilePath}"))
                            writer.Write(buffer);   
                    }
                    else
                    {

                        foreach (var buffer in YieldReadFromInternalFile(_reader, fp.Value.Size, fp.Value.Offset))
                            writer.Write(buffer);
                    }

                    yield return fp.Value.Index;
                }

                writer.BaseStream.Position = 16;

                foreach (var fp in orderedProperties)
                {
                    writer.WritePrimitiveProps(fp.Value);
                }

                writer.BaseStream.Position = 0;
                writer.WritePrimitiveProps(Header);
                writer.Close();
            }

            Header?.CalculateEntrySectionJamCrc32($"{obbName}_new.obb");
        }

        private static IEnumerable<byte[]> YieldReadFromExternalFile(string path) 
        {
            FileInfo fI = new(path);

            using BinaryReader reader = new(File.OpenRead(path));
            int totalToRead = (int)fI.Length;
           
            while (totalToRead > 0)
            {
                if (totalToRead < 4096)
                    yield return reader.ReadBytes(totalToRead);
                else
                    yield return reader.ReadBytes(4096);

                totalToRead -= 4096;
            }

            reader.Close();
        }

        private static IEnumerable<byte[]> YieldReadFromInternalFile(BinaryReader reader, int size ,long position)
        {
            reader.BaseStream.Position = position;
            int totalToRead = size;
            
            while (totalToRead > 0)
            {
                if (totalToRead < 4096)
                    yield return reader.ReadBytes(totalToRead);
                else
                    yield return reader.ReadBytes(4096);

                totalToRead -= 4096;
            }
        }


        private static string GetExtension(BinaryReader br, long position)
        {
            var positionBackup = br.BaseStream.Position;
            br.BaseStream.Position = position;
            string ext = Encoding.ASCII.GetString(br.ReadBytes(3));
            br.BaseStream.Position = positionBackup;
            return $".{ext.ToLower()}";
        }
    }
}
