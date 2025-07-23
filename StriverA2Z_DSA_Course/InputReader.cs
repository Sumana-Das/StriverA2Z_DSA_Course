namespace StriverA2Z_DSA_Course
{
    public static class InputHelper
    {
        public static object ReadUserInput(Type type)
        {
            string input = Console.ReadLine()!;
            if (input.ToLower() == "x") throw new OperationCanceledException("User requested exit.");

            try
            {
                if (type == typeof(int)) return int.Parse(input);
                if (type == typeof(bool)) return bool.Parse(input);
                if (type == typeof(string)) return input;
                if (type == typeof(double)) return double.Parse(input);
                if (type == typeof(List<int>)) return input.Split(',').Select(int.Parse).ToList();
                if (type == typeof(int[])) return input.Split(',').Select(int.Parse).ToArray();
            }
            catch
            {
                Console.WriteLine($"❌ Invalid input for {type.Name}. Using default.");
                return Activator.CreateInstance(type)!;
            }

            return Activator.CreateInstance(type)!;
        }
    }
}
