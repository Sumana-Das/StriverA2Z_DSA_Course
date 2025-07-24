namespace StriverA2Z_DSA_Course.Basics
{
    public class Recursion
    {
        #region Parameterized Recursion functions
        #region Straight forward way
        public void PrintName(int n, string s)
        {
            PrintName(1, n, s);
        }
        private void PrintName(int i, int n, string s)
        {
            if (i > n)
                return;
            Console.Write($"{s} ");
            PrintName(i + 1, n, s);
        }
        public void PrintNumbersAsc(int n)
        {
            PrintNumbersAsc(1, n);
        }
        private void PrintNumbersAsc(int i, int n)
        {
            if (i > n)
                return;
            Console.Write($"{i} ");
            PrintNumbersAsc(i + 1, n);
        }
        public void PrintNumbersDesc(int n)
        {
            PrintNumbersDesc(n, n);
        }
        private void PrintNumbersDesc(int i, int n)
        {
            if (i < 1)
                return;
            Console.Write($"{i} ");
            PrintNumbersDesc(i - 1, n);
        }
        #endregion
        #region Backtrack way
        public void PrintNumbers1toN(int n)
        {
            PrintNumbers1toN(n, n);
        }
        private void PrintNumbers1toN(int i, int n)
        {
            if (i < 1)
                return;
            PrintNumbers1toN(i - 1, n);
            Console.Write($"{i} ");
        }
        public void PrintNumbersNto1(int n)
        {
            PrintNumbersNto1(1, n);
        }
        private void PrintNumbersNto1(int i, int n)
        {
            if (i > n)
                return;
            PrintNumbersNto1(i + 1, n);
            Console.Write($"{i} ");
        }
        public void Summation(int n)
        {
            Summation(0, n);
        }
        private void Summation(int sum, int n)
        {
            if (n < 1)
            {
                Console.WriteLine($"Sum: {sum}");
                return;
            }
            Summation(sum + n, n - 1);
        }
        public void Factorial(int n)
        {
            Factorial(1, n);
        }
        private void Factorial(int product, int n)
        {
            if (n < 1)
            {
                Console.WriteLine($"Factorial: {product}");
                return;
            }

            Factorial(product * n, n - 1);
        }
        public void ReverseArray(int[] arr)
        {
            Console.WriteLine("Two pointer solution:");
            ReverseArray(0, arr.Length - 1, arr);
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine("\nSingle pointer solution reverse the reverse-array:");
            ReverseArray(0, arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
        /// <summary>
        /// Two pointer solution (left and right)
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="arr"></param>
        private void ReverseArray(int l, int r, int[] arr)
        {
            if (l >= r)
                return;
            int temp = arr[l];
            arr[l] = arr[r];
            arr[r] = temp;
            ReverseArray(l + 1, r - 1, arr);
        }
        /// <summary>
        /// Single pointer solution (i, n - i - 1)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="arr"></param>
        private void ReverseArray(int i, int[] arr)
        {
            if (i >= arr.Length/2)
                return;
            int temp = arr[i];
            arr[i] = arr[arr.Length - i - 1];
            arr[arr.Length - i - 1] = temp;
            ReverseArray(i + 1, arr);
        }
        #endregion
        #endregion
        #region Functional Recursion (Important for DP)
        public int SummationFunction(int n)
        {
            if (n < 1)
                return 0;
            return n + SummationFunction(n - 1);
        }
        public int FactorialFunction(int n)
        {
            if (n == 1)
                return 1;
            return n * FactorialFunction(n - 1);
        }
        /// <summary>
        /// https://leetcode.com/problems/valid-palindrome/description/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            return IsPalindrome(0, s);
        }
        private bool IsPalindrome(int i, string s)
        {
            if (i >= s.Length / 2)
                return true;
            if (s[i] != s[s.Length - i - 1])
                return false;
            return IsPalindrome(i + 1, s);
        }
        #region Multiple Recursion calls
        /// <summary>
        /// Time Complexity = 2^n (exponential)
        /// Space Complexity = 2^n
        /// https://leetcode.com/problems/fibonacci-number/description/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
        #endregion
        #endregion
    }
}
