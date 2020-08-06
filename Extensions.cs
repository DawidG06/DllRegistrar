using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DllRegistrar
{
    public static class Extensions
    {
        public static string WrapTo(this string word, string textBeforeAndAfter)
        {
            string result = string.Concat(textBeforeAndAfter, word, textBeforeAndAfter);
            return result;
        }
    }
}
