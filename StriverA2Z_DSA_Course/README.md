# Striver A2Z Sheet Problems Solutions Interactive CLI (C# Language)

This project is a **console-based interactive tool** built in C# to help me learn, test, and master the [Strivers A2Z DSA Course](https://takeuforward.org/strivers-a2z-dsa-course/strivers-a2z-dsa-course-sheet-2) — a curated set of 450+ Data Structures & Algorithms problems for software engineering interviews.

Instead of solving problems in isolation, I built this CLI to:

- Organize solutions by topic
- Run any method interactively with custom inputs
- Repeat tests with smart prompts
- View clean, formatted outputs for arrays, lists, and nested structures
- Exit or switch methods mid-loop
- Scale across folders and namespaces as I progress

This is my **mini project** to demonstrate not just problem-solving, but also:

- Backend design
- CLI tooling
- Reflection and dynamic execution
- Usability and discoverability
- Automation of developer workflows

---

## 🚀 How It Works

1. Launch the CLI
2. Select a topic (e.g., Recursion, Arrays, DP)
3. Choose a method (e.g., `IsPalindrome`, `MergeSort`)
4. Enter inputs interactively
5. View results instantly
6. Repeat or switch methods as needed

---

## 🧠 Features

- ✅ Dynamic class discovery across folders
- ✅ Interactive method selection and input prompts
- ✅ Smart looping with periodic confirmation
- ✅ Mid-loop exit (`x` to cancel)
- ✅ Pretty-printing for complex return types
- ✅ Modular architecture for easy extension
- ✅ Clean separation of logic (`DSARunner`, `InputHelper`, etc.)

> ⚠️ **Note:** This project is a work in progress. I'm actively implementing and testing solutions from the [Striver SDE Sheet](https://takeuforward.org/interviews/strivers-sde-sheet-top-coding-interview-questions/). New problems will be added regularly.  
> 📌 Track my progress in the [Pinned Issue Tracker](https://github.com/your-username/your-repo/issues/1)

---

## 🗂️ Topics & Classes

| Topic         | Class Name       | Path                                      |
|---------------|------------------|-------------------------------------------|
| Basics        | `BasicMaths`     | [`/Basics/BasicMaths.cs`](./Basics/BasicMaths.cs) |
| Recursion     | `Recursion`      | [`/Basics/Recursion.cs`](./Basics/Recursion.cs)    |
| Patterns      | `Patterns`       | [`/Basics/Patterns.cs`](./Basics/Patterns.cs)      |
| Arrays        | `ArrayProblems`  | [`/Arrays/ArrayProblems.cs`](./Arrays/ArrayProblems.cs) *(example)*
| Sorting       | `SortingUtils`   | [`/Sorting/SortingUtils.cs`](./Sorting/SortingUtils.cs) *(example)*
| Dynamic Prog. | `DPProblems`     | [`/DP/DPProblems.cs`](./DP/DPProblems.cs) *(example)*

> Each class contains public methods that solve one or more problems from the [Strivers A2Z DSA Course](https://takeuforward.org/strivers-a2z-dsa-course/strivers-a2z-dsa-course-sheet-2)

---

## 🧪 Sample Flow

```plaintext
Available DSA Classes:
  [0] Recursion
  [1] ArrayProblems
Enter class index to explore: 0

Methods in Recursion:
  [0] IsPalindrome(String s)
Enter method index to run: 0

→ Running: IsPalindrome
   Enter value for 's' (String) [type 'x' to cancel]: madam
   [OK] IsPalindrome returned: True

🔁 Do you want to run this method again? (y/n): y
```

## 🛠️ How to Extend
This CLI is designed to be plug-and-play for anyone learning DSA or building their own problem sets.

Add new classes under topic folders (e.g., /Graphs, /Stacks)

Write your own methods using public instance signatures

Modify existing methods to experiment with logic or edge cases

No need to register or configure anything — just run the app and your changes will appear automatically

Return types like List<int>, List<List<int>>, int[], etc. are auto-formatted for readability

Add XML comments for method summaries (optional)

## 🤝 For Contributors & Learners
Whether you're solving the Striver SDE Sheet or building your own problem bank, this tool is built to support your workflow:

✅ Just drop your class into the appropriate folder

✅ Write public methods with meaningful names

✅ Run the CLI and see your methods instantly

✅ Test interactively with custom inputs

✅ Repeat, refine, and debug without boilerplate

No config files. No registration. Just code, run, and learn.

## 🧩 Starter Template
Here’s a sample class you can copy to add your own problems:

```
namespace StriverA2Z_DSA_Course.Graphs
{
    public class TemplateProblem
    {
        public void SampleMethod(int n)
        {
            Console.WriteLine($"You passed: {n}");
        }

        public List<int> ReturnList(int[] arr)
        {
            return arr.ToList();
        }
    }
}
```
Just place it in the appropriate folder (e.g., /Graphs) and run the CLI — your methods will appear automatically.

## 📌 Learning Outcomes
Deepened understanding of DSA through implementation and testing

Applied reflection and dynamic method invocation in C#

Designed a modular CLI with usability-first principles

Automated repetitive testing and input workflows

Built a scalable structure for long-term learning and contribution

## 👩‍💻 Author
Created by **Sumana Das** — a backend engineer with a strong foundation in scalable system design, reliability, and technical leadership. Sumana has led architecture-heavy initiatives focused on usability, performance, and long-term maintainability. She’s passionate about building tools and systems that empower engineers, reduce friction, and make invisible work visible. This project reflects her approach to engineering: thoughtful, user-centric, and built for impact at scale.