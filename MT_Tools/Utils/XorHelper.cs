namespace MTTools.Utils.Helpers
{
    public static class XorHelper
    {
       private const string key1 = "fjfajfahajra;tira9tgujagjjgajgoa";
       private const string key2 = "mva;eignhpe/dfkfjgp295jtugkpejfu";
       public static byte[] XorDualDestinies(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                char x1 = key1[i % 32];
                char x2 = key2[i % 32];

                data[i] = Convert.ToByte(data[i] ^ x1 ^ x2);
            }
            return data;
        }

    }
}
