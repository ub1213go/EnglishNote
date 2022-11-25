using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public static class MyExtesions
    {
        public static string replaceOnce(this string str, string oStr, string nStr, bool ignoreCase)
        {
            bool begin = false;
            bool finded = false;
            int sIndex = 0;
            int eIndex = 0;
            List<char> ns = new List<char>();
            for(int i = 0, j = 0; i < str.Length && j < oStr.Length; i++)
            {
                char cStr = str[i];
                char cNewStr = oStr[j];

                if (ignoreCase)
                {
                    cStr = Convert.ToChar(Convert.ToInt32(cStr) + 32);
                    cNewStr = Convert.ToChar(Convert.ToInt32(cNewStr) + 32);
                }

                if(!finded && cStr == cNewStr)
                {
                    if (!begin)
                    {
                        begin = true;
                        sIndex = i;
                    }
                    
                    
                    j++;
                }
                else
                {
                    begin = false;
                    j = 0;
                }

                if(j == oStr.Length)
                {
                    finded = true;
                    eIndex = i;
                    break;
                }
            }

            if (finded)
            {
                for(int i = 0; i < str.Length; i++)
                {
                    if(i < sIndex || eIndex < i)
                    {
                        ns.Add(str[i]);
                    }
                    else
                    {
                        for(int j = 0; j < nStr.Length; j++)
                        {
                            ns.Add(nStr[j]);
                        }

                        i = eIndex;
                    }
                }

                return String.Join("", ns);
            }
            else
                return str;
        }

        public static string replaceStartWith(this string str, string oStr, string nStr, bool ignoreCase)
        {
            bool finded = false;
            for (int i = 0, j = 0; i < str.Length && j < oStr.Length; i++, j++)
            {
                char cStr = str[i];
                char cNewStr = oStr[j];

                if (ignoreCase)
                {
                    cStr = Convert.ToChar(Convert.ToInt32(cStr) + 32);
                    cNewStr = Convert.ToChar(Convert.ToInt32(cNewStr) + 32);
                }

                if (cStr != cNewStr)
                    break;
                
                if(j == oStr.Length - 1)
                {
                    finded = true;
                }
            }

            if (finded)
                return nStr + str.Substring(oStr.Length, str.Length - oStr.Length);
            else
                return str;
        }
    }
}
