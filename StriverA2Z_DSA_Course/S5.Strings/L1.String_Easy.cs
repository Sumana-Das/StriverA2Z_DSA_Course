using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriverA2Z_DSA_Course.S5.Strings
{
    public class String_Easy
    {
        /// <summary>
        /// https://leetcode.com/problems/remove-outermost-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveOuterParentheses(string s)
        {
            int count = 0;
            string result = "";
            string temp = "";

            for (int i = 0; i < s.Length; i++)
            {
                temp += s[i];
                if (s[i] == '(')
                    count++;
                if (s[i] == ')')
                    count--;
                if (count == 0)
                {
                    result += temp.Substring(1, temp.Length - 2);
                    temp = "";
                }
            }

            return result;
        }
        /// <summary>
        /// https://leetcode.com/problems/reverse-words-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            string result = "";
            string temp = "";

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 'A' && s[i] <= 'Z') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9'))
                {
                    temp += s[i];
                }
                else
                {
                    if (temp != "")
                        result = temp + " " + result;
                    temp = "";
                }
            }
            result = temp + " " + result;
            result = result.Trim();
            return result;
        }
        /// <summary>
        /// https://leetcode.com/problems/largest-odd-number-in-string/
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string LargestOddNumber(string num)
        {
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] == '1' || num[i] == '3' || num[i] == '5' || num[i] == '7' || num[i] == '9')
                {
                    return num.Substring(0, i + 1);
                }
            }
            return "";
        }
    }
}
