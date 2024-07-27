
using System.Text;

namespace IBERDROLA.TechnicalTest.Manager.Utils
{
    internal static class Base64Util
    {
        internal static string Base64Encode(this string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentException("Empty Key to encoded", nameof(plainText));
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }
        internal static string Base64Decode(this string encodedText)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(encodedText));
        }
      
    }
}
