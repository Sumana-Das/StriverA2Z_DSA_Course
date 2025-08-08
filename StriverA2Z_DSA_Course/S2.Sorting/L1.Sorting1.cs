using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriverA2Z_DSA_Course.S2.Sorting
{
    public class Sorting1
    {
        /// <summary>
        /// It selects the minimum and place it at the front
        /// this keeps going on until the array is sorted
        /// </summary>
        /// <param name="arr"></param>
        public void SelectionSort(int[] arr)
        {
            for(int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[min] > arr[j])
                    {
                        min = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
            Console.WriteLine("The sorted array is:");
            foreach(int item in arr)
            {
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// It compares and does adjacent swapping and pushes the large element to the last
        /// </summary>
        /// <param name="arr"></param>
        public void BubbleSort(int[] arr)
        {
            bool isSorted = true;
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        isSorted = false;
                    }
                }
                if (isSorted)
                    break;
                Console.WriteLine($"step {i}");
            }
            Console.WriteLine("The sorted array is:");
            foreach (int item in arr)
            {
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// It checks for the min value and put it in the correct place
        /// </summary>
        /// <param name="arr"></param>
        public void InsertionSort(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            Console.WriteLine("The sorted array is:");
            foreach (int item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
