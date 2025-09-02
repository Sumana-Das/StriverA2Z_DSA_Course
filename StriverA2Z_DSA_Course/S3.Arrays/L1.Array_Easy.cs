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
        public (int[], int) RemoveDuplicates(int[] arr)
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
    }
}
