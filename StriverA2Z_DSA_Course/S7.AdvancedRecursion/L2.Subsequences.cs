using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;

namespace StriverA2Z_DSA_Course.S7.AdvancedRecursion
{
    public class Subsequences
    {
        /// <summary>
        /// Time Complexity => O(2^n)
        /// Space Complexity => O(n)
        /// https://leetcode.com/problems/subsets/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>list of lists of all subsets</returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> allSubsequences = new List<IList<int>>();
            IList<int> subsequence = new List<int>();

            GetAllSubsets(allSubsequences, subsequence, nums, 0);
            return allSubsequences;
        }
        /// <summary>
        /// Most Important Technique to get subsequences
        /// Intuition => two options are always available 
        /// while selecting all combinations of sequences ->take or not take the lement
        /// </summary>
        /// <param name="allSubsequences"></param>
        /// <param name="subsequence"></param>
        /// <param name="nums"></param>
        /// <param name="idx"></param>
        private void GetAllSubsets(IList<IList<int>> allSubsequences, IList<int> subsequence, int[] nums, int idx)
        {
            if (idx == nums.Length)
            {
                allSubsequences.Add([.. subsequence]); // this is equivalent to => allSubsequences.Add(new List<int>(subsequence))
                return;
            }

            // two options are always available while selecting all combinations of sequences
            // either take the element
            subsequence.Add(nums[idx]);
            GetAllSubsets(allSubsequences, subsequence, nums, idx + 1);
            subsequence.RemoveAt(subsequence.Count - 1);

            // or not take the element
            GetAllSubsets(allSubsequences, subsequence, nums, idx + 1);
        }
        public IList<IList<int>> SubsetsWithSumK(int[] nums, int k)
        {
            IList<IList<int>> allSubsets = new List<IList<int>>();
            IList<int> subset = new List<int>();

            GetAllSubsetsWithSumK(nums, allSubsets, subset, k, 0, 0);
            return allSubsets;
        }
        /// <summary>
        /// Subsequence variation with same logic - take or not take the element
        /// Variation -> Get all subsets with sum k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="allSubsets"></param>
        /// <param name="subset"></param>
        /// <param name="k"></param>
        /// <param name="idx"></param>
        /// <param name="sum"></param>
        private void GetAllSubsetsWithSumK(int[] nums, IList<IList<int>> allSubsets, IList<int> subset, int k, int idx, int sum)
        {
            if (idx == nums.Length)
            {
                if (k == sum)
                {
                    allSubsets.Add([.. subset]);
                }
                return;
            }
            // pick the item
            subset.Add(nums[idx]);
            sum += nums[idx];
            GetAllSubsetsWithSumK(nums, allSubsets, subset, k, idx + 1, sum);
            // if decide to not pick the remove the item
            subset.RemoveAt(subset.Count - 1);
            sum -= nums[idx];

            // not pick the item
            GetAllSubsetsWithSumK(nums, allSubsets, subset, k, idx + 1, sum);
        }
        public IList<int> IsSubsetsExistWithSumK(int[] nums, int k)
        {
            IList<int> list = new List<int>();

            IsSubsetsExistWithSumK(nums, k, list, 0, 0);
            return list;

        }
        /// <summary>
        /// Get any one subsequence or just check if exists, 
        /// that means eliminate further recustion calls if get some result
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="list"></param>
        /// <param name="idx"></param>
        /// <param name="sum"></param>
        /// <returns>a boolean value that whether the array has any subset of sum k</returns>
        private bool IsSubsetsExistWithSumK(int[] nums, int k, IList<int> list, int idx, int sum)
        {
            if (idx == nums.Length)
            {
                if (k == sum)
                {
                    return true;
                }
                return false;
            }

            list.Add(nums[idx]);
            sum += nums[idx];
            // elimination for further calls
            if (IsSubsetsExistWithSumK(nums, k, list, idx + 1, sum))
                return true;
            list.RemoveAt(list.Count - 1);
            sum -= nums[idx];

            // elimination for further calls
            if (IsSubsetsExistWithSumK(nums, k, list, idx + 1, sum))
                return true;

            return false;
        }
        public int CountSubsetsWithSumK(int[] nums, int k)
        {
            return CountSubsetsWithSumK(nums, k, 0, 0);
        }
        /// <summary>
        /// Pattern to get count of subsequences
        /// Trick => in the base case return 1 or 0 based on condition and l + r or sum of all the recursion calls
        /// Useful for DP
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="idx"></param>
        /// <param name="sum"></param>
        /// <returns>an int value of the no. of subsets of sum k in an array</returns>
        private int CountSubsetsWithSumK(int[] nums, int k, int idx, int sum)
        {
            if (idx == nums.Length)
            {
                if (k == sum)
                    return 1;
                return 0;
            }

            sum += nums[idx];
            // it could get/not get any subset from left recursion
            int l = CountSubsetsWithSumK(nums, k, idx, sum);
            sum -= nums[idx];

            // it could get/not get any subset from right recursion
            int r = CountSubsetsWithSumK(nums, k, idx, sum);

            return l + r;
        }
        public IList<IList<int>> CombinationSumI(int[] nums, int target)
        {
            IList<IList<int>> allSubsets = new List<IList<int>>();
            IList<int> subset = new List<int>();

            CombinationSumI(nums, allSubsets, subset, target, 0);
            return allSubsets;
        }
        /// <summary>
        /// https://leetcode.com/problems/combination-sum/description/
        /// Combinations of subsets and picking an item multiple times
        /// Intuition: while picking always same index as can be picked same item multiple times, and target should reduce by the item
        /// while if not picking the item, the index should increase and target should remain same
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="allSubsets"></param>
        /// <param name="subset"></param>
        /// <param name="k"></param>
        /// <param name="idx"></param>
        /// <param name="sum"></param>
        private void CombinationSumI(int[] nums, IList<IList<int>> allSubsets, IList<int> subset, int target, int idx)
        {
            if (idx == nums.Length)
            {
                if(target == 0)
                {
                    allSubsets.Add([.. subset]);
                }
                return;
            }
            // pick
            if(target >= nums[idx])
            {
                subset.Add(nums[idx]);
                CombinationSumI(nums, allSubsets, subset, target - nums[idx], idx);
                subset.RemoveAt(subset.Count - 1);
            }
            //not-pick
            CombinationSumI(nums, allSubsets, subset, target, idx + 1);
        }
        /// <summary>
        /// https://leetcode.com/problems/combination-sum-ii/submissions/1718340926/
        /// Variation of Combination Sum I, but here the item should be picked only once and the subsets should be sorted
        /// Intuition: while ignoring duplicates and going in only forward direction, use loop to use the recursion
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns>list of lists of all subsets of sum target</returns>
        public IList<IList<int>> CombinationSumII(int[] nums, int target)
        {
            IList<IList<int>> combinations = new List<IList<int>>();
            IList<int> list = new List<int>();
            Array.Sort(nums);

            GetUniqueCombinations(nums, target, combinations, list, 0);

            return combinations;
        }
        private void GetUniqueCombinations(int[] nums, int target, IList<IList<int>> combinations, IList<int> list, int idx)
        {
            if(target == 0)
            {
                combinations.Add([.. list]);
                return;
            }
            for(int i = idx; i < nums.Length; i++)
            {
                if (nums[i] > target)
                    break;
                // i > idx is to retain the 1st element atleast, irrespective there is having duplicate values
                // [1,1] if trying to form this and nums[i] == nums[i - 1] is true then it will drop both 1s, but we need the 1st 1 not the 2nd
                // so to ensure that pick the 1st element i > idx needs to be checked
                if (i > idx && nums[i] == nums[i - 1])
                    continue;
                list.Add(nums[i]);
                GetUniqueCombinations(nums, target - nums[idx], combinations, list, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
        /// <summary>
        /// Variation of Subseuence, get sum of all the subsets in an array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>lists of all subsets sum</returns>
        public List<int> SubsetSumI(int[] arr)
        {
            List<int> subsets = new();

            GetAllSubsetsWithSumK(subsets, arr, 0, 0);
            subsets.Sort();

            return subsets;
        }
        private void GetAllSubsetsWithSumK(List<int> subsets, int[] arr, int idx, int sum)
        {
            if(idx == arr.Length)
            {
                subsets.Add(sum);
                return;
            }

            sum += arr[idx];
            GetAllSubsetsWithSumK(subsets, arr, idx + 1, sum);
            sum -= arr[idx];

            GetAllSubsetsWithSumK(subsets, arr, idx + 1, sum);
        }
        /// <summary>
        /// https://leetcode.com/problems/subsets-ii/description/
        /// Variation of CombinationSumII, here return all unique subsets
        /// Intuition: to get unique 1st the array needs to be sorted and loop the recursion
        /// while start with adding list in the list of lists (ensuring to start from empty list)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>list of lists of all unique subsets</returns>
        public IList<IList<int>> SubsetSumII(int[] nums)
        {
            IList<IList<int>> subsetsWithoutDup = new List<IList<int>>();
            IList<int> list = new List<int>();

            Array.Sort(nums);
            GetAllUniqueSubsets(nums, subsetsWithoutDup, list, 0);
            return subsetsWithoutDup;
        }
        private void GetAllUniqueSubsets(int[] nums, IList<IList<int>> subsetsWithoutDup, IList<int> list, int idx)
        {
            subsetsWithoutDup.Add([.. list]);

            for(int i = idx; i < nums.Length; i++)
            {
                if (i > idx && nums[i] == nums[i - 1])
                    continue;

                list.Add(nums[i]);
                GetAllUniqueSubsets(nums, subsetsWithoutDup, list, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/combination-sum-iii/
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> combinations = new List<IList<int>>();
            IList<int> list = new List<int>();

            // this condition ensures when n is lesser than k, it will not go for the recursion call
            // ex- k = 4, target = 1, so min sum will be 1+2+3+4 = 10 > 1
            if (k >= n)
                return combinations;
            CombinationSum3(k, n, combinations, list, 1);

            return combinations;
        }
        private void CombinationSum3(int k, int target, IList<IList<int>> combinations, IList<int> list, int start)
        {
            if (list.Count == k)
            {
                if (target == 0)
                {
                    combinations.Add([.. list]);
                }
                return;
            }

            for (int i = start; i <= 9; i++)
            {
                list.Add(i);
                CombinationSum3(k, target - i, combinations, list, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
        /// </summary>
        public IList<string> LetterCombinations(string digits)
        {
            if (digits == string.Empty)
                return new List<string>();
            Dictionary<string, string> phoneMapping = new Dictionary<string, string>();
            phoneMapping.Add("2", "abc");
            phoneMapping.Add("3", "def");
            phoneMapping.Add("4", "ghi");
            phoneMapping.Add("5", "jkl");
            phoneMapping.Add("6", "mno");
            phoneMapping.Add("7", "pqrs");
            phoneMapping.Add("8", "tuv");
            phoneMapping.Add("9", "wxyz");
            IList<string> result = new List<string>();

            LetterCombinations(digits, phoneMapping, result, 0, "");
            return result;
        }
        private void LetterCombinations(string digits, Dictionary<string, string> phoneMapping, IList<string> result, int idx, string s)
        {
            if(idx == digits.Length)
            {
                result.Add(s);
                return;
            }
            string letters = phoneMapping[digits[idx].ToString()];
            foreach(char c in letters)
            {
                s += c.ToString();
                LetterCombinations(digits, phoneMapping, result, idx + 1, s);
                s = s.Remove(s.Length - 1);
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/generate-parentheses/description/
        /// </summary>
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            string s = string.Empty;

            Generate(n, s, result, 0, 0);

            return result;
        }
        private void Generate(int n, string s, IList<string> result, int open, int close)
        {
            if(open == close && open == n)
            {
                result.Add(s);
                return;
            }
            if(open < n)
            {
                s += "(";
                Generate(n, s, result, open + 1, close);
                s = s.Remove(s.Length - 1);
            }
            if (close < open)
            {
                s += ")";
                Generate(n, s, result, open, close + 1);
                s = s.Remove(s.Length - 1);
            }
        }
        public List<string> GenerateBinaryStrings(int n)
        {
            List<string> result = new List<string>();
            string s = string.Empty;

            GenerateBinaries(n, s, result);
            result.Sort();
            return result;
        }
        private void GenerateBinaries(int n, string s, List<string> result)
        {
            if(s.Length == n)
            {
                result.Add(s);
                return;
            }
            s += "0";
            GenerateBinaries(n, s, result);
            s = s.Remove(s.Length - 1);
            
            if(s.Length == 0 || s[s.Length - 1] != '1')
            {
                s += "1";
                GenerateBinaries(n, s, result);
                s = s.Remove(s.Length - 1);
            }
            
        }
    }
}
