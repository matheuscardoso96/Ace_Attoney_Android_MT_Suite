namespace MTTools.Gmd.HeadersType
{
    internal class TheGreatAceAttorneyPCHeader : HeaderBase
    {

        public TheGreatAceAttorneyPCHeader() {   }


        public override TheGreatAceAttorneyPCHeader CreateHeader() 
        {
            return new TheGreatAceAttorneyPCHeader()
            {
                Magic = 0x444D47,
                Version = 0x10302,
                LanguageId = 0x1,

            };
        }

    }
 
}
