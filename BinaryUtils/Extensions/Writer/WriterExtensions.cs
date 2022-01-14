using BinaryUtils.Attributes;
using System.IO;
using System.Reflection;
using System.Text;

namespace BinaryUtils.Extensions.Writer
{
    public static class WriterExtensions
    {
        /// <summary>
        ///Write primitive types of a class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static void WritePrimitiveProps<T>(this BinaryWriter writer, T obj) where T : class
        {

            foreach (var propInfo in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                IgnoreAtWriting ignoreAtWriting = (IgnoreAtWriting)propInfo.GetCustomAttribute(typeof(IgnoreAtWriting));
                if (ignoreAtWriting is not null && ignoreAtWriting.Ingnore)
                    continue;

                if (propInfo.PropertyType.IsPrimitive 
                    || propInfo.PropertyType.Name.ToLower().Contains("string"))
                {
                    WritePrimitiveType(propInfo, obj, writer);
                }
            }

        }

        private static void WritePrimitiveType<C>(PropertyInfo propInfo, C obj, BinaryWriter writer) where C : class
        {
            var typeName = propInfo.PropertyType.Name;

            switch (typeName.ToLower())
            {
                case "char":
                    writer.Write((char)propInfo.GetValue(obj));
                    break;
                case "string":
                    TextProperties textProperties = (TextProperties)propInfo.GetCustomAttribute(typeof(TextProperties));
                    writer.Write(ConvertString(propInfo.GetValue(obj).ToString(), textProperties));
                    break;
                case "boolean":
                    writer.Write((bool)propInfo.GetValue(obj));
                    break;
                case "sbyte":
                    writer.Write((sbyte)propInfo.GetValue(obj));
                    break;
                case "byte":
                    writer.Write((byte)propInfo.GetValue(obj));
                    break;
                case "uint16":
                    writer.Write((ushort)propInfo.GetValue(obj));
                    break;
                case "int16":
                    writer.Write((short)propInfo.GetValue(obj));
                    break;
                case "uint32":
                    writer.Write((uint)propInfo.GetValue(obj));
                    break;
                case "int32":
                    writer.Write((int)propInfo.GetValue(obj));
                    break;
                case "int64":
                    writer.Write((long)propInfo.GetValue(obj));
                    break;
                case "uint64":
                    writer.Write((ulong)propInfo.GetValue(obj));
                    break;
                default:
                    break;
            }
        }

        private static byte[] ConvertString(string text, TextProperties textProperties = null)
        {
            if (textProperties == null)
            {
                textProperties = new TextProperties(TextEnconding.ASCII);
            }

            return textProperties.Encoding switch
            {
                TextEnconding.ASCII => Encoding.ASCII.GetBytes(text),
                TextEnconding.UTF8 => Encoding.UTF8.GetBytes(text),
                TextEnconding.UTF32 => Encoding.UTF32.GetBytes(text),
                TextEnconding.UNICODE => Encoding.Unicode.GetBytes(text),
                _ => Encoding.ASCII.GetBytes(text),
            };
        }

        
    }
}