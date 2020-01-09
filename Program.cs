using System;
using System.Linq;

/* From going through the Wikipedia article
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //             i,j                         pivot
            //             0   1   2   3   4   5   6   7
            int[] argh = { 15, 95, 66, 72, 42, 38, 39, 51 };
                        // 15, 95, 66, 72, 42, 38, 39, 51
                        // 15, 42, 66, 72, 95, 38, 39, 51
                        // 15, 42, 38, 72, 95, 66, 39, 51
                        // 15, 42, 38, 39, 95, 66, 72, 51
                        // 15, 42, 38, 39, 51, 66, 72, 95
                        // ----------------------------------
                        // i j         pivot
                        // 15, 42, 38, 39     i = 0, j = 0
                        // 15, 42, 38, 39     i = 1, j = 1
                        // 15, 38, 42, 39     i = 1, j = 2
                        // 15, 38, 39, 42     i = 2, j = 3, swap pivot with last i
                        // ----------------------------------
                        // ...
                        // ..
                        // .

            //SortLamuto(argh, 0, argh.Count() - 1);
            SortHoare(argh, 0, argh.Count() - 1);

            foreach (var item in argh)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }

        static void Swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        static int PartitionLamuto(int[] arr, int start, int end)
        {
            int pivot = end;
            int i = start;

            for(int j = start; j < end; j++) // both i and j start at index 0
            {
                if (arr[j] <= arr[pivot])    // 15 <= 51 ? yes, so we swap i and j | 95 <= 51 ? no | 66 <= 51 ? no | 72 <= 51 ? no | 42 <= 51 ? yes | 38 <= 51 ? yes | 39 <= 51 ? yes |
                {
                    Swap(arr, j, i);         // 15 <> 15                           |               |               |               | 42 <> 95       | 38 <> 66       | 39 <> 72       |
                    i++;                     // i = 1                              | i = 1         | i = 1         | i = 1         | i = 2          | i = 3          | i = 4          |
                }
            }                                // j = 1                              | j = 2         | j = 3         | j = 4         | j = 5          | j = 6          | j = 7 and stop |
            Swap(arr, i, end);               // i = arr[4], so we swap 95 with 51
            return i;                        // returning index for recurssion
        }

        static int PartitionHoare(int[] arr, int left, int right)
        {
            //               start       pivot           end
            //               0   1   2   3   4   5   6   7
            //int[] argh = { 15, 95, 66, 72, 42, 38, 39, 51 };
            //               15, 51, 66, 72, 42, 38, 39, 95  
            //               15, 51, 66, 
   
            int pivot = left + (right - left) / 2;  // each recurssion will take start and end into consideration

            while (true)
            {
                while(arr[left] < arr[pivot])
                {
                    left++;
                }

                while (arr[right] > arr[pivot])
                {
                    right--;
                }
                
                if (left <= right)
                {
                    Swap(arr, left, right);
                    return right;
                }
            }
        }

        static void SortLamuto(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int index = PartitionLamuto(arr, start, end);
                SortLamuto(arr, start, index - 1);
                SortLamuto(arr, index + 1, end);
            }
        }

        static void SortHoare(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = PartitionHoare(arr, start, end);
                SortHoare(arr, start, pivot);
                SortHoare(arr, pivot + 1, end);
            }
        }

        // First attempt
        //static void Quicky(int[] arr)
        //{
        //    int pivotValue = 0;
        //    int left = 1;
        //    int right = arr.Length - 1;

        //    for (int i = pivotValue; i < right; i++)
        //    {

        //        if (arr[left] > arr[pivotValue])
        //        {
        //            if (arr[right] < arr[pivotValue])
        //            {
        //                int temp = arr[left];
        //                arr[left] = arr[right];
        //                arr[right] = temp;
        //            }
        //        }

        //        else if (arr[left] < arr[pivotValue] && arr[right] > arr[pivotValue]) continue;

        //        left++;
        //        right--;
        //    }

        //    foreach (var item in arr)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
    }

    //               72, 95, 66, 15, 42, 38, 39, 51
    //               72, 51, 66, 15, 42, 38, 39, 95
    //               39, 51, 66, 15, 42, 38, 72, 95
    //               ------------------------------
    //               39, 51, 66, 15, 42, 38
    //               66, 51, 39, 15, 42, 38
    //               38, 51, 39, 15, 42, 66
    //               ----------------------
    //               38     
}
