namespace StriverA2Z_DSA_Course.Basics
{
    public class Patterns
    {
        public void PrintPatterns(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintPatterns2(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintPatterns3(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < n - i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void PrintNumbers(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
        public void PrintNumbers2(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
        }
        public void PrintNumbers3(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i + 1; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
}
