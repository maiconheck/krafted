using System.Text;

namespace System.Security
{
    public static class CriptographyHelper
    {
        public static string CalculateHash(string value, Algorithm algorithm)
        {
            if (algorithm != Algorithm.MD5)
            {
                throw new NotImplementedException();
            }

            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            var password = value += "|2dca6242-8414-471b-a6fb-5e7dd731aaa4";
            var md5 = Cryptography.MD5.Create();

            byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(password));

            var hashFormatted = new StringBuilder();
            foreach (var t in hash)
            {
                hashFormatted.Append(t.ToString("x2"));
            }

            return hashFormatted.ToString();
        }
    }
}