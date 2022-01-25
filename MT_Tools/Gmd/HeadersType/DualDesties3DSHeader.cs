namespace MTTools.Gmd.HeadersType
{
    internal class DualDesties3DSHeader : HeaderBase
    {

        public DualDesties3DSHeader() {   }

        public override TheGreatAceAttorneyPCHeader CreateHeader() 
        {
            return new TheGreatAceAttorneyPCHeader()
            {
                Magic = 0x444D47,
                Version = 0x10201,
                LanguageId = 0x1,

            };
        }

    }
 
}
