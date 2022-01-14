using System;

namespace BinaryUtils.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAtReading : Attribute
    {
        public bool Ingnore { get; set; }

        public IgnoreAtReading(bool ingnore)
        {
            Ingnore = ingnore;
        }
    }
}
