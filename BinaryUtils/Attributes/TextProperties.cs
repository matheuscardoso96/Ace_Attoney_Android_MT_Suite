using System;

namespace BinaryUtils.Attributes
{
    public class TextProperties : Attribute
    {
        public int Length { get; set; }
        public TextEnconding Encoding { get; set; }

        public TextProperties(TextEnconding encoding, int length = 1)
        {
            Length = length;
            Encoding = encoding;
        }
    }

    public enum TextEnconding
    {
       ASCII,
       UTF8,
       UTF32,
       UNICODE
    }
}
