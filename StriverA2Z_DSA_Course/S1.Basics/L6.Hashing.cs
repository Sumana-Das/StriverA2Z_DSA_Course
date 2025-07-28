namespace StriverA2Z_DSA_Course.Basics
{
    public class Hashing
    {
        public List<List<int>> CountFrequencies(int[] nums)
        {
            // without Dictionary
            if (nums.Length <= 10)
            {
                return CountFrequenciesWithArray(nums);
            }
            // with Dictionary
            else
            {
                return CountFrequenciesWithDictionary(nums);
            }
        }
        private List<List<int>> CountFrequenciesWithArray(int[] nums)
        {
            List<List<int>> lists = new();
            int[] arr = new int[nums.Length + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= nums.Length)
                {
                    arr[nums[i]]++;
                }
                else
                {
                    return CountFrequenciesWithDictionary(nums);
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                List<int> list = new();
                if (arr[i] != 0)
                {
                    lists.Add(new List<int> { i, arr[i] });
                }
            }
            return lists;
        }
        private List<List<int>> CountFrequenciesWithDictionary(int[] nums)
        {
            List<List<int>> lists = new();
            Dictionary<int, int> dict = new();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            foreach(var kvp in dict)
            {
                lists.Add(new List<int> { kvp.Key, kvp.Value });
            }
            return lists;
        }
        /// <summary>
        /// Get the Element which occurred maximum times
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MostFrequentElement(int[] arr)
        {
            IDictionary<int, int> dict = new Dictionary<int, int>();
            int maxFreq = MaxFrequency(arr, dict);
            int mostFreq = 0;

            foreach(var kvp in dict)
            {
                if ((kvp.Value == maxFreq && mostFreq == 0) || (kvp.Value == maxFreq && mostFreq > kvp.Key))
                    mostFreq = kvp.Key;
            }
            return mostFreq;
        }
        /// <summary>
        /// Get the count of the elements which occured maximum times
        /// https://leetcode.com/problems/count-elements-with-maximum-frequency/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxFrequencyElements(int[] arr)
        {
            IDictionary<int, int> dict = new Dictionary<int, int>();
            int maxFreq = MaxFrequency(arr, dict);
            int mostFreq = 0;

            foreach (var kvp in dict)
            {
                if (kvp.Value == maxFreq)
                    mostFreq++;
            }
            return mostFreq * maxFreq;
        }
        private int MaxFrequency(int[] arr, IDictionary<int, int> dict)
        {
            int maxFreq = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                    dict[arr[i]]++;
                else
                    dict.Add(arr[i], 1);
            }
            foreach (var kvp in dict)
            {
                maxFreq = Math.Max(maxFreq, kvp.Value);
            }
            return maxFreq;
        }
    }
}
