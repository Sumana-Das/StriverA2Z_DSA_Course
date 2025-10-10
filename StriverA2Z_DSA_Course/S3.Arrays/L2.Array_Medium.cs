using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriverA2Z_DSA_Course.S3.Arrays
{
    public class Array_Medium
    {
        /// <summary>
        /// Two Sum problem
        /// Intuition: use of hashing
        /// Variation: if only true/false should be returned and not index positions, 
        /// then we can use two pointer, left and right after sorting the array
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(target - nums[i]))
                {
                    dict.TryAdd(nums[i], i);
                }
                else
                {
                    return new int[] { dict[target - nums[i]], i };
                }
            }
            return new int[] { };
        }
        /// <summary>
        /// https://leetcode.com/problems/sort-colors/
        /// Brute Force: using dictionary
        /// Optimal Intuition: 2s should be at last and 0s are at first, so using 2 pointer and pivot pointer check for 0s or 1s
        /// if found swap, in that case 1s will be at the middle only, thats why pivot is used
        /// soleft side of pivot is 1s and right side of pivot is 2s
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int pivot = 0;

            while (pivot <= right)
            {
                if (nums[pivot] == 0)
                {
                    int temp = nums[left];
                    nums[left] = nums[pivot];
                    nums[pivot] = temp;

                    left++;
                    pivot++;
                }
                else if (nums[pivot] == 1)
                {
                    pivot++;
                }
                else
                {
                    int temp = nums[pivot];
                    nums[pivot] = nums[right];
                    nums[right] = temp;

                    right--;
                }
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/majority-element/
        /// using Moore's Voting algorithm - get the majority possible element
        /// this algo says pick an element and increase count if you get the same if not then decrease count
        /// if the count becomes zero then pick at that position element and repeat the process
        /// by this we will get a possible majority element
        /// then verify whether its majority or not
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int element = -1;
            int count = 0;

            // Moore's Voting algorithm
            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    element = nums[i];
                    count++;
                }
                else if (element == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            // verify whether its majority or not
            count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == element)
                {
                    count++;
                }
            }
            if (count > nums.Length / 2)
                return element;
            return -1;
        }
        /// <summary>
        /// https://leetcode.com/problems/maximum-subarray/description/
        /// Similar to longest subarray sum in easy problem but here need to find the sum
        /// using Kadane's Algorithm - this states take the sum and compare with max sum
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumSubArraySum(int[] nums)
        {
            int sum = 0;
            int maxSum = Int32.MaxValue;
            int startIdx = -1, endIdx = -1, start = -1;

            for(int i = 0; i < nums.Length; i++)
            {
                if(sum == 0)
                {
                    start = i;
                }
                sum += nums[i];

                if(maxSum < sum)
                {
                    maxSum = sum;
                    startIdx = start;
                    endIdx = i;
                }

                if(sum < 0)
                {
                    sum = 0;
                }
            }
            Console.WriteLine($"Subarray {startIdx} - {endIdx}");
            return maxSum;
        }
        /// <summary>
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// Kadane's Algorithm
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int buyPrice = prices[0];
            int profit = 0;
            int maxProfit = 0;

            for(int i = 1; i < prices.Length; i++)
            {
                profit = prices[i] - buyPrice;

                maxProfit = Math.Max(maxProfit, profit);

                if(profit < 0)
                {
                    buyPrice = prices[i];
                }
            }

            return maxProfit;
        }
        /// <summary>
        /// https://leetcode.com/problems/rearrange-array-elements-by-sign/
        /// when positive and negative values are of same count, means +ve = n/2 and -ve= n/2, so array should be even length
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RearrangeArray(int[] nums)
        {
            int[] res = new int[nums.Length];
            int pos = 0, neg = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    res[neg] = nums[i];
                    neg = neg + 2;
                }
                else
                {
                    res[pos] = nums[i];
                    pos = pos + 2;
                }
            }
            return res;
        }
        /// <summary>
        /// when positive and negative value counts are not same, means the array could be of any length
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RearrangeInEqualArray(int[] nums)
        {
            IList<int> pos = new List<int>();
            IList<int> neg = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    pos.Add(nums[i]);
                }
                if (nums[i] < 0)
                {
                    neg.Add(nums[i]);
                }
            }
            if(pos.Count > neg.Count)
            {
                for(int i = 0; i < neg.Count; i++)
                {
                    nums[i * 2] = pos[i];
                    nums[i * 2 + 1] = neg[i];
                }
                int idx = neg.Count * 2;
                for(int i = neg.Count; i < pos.Count; i++)
                {
                    nums[idx] = pos[i];
                    idx++;
                }
            }
            else
            {
                for (int i = 0; i < pos.Count; i++)
                {
                    nums[i * 2] = pos[i];
                    nums[i * 2 + 1] = neg[i];
                }
                int idx = pos.Count * 2;
                for (int i = pos.Count; i < neg.Count; i++)
                {
                    nums[idx] = neg[i];
                    idx++;
                }
            }
            return nums;
        }
        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            int breakPoint = -1;

            // Step 1: find the break point where nums[i] < nums[i + 1],
            // starting from end of the array
            for (int i = n - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    breakPoint = i;
                    break;
                }
            }
            // edge case: where no breakpoint found means the array is in decreasing order,
            // means it reached to the last combination, now to get next combination it should be
            // the 1st sorted order, so just reverse it
            if (breakPoint == -1)
            {
                Reverse(nums, 0, n - 1);
                return;
            }

            // Step 2: find the element who is greater than the breakPoint value
            // but less than the other elements after the breakpoint till rest values,
            // and then swap it simply
            for (int i = n - 1; i > breakPoint; i--)
            {
                if (nums[i] > nums[breakPoint])
                {
                    Swap(nums, breakPoint, i);
                    break;
                }
            }
            // Step 3: the rest of the array after the breakPoint should be in sorted order,
            // here reverse would work as after the breakpoint all are in decresing order
            Reverse(nums, breakPoint + 1, n - 1);
        }
        private void Reverse(int[] nums, int start, int end)
        {
            while (start <= end)
            {
                int k = nums[start];
                nums[start] = nums[end];
                nums[end] = k;

                start++;
                end--;
            }
        }
        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        /// <summary>
        /// https://leetcode.com/problems/longest-consecutive-sequence/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive(int[] nums)
        {
            int lastElement = Int32.MinValue;
            int count = 0;
            Array.Sort(nums);
            int longest = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (lastElement == nums[i] - 1)
                {
                    lastElement = nums[i];
                    count++;
                }
                else if (lastElement != nums[i])
                {
                    lastElement = nums[i];
                    count = 1;
                }
                longest = Math.Max(longest, count);
            }
            return longest;
        }
        /// <summary>
        /// https://leetcode.com/problems/search-a-2d-matrix/
        /// Intuition: flatten the array in mind and try binary search
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            int left = 0, right = n * m - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int row = mid / m; // row is multiple of col length
                int col = mid % m; // col is remainder of the division with col length

                if (matrix[row][col] == target)
                {
                    return true;
                }
                else if (matrix[row][col] < target)
                {
                    left = mid + 1;
                }
                else if (matrix[row][col] > target)
                {
                    right = mid - 1;
                }
            }
            return false;
        }
        /// <summary>
        /// Find the elements whose right side items are greater than that
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public List<int> LeadersInArray(int[] arr)
        {
            List<int> listA = new();

            int max = Int32.MinValue;

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    listA.Add(arr[i]);
                }
                max = Math.Max(max, arr[i]);
            }
            return listA;
        }
        /// <summary>
        /// https://leetcode.com/problems/spiral-matrix/description/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> SpiralMatrix(int[][] matrix)
        {
            IList<int> spiral = new List<int>();
            int left = 0;
            int right = matrix[0].Length - 1;
            int top = 0;
            int bottom = matrix.Length - 1;

            while (left <= right && top <= bottom)
            {
                //Traverse the top row from left to right
                //moving right across the top row
                for (int i = left; i <= right; i++)
                {
                    spiral.Add(matrix[top][i]);
                }
                //then move the top boundary down means increase it by 1
                top++;
                //Traverse the right column from top to bottom
                //down the rightmost column
                for (int i = top; i <= bottom; i++)
                {
                    spiral.Add(matrix[i][right]);
                }
                //then move the right boundary left means decrease it by 1
                right--;
                //Check if top <= bottom
                if (top <= bottom)
                {
                    //traverse the bottom row from right to left
                    //left across the bottom row
                    for (int i = right; i >= left; i--)
                    {
                        spiral.Add(matrix[bottom][i]);
                    }
                    //then move the bottom boundary up means decrease it by 1
                    bottom--;
                }
                //Check if left <= right
                if (left <= right)
                {
                    //traverse the left column from bottom to top
                    //up the leftmost column
                    for (int i = bottom; i >= top; i--)
                    {
                        spiral.Add(matrix[i][left]);
                    }
                    //then move the left boundary right
                    left++;
                }
            }
            return spiral;
        }
        /// <summary>
        /// https://leetcode.com/problems/rotate-image/
        /// Brute force: take another 2d array and then put all the elements in correct space,
        /// which is ans[j][n - 1 - i] = mat[i][j]
        /// Optimal Intuition: either side of the diagonal is opposite, so transpose and then reverse
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            Transpose(matrix);
            Reverse(matrix);
        }
        private void Transpose(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = i + 1; j < matrix[0].Length; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }
        private void Reverse(int[][] matrix)
        {
            for (int i = 0; i < matrix[0].Length; i++)
            {
                int start = 0;
                int end = matrix[0].Length - 1;

                while (start < end)
                {
                    int temp = matrix[i][start];
                    matrix[i][start] = matrix[i][end];
                    matrix[i][end] = temp;

                    start++;
                    end--;
                }
            }
        }
    }
}
