using System.Reflection;

namespace StriverA2Z_DSA_Course
{
    public static class DSARunner
    {
        private static readonly string RootNamespace = typeof(DSARunner).Namespace!.Split('.')[0];
        private const int PromptInterval = 5;

        public static void Run()
        {
            var dsaTypes = DsaClasses();

            while (true)
            {
                var selectedType = SelectClass(dsaTypes);
                if (selectedType == null) break;

                ExploreClass(selectedType);
            }

            Console.WriteLine("\n👋 Exiting DSA Helper. Happy coding!");
        }

        /// <summary>
        /// Get all the classes present related to DSA
        /// </summary>
        /// <returns></returns>
        private static List<Type> DsaClasses()
        {
            var list = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    t.IsClass &&
                    t.Namespace != null &&
                    t.Namespace.StartsWith(RootNamespace) &&
                    t.Name != nameof(DSARunner) &&
                    t.Name != nameof(InputHelper) &&
                    !t.Name.StartsWith("<") &&
                    !t.IsDefined(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), false))
                .ToList();

            return list;
        }

        /// <summary>
        /// Select particular class upon user selection
        /// </summary>
        /// <param name="dsaTypes"></param>
        /// <returns></returns>
        private static Type? SelectClass(List<Type> dsaTypes)
        {
            Console.WriteLine("\n📚 Available DSA Classes:");
            for (int i = 0; i < dsaTypes.Count; i++)
            {
                Console.WriteLine($"  [{i}] {dsaTypes[i].Name}");
            }

            Console.Write("🔍 Enter class index to explore (or 'x' to exit): ");
            var input = Console.ReadLine()!;
            if (input.ToLower() == "x") return null;

            if (!int.TryParse(input, out int index) || index < 0 || index >= dsaTypes.Count)
            {
                Console.WriteLine("❌ Invalid class index.");
                return null;
            }

            return dsaTypes[index];
        }

        /// <summary>
        /// Get all the public methods present in user selected class
        /// </summary>
        /// <param name="selectedType"></param>
        private static void ExploreClass(Type selectedType)
        {
            var instance = Activator.CreateInstance(selectedType);
            var methods = selectedType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            MethodInfo? currentMethod = null;

            while (true)
            {
                if (currentMethod == null)
                {
                    currentMethod = SelectMethod(selectedType, methods);
                    if (currentMethod == null) break;

                    RunMethod(currentMethod, instance);

                    Console.Write("\n🔁 Do you want to run this method again? (y/n): ");
                    var repeat = Console.ReadLine()!;
                    if (repeat.ToLower() != "y")
                    {
                        currentMethod = null;
                        continue;
                    }
                }

                RunMethodLoop(currentMethod, instance);

                Console.Write("\n📌 Run another method in this class? (y/n): ");
                var another = Console.ReadLine()!;
                if (another.ToLower() != "y") break;

                currentMethod = null;
            }
        }

        /// <summary>
        /// Select particular method upon user selection
        /// </summary>
        /// <param name="selectedType"></param>
        /// <param name="methods"></param>
        /// <returns></returns>
        private static MethodInfo? SelectMethod(Type selectedType, MethodInfo[] methods)
        {
            Console.WriteLine($"\n🧠 Methods in {selectedType.Name}:");
            for (int i = 0; i < methods.Length; i++)
            {
                var paramList = string.Join(", ", methods[i].GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                Console.WriteLine($"  [{i}] {methods[i].Name}({paramList})");
            }

            Console.Write("🔍 Enter method index to run (or 'b' to go back): ");
            var input = Console.ReadLine()!;
            if (input.ToLower() == "b") return null;

            if (!int.TryParse(input, out int index) || index < 0 || index >= methods.Length)
            {
                Console.WriteLine("❌ Invalid method index.");
                return null;
            }

            return methods[index];
        }

        /// <summary>
        /// Run the DSA method multiple times (5)
        /// </summary>
        /// <param name="method"></param>
        /// <param name="instance"></param>
        private static void RunMethodLoop(MethodInfo method, object instance)
        {
            int repeatCount = 0;

            while (true)
            {
                bool success = RunMethod(method, instance);
                if (!success) break;

                repeatCount++;
                if (repeatCount % PromptInterval == 0)
                {
                    Console.Write("\n🔁 Run same method again? (y/n): ");
                    var again = Console.ReadLine()!;
                    if (again.ToLower() != "y") break;
                }
            }
        }

        /// <summary>
        /// Run the DSA method single time
        /// </summary>
        /// <param name="method"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        private static bool RunMethod(MethodInfo method, object instance)
        {
            Console.WriteLine($"\n→ Running: {method.Name}");

            var parameters = method.GetParameters();
            object[] args = new object[parameters.Length];

            try
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"   Enter value for '{parameters[i].Name}' ({parameters[i].ParameterType.Name}) [type 'x' to cancel]: ");
                    args[i] = InputHelper.ReadUserInput(parameters[i].ParameterType);
                }

                var result = method.Invoke(instance, args);
                if (method.ReturnType != typeof(void))
                    Console.WriteLine($"   ✅ {method.Name} returned: {FormatResult(result)}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("⏹️ Exiting method early by user request.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ❌ {method.Name} threw an exception: {ex.Message}");
                return false;
            }
            return true;
        }

        private static string FormatResult(object result)
        {
            if (result == null) return "null";

            // Handle List<List<int>>
            if (result is IEnumerable<IEnumerable<object>> nested)
            {
                return "[" + string.Join(", ", nested.Select(inner => "[" + string.Join(", ", inner) + "]")) + "]";
            }

            // Handle List<List<int>> (strongly typed)
            if (result is IEnumerable<IEnumerable<int>> nestedInt)
            {
                return "[" + string.Join(", ", nestedInt.Select(inner => "[" + string.Join(", ", inner) + "]")) + "]";
            }

            // Handle List<int>, int[], string[], etc.
            if (result is IEnumerable<object> flat)
            {
                return "[" + string.Join(", ", flat) + "]";
            }

            if (result is IEnumerable<int> flatInt)
            {
                return "[" + string.Join(", ", flatInt) + "]";
            }

            if (result is IEnumerable<string> flatStr)
            {
                return "[" + string.Join(", ", flatStr) + "]";
            }

            // Fallback
            return result.ToString()!;
        }

    }
}
