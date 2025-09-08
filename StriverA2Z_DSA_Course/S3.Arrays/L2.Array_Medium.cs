using System;
using System.Collections.Generic;
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

            for(int i = 0; i <= 0; i++)
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
