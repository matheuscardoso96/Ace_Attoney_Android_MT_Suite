using BinaryUtils.Extensions.Reader;
using BinaryUtils.Extensions.Writer;
using MTTools.Gmd.EntriesType;
using MTTools.Gmd.HeadersType;
using MTTools.Gmd.Helpers;

namespace MTTools.Gmd.GmdType
{
    public class GmdTheGreatAceAttorneyPC
    {
        internal TheGreatAceAttorneyPCHeader? Header { get; set; }
        internal List<TheGreatAceAttorneyPCEntry> Entries { get; set; } = new();
        public string GmdPath { get; set; }
        public ulong[] Bucket { get; set; } = new ulong[256];
        public Dictionary<long, string> Keys { get; set; } = new();
        public List<Section> Sections { get; set; } = new();

        public GmdTheGreatAceAttorneyPC(string gmdPath)
        {
            GmdPath = gmdPath;
            Deserialize(new MemoryStream(File.ReadAllBytes(gmdPath)));
        }

        private void Deserialize(MemoryStream gmd)
        {
            using BinaryReader br = new(gmd);        
            Header = br.ReadPrimitiveProps<TheGreatAceAttorneyPCHeader>();
            Header.SetGmdInternalName(br);

            if (GmdUtils.ValidateVersion(0x10302, (int)Header.Version))
            {
                Entries = GmdUtils.GetEntries<TheGreatAceAttorneyPCEntry>(br, (int)Header.KeyCount);
                Bucket = GmdUtils.GetBucketLong(br, 256);         
                long indexBaseLabels = br.BaseStream.Position;
                Keys = GmdUtils.GetKeys(br,indexBaseLabels, Header.KeyCount);
                Sections = GmdUtils.GetSections(br, (int)Header.SectionAreaSize, isDualDestinies3DS:false);
            }
        }

        public byte[] SerializeGmd()
        {
            MemoryStream newGmd = new();
            using (BinaryWriter bw = new(newGmd))
            {
                bw.BaseStream.Position = 0x28 + Header.GmdStrNameSize + 1;
                GmdUtils.WriteEntries(bw, Entries);
                GmdUtils.WriteBucketLong(bw, Bucket);

                long baseKeysOffset = bw.BaseStream.Position;
                GmdUtils.WriteKeys(bw, Keys);

                Header.KeyAreaSize = (uint)(bw.BaseStream.Position - baseKeysOffset);

                long enderecoBaseSecoes = bw.BaseStream.Position;
                GmdUtils.WriteSections(bw, Sections);

                Header.SectionAreaSize = (uint)(bw.BaseStream.Position - enderecoBaseSecoes);
                bw.BaseStream.Position = 0;
                bw.WritePrimitiveProps(Header);
            }

            return newGmd.ToArray();
        }

        public override string ToString()
        {
            return Header.GmdInternalName;
        }
    }
 
}
