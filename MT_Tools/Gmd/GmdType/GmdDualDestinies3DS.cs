using BinaryUtils.Extensions.Reader;
using BinaryUtils.Extensions.Writer;
using MTTools.Gmd.EntriesType;
using MTTools.Gmd.HeadersType;
using MTTools.Gmd.Helpers;
using System.Text;

namespace MTTools.Gmd.GmdType
{
    public class GmdDualDestinies3DS 
    {
        internal DualDesties3DSHeader? Header { get; set; }
        internal List<DualDestiniesEntry3DS> Entries { get; set; } = new();
        public string? GmdPath { get; set; }
        public Dictionary<long, string> Keys { get; set; } = new();
        public List<Section> Sections { get; set; } = new();

        public GmdDualDestinies3DS(string gmdPath)
        {
            Deserialize(new MemoryStream(File.ReadAllBytes(gmdPath)));
        }

        private void Deserialize(MemoryStream gmd)
        {
            using BinaryReader br = new(gmd);
            Header = br.ReadPrimitiveProps<DualDesties3DSHeader>();
            Header.SetGmdInternalName(br);


            if (GmdUtils.ValidateVersion(0x10201, (int)Header.Version))
            {
                Entries = GmdUtils.GetEntries<DualDestiniesEntry3DS>(br, (int)Header.KeyCount);
                long indexBaseLabels = br.BaseStream.Position;
                Keys = GmdUtils.GetKeys(br, indexBaseLabels, Header.KeyCount);
                Sections = GmdUtils.GetSections(br, (int)Header.SectionAreaSize, isDualDestinies3DS: true);
            }
        }

        public byte[] SerializeGmd()
        {
            MemoryStream newGmd = new();
            using (BinaryWriter bw = new(newGmd))
            {
                bw.BaseStream.Position = 0x28 + Header.GmdStrNameSize + 1;
                GmdUtils.WriteEntries(bw, Entries);
               
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
