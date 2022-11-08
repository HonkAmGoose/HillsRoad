namespace RC4Vernam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateKey(256));
        }
        static string GenerateKey(int keylength)
        {
            byte[] key = new byte[16];
            for (int i = 0; i < 256; i++)
            {
                key[i] = (byte)i;
            }
            int j = 0;
            byte temp;
            for (int i = 0; i < 256; i++)
            {
                j = (j + key[i] + key[i % keylength]) % 256;
                temp = key[i];
                key[i] = key[j];
                key[j] = temp;
            }
            return key.ToString();
        }
    }
}