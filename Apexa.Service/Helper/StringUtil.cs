using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Service.Helper
{
    public static class StringUtil
    {
        public static string Mask(this string str,string mask,int keep)
        {
            string retVal = str;
            if (!string.IsNullOrEmpty(str))
            {
                if (keep < str.Length)
                {
                    retVal = string.Empty;
                    int maskLength = str.Length - keep;
                    for (int i = 0; i < maskLength; i++)
                    {
                        retVal += mask;
                    }

                    retVal +=  string.Concat(str.Skip(maskLength));
                }


                return retVal;
            }
            else
            {
                return str;
            }
        }
    }
}
