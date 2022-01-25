using System.Text;

namespace MTTols.Utils
{
    public static class CRC32
    {
        private static readonly uint[] ChecksumTable = new uint[0x100];
        private static readonly uint Polynomial = 0xEDB88320;
        private static bool IsIniatialized = false;

        public static void Initialize()
        {
            IsIniatialized = true;

            for (uint index = 0; index < 0x100; ++index)
            {
                uint item = index;
                for (int bit = 0; bit < 8; ++bit)
                    item = ((item & 1) != 0) ? (Polynomial ^ (item >> 1)) : (item >> 1);
                ChecksumTable[index] = item;
            }

        }

        public static uint ComputeHash(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);

            if (!IsIniatialized)
                Initialize();

            uint result = 0xFFFFFFFF;

            int current = 0;
            while (current < data.Length)
            {
                result = ChecksumTable[(result & 0xFF) ^ data[current]] ^ (result >> 8);
                current++;
            }

            return result;
        }

    }
}
