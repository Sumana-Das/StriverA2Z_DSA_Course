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
        /// <summary>
        /// https://leetcode.com/problems/longest-common-prefix/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            Array.Sort(strs);

            string s1 = strs[0];
            string s2 = strs[strs.Length - 1];
            int idx = 0;

            while (idx < s1.Length)
            {
                if (s1[idx] == s2[idx])
                {
                    idx++;
                }
                else
                {
                    break;
                }
            }

            return s1.Substring(0, idx);
        }
        /// <summary>
        /// https://leetcode.com/problems/isomorphic-strings/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> dict1 = new();
            Dictionary<char, char> dict2 = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict1.ContainsKey(s[i]))
                {
                    dict1.Add(s[i], t[i]);
                }
                if (!dict2.ContainsKey(t[i]))
                {
                    dict2.Add(t[i], s[i]);
                }
                if (dict1[s[i]] != t[i] || dict2[t[i]] != s[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// https://leetcode.com/problems/valid-anagram/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> dict = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], 1);
                }
                else
                {
                    dict[s[i]]++;
                }
            }
            foreach (char i in t)
            {
                if (dict.ContainsKey(i))
                {
                    if (dict[i] > 1)
                        dict[i]--;
                    else
                        dict.Remove(i);
                }
            }

            return dict.Count == 0;
        }
    }
}
