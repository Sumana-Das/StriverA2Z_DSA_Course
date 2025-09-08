using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriverA2Z_DSA_Course.S3.Arrays
{
    public class Array_Easy
    {
        public int LargestElement(int[] arr)
        {
            int largest = arr[0];

            if(arr.Length == 1)
            {
                return largest;
            }

            for(int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > largest)
                {
                    largest = arr[i];
                }
            }
            return largest;
        }

        public int SecondLargest(int[] arr)
        {
            int largest = arr[0];
            int secondLargest = -1;

            if(arr.Length > 1)
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    if(arr[i] > largest)
                    {
                        secondLargest = largest;
                        largest = arr[i];
                    }
                    else if (arr[i] > secondLargest && arr[i] < largest)
                    {
                        secondLargest = arr[i];
                    }
                }
            }
            return secondLargest;
        }

        /// <summary>
        /// https://leetcode.com/problems/check-if-array-is-sorted-and-rotated/description/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool IsSortedOrRotated(int[] arr)
        {
            int count = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    count++;
                }
            }
            // last element should be less than 1st elemnt if there is a rotation
            if (arr[0] < arr[arr.Length - 1])
            {
                count++;
            }
            return count <= 1 ? true : false;
        }

        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public (int[], int) RemoveDuplicates1(int[] arr)
        {
            int start = 0;
            int end = 1;
            while(start < end && end < arr.Length)
            {
                if (arr[start] == arr[end])
                {
                    end++;
                }
                else
                {
                    arr[start + 1] = arr[end];
                    start++;
                    end++;
                }
            }
            return (arr, start + 1);
        }
        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int RemoveDuplicates2(int[] arr)
        {
            int idx = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] != arr[i])
                {
                    arr[idx] = arr[i];
                    idx++;
                }
            }
            return idx;
        }
        /// <summary>
        /// Left rotate the array by one place
        /// </summary>
        /// <param name="arr"></param>
        public void RotateByOnePlace(int[] arr)
        {
            int temp = arr[0];

            for(int i = 1; i < arr.Length; i++)
            {
                arr[i - 1] = arr[i];
            }
            arr[arr.Length - 1] = temp;

            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
        /// <summary>
        /// Right rotate array by k places
        /// Intuition: Reverse the parts of the array (0 - k), (k + 1 - n)
        /// then reverse whole array (0 - n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;

            Reverse(nums, 0, n - k - 1);
            Reverse(nums, n - k, n - 1);
            Reverse(nums, 0, n - 1);
        }
        public void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
        /// <summary>
        /// Find the union from two sorted array
        /// Brute Force: can use SortedSet<int> and put all the elements from the two arrays
        /// Optimal: use the power of sorted array by using 2 pointer
        /// TC: O(mn)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns>list of integers</returns>
        /// [1,3,4,5,9],[1,1,2,2,2,3,4,5,6]
        public List<int> FindUnion(int[] nums1, int[] nums2)
        {
            List<int> union = new();
            int i = 0, j = 0;

            while(i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] <= nums2[j])
                {
                    if(union.Count == 0)
                    {
                        union.Add(nums1[i]);
                    }
                    else if(union[union.Count - 1] != nums1[i])
                    {
                        union.Add(nums1[i]);
                    }
                    i++;
                }
                else
                {
                    if (union.Count == 0)
                    {
                        union.Add(nums2[j]);
                    }
                    else if (union[union.Count - 1] != nums2[j])
                    {
                        union.Add(nums2[j]);
                    }
                    j++;
                }
            }
            while(i < nums1.Length)
            {
                if (union.Count == 0)
                {
                    union.Add(nums1[i]);
                }
                else if (union[union.Count - 1] != nums1[i])
                {
                    union.Add(nums1[i]);
                }
                i++;
            }
            while (j < nums2.Length)
            {
                if (union.Count == 0)
                {
                    union.Add(nums2[j]);
                }
                else if (union[union.Count - 1] != nums2[j])
                {
                    union.Add(nums2[j]);
                }
                j++;
            }
            return union;
        }
        /// <summary>
        /// https://leetcode.com/problems/max-consecutive-ones/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int maxCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    maxCount = Math.Max(count, maxCount);
                    count = 0;
                }
            }
            maxCount = Math.Max(count, maxCount);
            return maxCount;
        }
        /// <summary>
        /// https://leetcode.com/problems/move-zeroes/
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int idx = 0;
            if (nums.Length == 1 && nums[0] == 0)
                return;
            if (nums.Length == 2 && nums[1] == 0)
                return;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    continue;
                }
                else
                {
                    int temp = nums[i];
                    nums[i] = nums[idx];
                    nums[idx] = temp;
                    if (idx < nums.Length)
                    {
                        idx++;
                    }
                }
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/missing-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            int missingNum = nums.Length;

            for (int i = 0; i < nums.Length; i++)
            {
                missingNum ^= nums[i] ^ i;
            }
            return missingNum;
        }
        /// <summary>
        /// https://leetcode.com/problems/single-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int num = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                num ^= nums[i];
            }

            return num;
        }
        /// <summary>
        /// Find the longest subarray whose sum is k, array can have +ve, -ve and 0s
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestSubarraySum(int[] arr, int k)
        {
            Dictionary<int, int> dict = new();
            int prefixSum = 0;
            int len = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                prefixSum += arr[i];
                if (prefixSum == k)
                {
                    len = Math.Max(len, i + 1);
                }
                if (dict.ContainsKey(prefixSum - k))
                {
                    len = Math.Max(len, i - dict[prefixSum - k]);
                }
                if (!dict.ContainsKey(prefixSum))
                {
                    dict.Add(prefixSum, i);
                }
            }
            return len;
        }
        /// <summary>
        /// Find the longest subarray whose sum is k, array can only have +ve                           
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestSubarraySumPositive(int[] arr, int k)
        {
            int left = 0, right = 0;
            int sum = 0;
            int len = 0;

            while(left <= right)
            {
                if (right < arr.Length)
                    sum += arr[right];

                while(sum > k && left <= right)
                {
                    sum -= arr[left];
                    left++;
                }
                if(sum == k)
                    len = Math.Max(len, right - left + 1);

                if(right < arr.Length - 1)
                    right++;
                else
                    left++;
            }
            return len;
        }
    }
}
