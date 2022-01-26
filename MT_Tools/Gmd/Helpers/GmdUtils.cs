using BinaryUtils.Extensions.Reader;
using BinaryUtils.Extensions.Writer;
using MTTools.Utils.Helpers;
using System.Text;

namespace MTTools.Gmd.Helpers
{
    public static class GmdUtils 
    {
        public static bool ValidateVersion(int expectedVersion, int version) 
        {
            if (version != expectedVersion)
            {
                throw new Exception($"Wrong version! Expected {expectedVersion} but {version}");
            }

            return true;
        }
        public static List<T> GetEntries<T>(BinaryReader br, int count) where T : class
        {
            List<T> entries = new();
            for (int i = 0; i < count; i++)
            {
                entries.Add(br.ReadPrimitiveProps<T>());
            }

            return entries;
        }

        public static void WriteEntries<T>(BinaryWriter writer, List<T> entries) where T : class
        {
            foreach (var entry in entries)
                writer.WritePrimitiveProps(entry);
        }

        public static ulong[] GetBucketLong(BinaryReader br, long size)
        {
            ulong[] bucket = new ulong[size];
            
            for (int i = 0; i < size; i++)
            {
                bucket[i] = br.ReadUInt64();
            }

            return bucket;
        }

        public static void WriteBucketLong(BinaryWriter writer, ulong[] bucket)
        {
            foreach (long item in bucket)
                writer.Write(item);
        }

        public static Dictionary<long, string> GetKeys(BinaryReader br, long baseOffeset, long count)
        {
            var keys = new Dictionary<long, string>();

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new();
                long chaveLabel = br.BaseStream.Position - baseOffeset;
                string letra = Encoding.ASCII.GetString(br.ReadBytes(1));
                while (letra != "\0")
                {
                    sb.Append(letra);
                    letra = Encoding.ASCII.GetString(br.ReadBytes(1));
                }

                keys.Add(chaveLabel, sb.ToString());
            }

            return keys;
        }

        public static void WriteKeys(BinaryWriter writer, Dictionary<long, string> keys)
        {
            foreach (KeyValuePair<long, string> key in keys)
                writer.Write(Encoding.ASCII.GetBytes($"{key.Value}\0"));
        }

        public static List<Section> GetSections(BinaryReader br, int sectionSize , bool isDualDestinies3DS)
        {
            var sections = new List<Section>();
            var sectionArea = br.ReadBytes(sectionSize).AsSpan();

            if (isDualDestinies3DS)
                sectionArea = XorHelper.XorDualDestinies(sectionArea.ToArray()).AsSpan();

            for (int i = 0; i < sectionArea.Length;)
            {
                int start = i;
                byte valor = sectionArea[i];
                while (valor != 0)
                {
                    valor = sectionArea[i];
                    i++;
                }

                sections.Add(new Section(i, Encoding.UTF8.GetString(sectionArea[start..i]).TrimEnd('\0')));
            }

            return sections;
        }

        public static void WriteSections(BinaryWriter writer, List<Section> sections) 
        {
            foreach (var section in sections)
                writer.Write(Encoding.UTF8.GetBytes($"{section.Raw}\0"));
        }

        public static string GetTag(ReadOnlySpan<char> text, int index) 
        {
            int count = index;
            StringBuilder tag = new();

            while (text[count] != '>')
            {
                tag.Append(text[count]);
                count++;
            }
            
            tag.Append(text[count]);

            return tag.ToString();
        }

        public static string ReadDialog(ReadOnlySpan<char> text, int index)
        {
            int count = index;
            StringBuilder dialog = new();
            const char tagStart = '<';
            const string page = "<PAGE>";
            
            while (true)
            {
                if (text[count] == tagStart)
                {
                    string tag = GetTag(text, count);
                    dialog.Append(tag);
                    count+= tag.Length;

                    if (tag == page)
                        break;
                    
                }
                else
                {
                    dialog.Append(text[count]);
                    count++;
                }
            }

            return dialog.ToString();
        }

    }
 
}
