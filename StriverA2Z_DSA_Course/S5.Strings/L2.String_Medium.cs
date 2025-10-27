using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriverA2Z_DSA_Course.S5.Strings
{
    public class L2
    {
        /// <summary>
        /// https://leetcode.com/problems/sort-characters-by-frequency/
        /// This is using bucket sort
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FrequencySort(string s)
        {
            Dictionary<char, int> dict = new();
            StringBuilder result = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }
            List<char> sortedList = new List<char>(dict.Keys);
            sortedList.Sort((a, b) => dict[b].CompareTo(dict[a])); //descending order

            foreach (var c in sortedList)
            {
                result.Append(c, dict[c]);
            }

            return result.ToString();
        }
        /// <summary>
        /// https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxDepth(string s)
        {
            int opened = 0;
            int maxDepth = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    opened++;
                    maxDepth = Math.Max(maxDepth, opened);
                }
                if (s[i] == ')')
                {
                    opened--;
                }
            }

            return maxDepth;
        }
    }
}
