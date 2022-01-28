using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabetDemoUsingExtension.StringExtensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string myString)
        {
            return Skip(myString, -1);
        }

        public static string Skip(this string myString, int nSkip)
        {
            if (myString == null) return null;

            if (nSkip == 0) throw new ArgumentOutOfRangeException("nSkip cannot be 0");

            string skippedString = string.Empty;
            int i = nSkip < 0 ? myString.Length - 1 : 0; 
            do
            {
                skippedString += myString[i];
                i += nSkip;
            } while (nSkip < 0 ? i >= 0 : i < myString.Length);

            return skippedString;
        }
    }
}
