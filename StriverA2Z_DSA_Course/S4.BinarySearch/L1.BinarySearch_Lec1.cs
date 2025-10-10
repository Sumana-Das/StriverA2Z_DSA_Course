using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StriverA2Z_DSA_Course.S4.BinarySearch
{
    public class BinarySearch_Lec1
    {
        /// <summary>
        /// https://leetcode.com/problems/binary-search/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int BinarySearch(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (nums[mid] == target)
                    return mid;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
        /// <summary>
        /// https://leetcode.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1, mid = 0;

            while (left <= right)
            {
                mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }

            return left;
        }
        /// <summary>
        /// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int first = FindFirst(nums, target);
            if (first == -1)
                return [-1, -1];
            int last = FindLast(nums, target);

            return new int[] { first, last };
        }

        private int FindFirst(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int first = -1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    first = mid;
                    right = mid - 1;
                }
                if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }
            return first;
        }
        private int FindLast(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int last = -1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    last = mid;
                    left = mid + 1;
                }
                if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }
            return last;
        }
        /// <summary>
        /// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        /// </summary>
        /// Search range to find an element using upper and lower bound
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchBoundaries(int[] nums, int target)
        {
            int lb = LowerBound(nums, target);
            if (lb == nums.Length || nums[lb] != target)
                return [-1, -1];
            int ub = UpperBound(nums, target);

            return new int[] { lb, ub - 1 };
        }
        /// <summary>
        /// when finding range, this could be useful finding a possible position int the lower half where the target might be
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int LowerBound(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int ans = nums.Length;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] >= target)
                {
                    // possible position to get
                    ans = mid;
                    //check for lower side  to get more matches instead of going beyond mid
                    right = mid - 1;
                }
                else
                    left = mid + 1;
            }
            return ans;
        }
        /// <summary>
        /// when finding range, this could be useful finding a possible position in the upper half where the target might be
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int UpperBound(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int ans = nums.Length;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] > target)
                {
                    // possible position to get already in the extreme right as searching for > target values
                    ans = mid;
                    //check for lower side to get more matches instead of going beyond mid
                    right = mid - 1;
                }
                else
                    left = mid + 1;
            }
            return ans;
        }
        public int CountOccurences(int[] nums, int target)
        {
            int lb = LowerBound(nums, target);
            if (lb == nums.Length || nums[lb] != target)
                return 0;
            int ub = UpperBound(nums, target);

            return ub - lb;
        }
        /// <summary>
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/
        /// </summary>
        /// Identify the sorted half is the intuition
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int RotateSortedArraySearch(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] >= nums[left])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// https://leetcode.com/problems/search-in-rotated-sorted-array-ii/
        /// </summary>
        /// having duplicates the extra if condition optimise the search
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool RotateDuplicateSortedArraySearch(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return true;

                // if duplicates available
                if (nums[mid] == nums[left] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                    continue;
                }
                if (nums[mid] >= nums[left])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMinSortedArray(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            int min = Int32.MaxValue;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                // left part is sorted
                if (nums[left] <= nums[mid])
                {
                    // this could be min
                    min = Math.Min(nums[left], min);

                    //now try for right half
                    left = mid + 1;
                }
                // right half is sorted
                else
                {
                    // this could be min
                    min = Math.Min(nums[mid], min);

                    //now try for left half
                    right = mid - 1;
                }
            }
            return min;
        }
        /// <summary>
        /// https://leetcode.com/problems/single-element-in-a-sorted-array/
        /// </summary>
        /// Intuition: if the array cut into half by the single element position,
        /// then the left side same elements will be in odd, even position and 
        /// in the right same elements will be in even, odd position
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNonDuplicate(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            if (nums[0] != nums[1])
                return nums[0];
            if (nums[nums.Length - 1] != nums[nums.Length - 2])
                return nums[nums.Length - 1];

            int left = 1, right = nums.Length - 2;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (nums[mid] != nums[mid + 1] && nums[mid] != nums[mid - 1])
                    return nums[mid];
                // check if mid value is same as mid  - 1 value and mid is at odd or mid value is same as mid + 1 value and mid is at even
                // that means hte value should be at right side
                if ((nums[mid] == nums[mid - 1] && mid % 2 == 1) || (nums[mid] == nums[mid + 1] && mid % 2 == 0))
                {
                    left = mid + 1;
                }
                // else value would be at left side
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
        /// <summary>
        /// https://leetcode.com/problems/find-peak-element/
        /// </summary>
        /// this is almost same as [SingleNonDuplicate]https://leetcode.com/problems/single-element-in-a-sorted-array/
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return 0;
            if (n == 2)
            {
                if (nums[0] > nums[1])
                    return 0;
                else
                    return 1;
            }
            if (nums[0] > nums[1])
                return 0;
            else if (nums[n - 1] > nums[n - 2])
                return n - 1;

            int left = 1, right = nums.Length - 2;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
                    return mid;
                else if (nums[mid] < nums[mid + 1])
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}
