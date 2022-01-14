using BinaryUtils.Attributes;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace BinaryUtils.Extensions.Reader
{
    public static class ReaderExtensions
    {
        /// <summary>
        ///Creates an instance of a class with the default constructor and read values to public primitive type properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T ReadPrimitiveProps<T>(this BinaryReader reader) where T : class 
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            foreach (var propInfo in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                IgnoreAtReading ignoreAtReading = (IgnoreAtReading)propInfo.GetCustomAttribute(typeof(IgnoreAtReading));
                if (ignoreAtReading is not null && ignoreAtReading.Ingnore)
                    continue;

                if (propInfo.PropertyType.IsPrimitive 
                    || propInfo.PropertyType.Name.ToLower().Contains("string")) 
                {                  
                    ReadPrimitiveType(propInfo, obj, reader);
                }
            }

            return obj;
        }

        private static void ReadPrimitiveType<C>(PropertyInfo propInfo, C obj, BinaryReader reader) where C : class
        {
            var typeName = propInfo.PropertyType.Name;

            switch (typeName.ToLower())
            {
                case "char":
                    propInfo.SetValue(obj, reader.ReadChar());
                    break;
                case "string":
                    TextProperties textProperties = (TextProperties)propInfo.GetCustomAttribute(typeof(TextProperties));
                    propInfo.SetValue(obj, ReadString(reader, textProperties));
                    break;
                case "boolean":
                    propInfo.SetValue(obj, reader.ReadBoolean());
                    break;
                case "sbyte":
                    propInfo.SetValue(obj, reader.ReadSByte());
                    break;
                case "byte":
                    propInfo.SetValue(obj, reader.ReadByte());
                    break;
                case "uint16":
                    propInfo.SetValue(obj, reader.ReadUInt16());
                    break;
                case "int16":
                    propInfo.SetValue(obj, reader.ReadInt16());
                    break;
                case "uint32":
                    propInfo.SetValue(obj, reader.ReadUInt32());
                    break;
                case "int32":
                    propInfo.SetValue(obj, reader.ReadInt32());
                    break;
                case "uint64":
                    propInfo.SetValue(obj, reader.ReadUInt64());
                    break;
                case "int64":
                    propInfo.SetValue(obj, reader.ReadInt64());
                    break;
                default:
                    break;
            }
        }


        private static string ReadString(BinaryReader br,TextProperties textProperties = null) 
        {
            if (textProperties is null) textProperties = new(TextEnconding.ASCII);
            
            byte[] text = br.ReadBytes(textProperties.Length);

            return textProperties.Encoding switch
            {
                TextEnconding.ASCII => Encoding.ASCII.GetString(text),
                TextEnconding.UTF8 => Encoding.UTF8.GetString(text),
                TextEnconding.UTF32 => Encoding.UTF32.GetString(text),
                TextEnconding.UNICODE => Encoding.Unicode.GetString(text),
                _ => Encoding.ASCII.GetString(text),
            };
        }
    }
}
