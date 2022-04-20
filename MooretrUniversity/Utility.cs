/* Utility is a helper class for processing a model's concurrency token to detect
 * concurrency exceptions. It will work with either SQLite or SQL databases.
 * 
*/

#if SQLiteVersion
using System;

namespace MooretrUniversity
{
    public static class Utility
    {
        public static string GetLastChars(Guid token)
        {
            return token.ToString().Substring(token.ToString().Length - 3);
        }
    }
}
#else
namespace MooretrUniversity
{
    public static class Utility
    {
        public static string GetLastChars(byte[] token)
        {
            return token[7].ToString();
        }
    }
}
#endif