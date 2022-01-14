using System;

namespace BinaryUtils.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAtWriting : Attribute
    {
        public bool Ingnore { get; set; }

        public IgnoreAtWriting(bool ingnore)
        {
            Ingnore = ingnore;
        }
    }
}
