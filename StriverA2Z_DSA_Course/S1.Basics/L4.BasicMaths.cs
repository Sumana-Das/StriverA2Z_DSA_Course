namespace StriverA2Z_DSA_Course.Basics
{
    public class BasicMaths
    {
        /// <summary>
        /// Main intuition is n % 10 gives the last digit and n/10 reduces the number
        /// </summary>
        /// <param name="n"></param>
        public int CountDigits(int n)
        {
            int count = (int)Math.Log10(n) + 1;
            // while (n > 0)
            // {
            //     int lastDigit = n % 10;
            //     Console.WriteLine(lastDigit);
            //     count++;
            //     n = n / 10;
            // }
            return count;
        }
        /// <summary>
        /// https://leetcode.com/problems/reverse-integer/description/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ReverseNumber(int n)
        {
            int rev = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                rev = rev * 10 + lastDigit;
                n = n / 10;
            }
            return rev;
        }
        /// <summary>
        /// https://leetcode.com/problems/palindrome-number/description/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPalindrome(int n)
        {
            int rev = ReverseNumber(n);
            return n == rev;
        }
        /// <summary>
        /// https://leetcode.com/problems/armstrong-number/description/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsArmstrong(int n)
        {
            int count = (int)Math.Log10(n) + 1;
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                for (int i = 1; i < count; i++)
                {
                    lastDigit *= lastDigit;
                }
                sum += lastDigit;
                n /= 10;
            }
            return n == sum;
        }
        /// <summary>
        /// Main intuition here is n % i == 0 then only its a divisor and 
        /// loop could be reduced to sqrt(n) means i*i <= n, as 6*2 = 2*6 is same so counting half the way
        /// </summary>
        /// <param name="n"></param>
        public void PrintDivisors(int n)
        {
            List<int> list = new();
            // i <= Math.Sqrt(n) => i * i <= n => sqrt is nothing but (i * i) / 2
            //O(sqrt(n))
            for (int i = 1; i * i <= n; i++)
            {
                if(n % i == 0)
                {
                    list.Add(i);
                    if(n / i != i)
                    {
                        list.Add(n / i);
                    }
                }
            }
            // O(nLogn)
            list.Sort();

            // O(n)
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write("{0} ", list[i]);
            }

            //total = O(sqrt(n)) + O(nlogn) + O(n)
        }
        /// <summary>
        /// Main intuition here is n % i == 0 then only its a divisor ,while counting the divisors if > 2 then not prime
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPrime(int n)
        {
            int count = 0;

            for(int i = 1; i * i <= n; i++)
            {
                if(n % i == 0)
                {
                    count++;
                    if (n / i != i)
                        count++;
                }
            }
            return count <= 2;
        }
        /// <summary>
        /// same formula to get gcd is getting divisors and manipulate
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public int GetGcdHcf(int n1, int n2)
        {
            int gcd = 1;
            for(int i = 1; i <= Math.Min(n1, n2); i++)
            {
                if(n1 % i == 0 && n2 % i == 0)
                {
                    gcd = i;
                }
            }
            return gcd;
        }
        /// <summary>
        /// According to this algorithm gcd(n1, n2) = gcd(n1 - n2, n2) => n1 > n2
        /// To simplify this gcd(n1, n2) = gcd(n1 % n2, n2) => n1 > n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public int EuclideanAlgoGetGcdHcf(int n1, int n2)
        {
            while(n1 > 0 && n2 > 0)
            {
                if (n1 > n2)
                    n1 = n1 % n2;
                else
                    n2 %= n1;
            }
            if (n1 == 0)
                return n2;
            return n1;
        }
    }
}
