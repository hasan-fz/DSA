using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Sort
    {
        internal static void Begin()
        {
            int[] arr = new int[] { 0, 3, 45, 7, 2, 0, 8, 9, 10, 4, 1, 0, 5, 3 };
            char choice = 'n';
            do
            {
                Console.WriteLine("Pick your choice:\n1: Insertion Sort\n2: Selection Sort\n3: Bubble Sort\n4: Merge Sort\n5: Quick Sort\n");
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        InsertionSort(arr);
                        Console.WriteLine();
                        break;
                    case '2':
                        SelectionSort(arr);
                        Console.WriteLine();
                        break;
                    case '3':
                        BubbleSort(arr);
                        Console.WriteLine();
                        break;
                    case '4':
                        MergeSort(arr);
                        Console.WriteLine();
                        break;
                    case '5':
                        QuickSort(arr);
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press 'n' to exit.\n");
                choice = char.ToLower(Console.ReadKey(true).KeyChar);
            } while (choice != 'n');
            
        }
        internal static void InsertionSort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                for(int j = i; j > 0 && arr[j] < arr[j - 1]; j--)
                {
                    swap(arr, j, j - 1);
                }
            }
            Console.WriteLine("Sorted Array: " + string.Join(", ", arr));
        }
        internal static void SelectionSort(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                int currMin = i;
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[currMin])
                        currMin = j;
                }
                swap(arr, i, currMin);
            }
            Console.WriteLine("Sorted Array: " + string.Join(", ", arr));
        }
        internal static void BubbleSort(int[]arr)
        {
            for (int i = 1; i != arr.Length; i++)
            {
                int swapflag = 0;
                for(int j = 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        swap(arr, j, j - 1);
                        swapflag = 1;
                    }
                }
                if (swapflag == 0)
                    break;
            }
            Console.WriteLine("Sorted Array: " + string.Join(", ", arr));
        }
        internal static void MergeSort(int[] arr)
        {
            Divide(arr, 0, arr.Length - 1);
            Console.WriteLine("Sorted Array: " + string.Join(", ", arr));
        }
        internal static void QuickSort(int[] arr)
        {
            QuickSortMain(arr, 0, arr.Length - 1);
            Console.WriteLine("Sorted Array: " + string.Join(", ", arr));
        }
        static void QuickSortMain(int[] arr, int start, int end)
        {
            if (start >= end)
                return;
            else if ((end - start) < 2)
            {
                if(arr[start] > arr[end])
                    swap(arr, start, end);
                return;
            }
            else
            {
                int pivot = FindPivot(arr, start, end);
                swap(arr, pivot, end);
                int l = start;
                int r = end - 1;
                while (l < r)
                {
                    while (l < end && arr[l] <= arr[end])
                        l++;
                    while (r > start && arr[r] >= arr[end])
                        r--;
                    if (l < r)
                        swap(arr, l, r);
                }
                swap(arr, l, end);
                QuickSortMain(arr, start, l - 1);
                QuickSortMain(arr, l + 1, end);
            }  
        }
        static int FindPivot(int[] arr, int start, int end)
        {
            int median = (start + end) / 2;
            int[] temp = new int[3];

            temp[0] = arr[start];
            temp[1] = arr[median];
            temp[2] = arr[end];
            Array.Sort(temp);
            if (temp[1] == arr[median])
                return median;
            else if (temp[1] == arr[start])
                return start;
            else
                return end;
        }
        static void Divide(int[] arr, int start, int end)
        {
            if(end == start)
                return;
            Divide(arr, start, start + (end - start) / 2);
            Divide(arr, start + (end - start) / 2 + 1, end);
            Merge(arr, start, end);    
        }
        static void Merge(int[] arr, int start, int end)
        {
            int median = start + (end - start) / 2;
            int i = 0, j = 0, k = 0;
            int[] leftArr = new int[median - start + 1];
            int[] rightArr = new int[end - median];

            for (i = 0; i < leftArr.Length; i++)
            {
                leftArr[i] = arr[start + i];
            }
            for (i = 0; i < rightArr.Length; i++)
            {
                rightArr[i] = arr[median + i + 1];
            }
            for (i = 0, j = 0, k = 0; i < leftArr.Length && j < rightArr.Length; k++)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[start + k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[start + k] = rightArr[j];
                    j++;
                }
            }
            while(i < leftArr.Length)
            {
                arr[start + k] = leftArr[i];
                i++;
                k++;
            }
            while (j < rightArr.Length)
            {
                arr[start + k] = rightArr[j];
                j++;
                k++;
            }
        }
        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}