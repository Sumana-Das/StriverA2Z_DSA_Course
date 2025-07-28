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
        /// <returns></returns>
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

            // or not take the element
            subsequence.RemoveAt(subsequence.Count - 1);
            GetAllSubsets(allSubsequences, subsequence, nums, idx + 1);
        }
        public IList<IList<int>> SubsetsWithSumK(int[] nums, int k)
        {
            IList<IList<int>> allSubsets = new List<IList<int>>();
            IList<int> subset = new List<int>();
            HashSet<string> seen = new();

            GetAllSubsetsWithSumK(nums, allSubsets, subset, k, 0, 0, seen);
            return allSubsets;
        }
        /// <summary>
        /// Subsequence variation with same logic - take or not take the element
        /// Variation -> Get all unique subsets with sum k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="allSubsets"></param>
        /// <param name="subset"></param>
        /// <param name="k"></param>
        /// <param name="idx"></param>
        /// <param name="sum"></param>
        private void GetAllSubsetsWithSumK(int[] nums, IList<IList<int>> allSubsets, IList<int> subset, int k, int idx, int sum, HashSet<string> seen)
        {
            if (idx == nums.Length)
            {
                if(k == sum)
                {
                    var key = string.Join(",", subset);
                    if(!seen.Contains(key))
                    {
                        seen.Add(key);
                        allSubsets.Add([.. subset]);
                    }
                }
                return;
            }
            subset.Add(nums[idx]);
            sum += nums[idx];
            GetAllSubsetsWithSumK(nums, allSubsets, subset, k, idx + 1, sum, seen);

            subset.RemoveAt(subset.Count - 1);
            sum -= nums[idx];
            GetAllSubsetsWithSumK(nums, allSubsets, subset, k, idx + 1, sum, seen);
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
        /// <returns></returns>
        private bool IsSubsetsExistWithSumK(int[] nums, int k, IList<int> list, int idx, int sum)
        {
            if(idx == nums.Length)
            {
                if(k == sum)
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
        /// <returns></returns>
        private int CountSubsetsWithSumK(int[] nums, int k, int idx, int sum)
        {
            if(idx == nums.Length)
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
    }
}
