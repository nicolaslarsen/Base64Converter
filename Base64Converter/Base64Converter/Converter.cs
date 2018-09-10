using System;

namespace Base64Converter
{
    class Converter
    {
        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static byte[] Base64Decode(string base64EncodedData) {
            return System.Convert.FromBase64String(base64EncodedData);
        }

        public static string CreateFilename()
        {
            long TS = DateTime.Now.Ticks;
            return "output_" + TS + ".pdf";
        }
    }
}