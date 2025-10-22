using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriverA2Z_DSA_Course.S4.BinarySearch
{
    public class BinarySearch_Lec3
    {
        /// <summary>
        /// https://leetcode.com/problems/search-a-2d-matrix/
        /// The entire array is sorted like each row is sorted and 
        /// first element of each row is greater than the last element of previous row
        /// --->
        /// <---
        /// --->
        /// Intuition: flatten the array in mind and try binary search
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrixI(int[][] matrix, int target)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            int left = 0, right = n * m - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int row = mid / m; // row is multiple of col length if flatten the array
                int col = mid % m; // col is remainder of the division with col length if flatten the array
                // ex: the mat[][] = [1,3,5,7,10,11,16,20,23,24,60]
                // so if I want to have coordinates of 3 which is 1 in the flat array
                // then row = 1 / 4 = 1 and col = 1 % 4 = 0, ans = [1, 0] in matrix

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
        /// https://leetcode.com/problems/search-a-2d-matrix-ii/
        /// Each row and each column is sorted
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrixII(int[][] matrix, int target)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int row = 0, col = n - 1;

            while (row < m && col >= 0)
            {
                if (matrix[row][col] == target)
                {
                    return true;
                }
                else if (matrix[row][col] < target)
                {
                    row++;
                }
                else
                {
                    col--;
                }
            }

            return false;
        }
        /// <summary>
        /// https://leetcode.com/problems/find-a-peak-element-ii/
        /// This is in 2D array
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[] FindPeakGrid(int[][] mat)
        {
            int m = mat[0].Length, n = mat.Length;
            int left = 0, right = m - 1;
            int maxRow = 0;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                maxRow = MaxElement(mat, n, m, mid);

                int leftEle = mid - 1 >= 0 ? mat[maxRow][mid - 1] : -1;
                int rightEle = mid + 1 < m ? mat[maxRow][mid + 1] : -1;

                if (mat[maxRow][mid] > leftEle && mat[maxRow][mid] > rightEle)
                {
                    return new int[] { maxRow, mid };
                }
                else if (leftEle > mat[maxRow][mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return new int[] { -1, -1 };
        }

        private int MaxElement(int[][] mat, int rows, int cols, int col)
        {
            int max = Int32.MinValue;
            int index = -1;

            for (int i = 0; i < rows; i++)
            {
                if (mat[i][col] > max)
                {
                    max = mat[i][col];
                    index = i;
                }
            }

            return index;
        }
    }
}
