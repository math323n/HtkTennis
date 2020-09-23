using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtkTennis.Utilities
{
    public static class Validations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool TextOnly(string s)
        {
            return !string.IsNullOrWhiteSpace(s) && s.All(c => char.IsLetter(c));
        }

        public static bool TextOnlySentence(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            foreach(string word in s.Split(' ', '\t'))
            {
                if(!TextOnly(word))
                {
                    return false;
                }
            }
            return true;
        }
    }
}