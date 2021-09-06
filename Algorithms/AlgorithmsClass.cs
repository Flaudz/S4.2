using System;
using Extras;

namespace Algorithms
{
    public class AlgorithmsClass
    {
        // Search Algorithms
        public static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                if(i != arr.Length - 1)
                {
                    if(arr[i] > arr[i + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static int BinarySearch(int[] arr, int value)
        {
                int left = 0;
                int right = arr.Length - 1;
                int mid;

                while(left < right)
                {
                    mid = (left + right) / 2;

                    if(value > arr[mid])
                    {
                        left = mid + 1;
                    }

                    else
                    {
                        right = mid;
                    }

                }

                if (arr[left] == value)
                {
                    int initinalMatch = left;
                    while(arr[initinalMatch] == value)
                    {
                        if(initinalMatch == arr.Length - 1)
                        {
                            return initinalMatch;
                        }
                        else
                        {
                            initinalMatch++;
                        }
                    }
                    return initinalMatch-1;
                }
                else
                    return -1;
        }

        public static int BinarySearchLeft(int[] arr, int value)
        {
            int left = 0;
            int right = arr.Length - 1;
            int mid;

            while (left < right)
            {
                mid = (left + right) / 2;

                if (value > arr[mid])
                {
                    left = mid + 1;
                }

                else
                {
                    right = mid;
                }

            }

            if (arr[left] == value)
            {
                return left;
            }
            else
                return -1;
        }

        public static int LinearSearch(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }


        // Sorting Algorithms
        public static int[] BubbleSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = arr.Length-1; j >= i; j--)
                {
                    if (arr[j] < arr[j - 1])
                        arr = ExtrasClass.Swap(arr, j, j - 1);
                }
            }
            return arr;
        }

        public static int[] InsertionSort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                for(int j = i; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        arr = ExtrasClass.Swap(arr, j, j - 1);
                    }
                    else
                        break;
                }
            }
            return arr;
        }

        public static int[] SelectionSort(int[] arr)
        {
            for(int i = 0; i < arr.Length-1; i++)
            {
                int k = i;
                for(int j = i+1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[k])
                    {
                        k = j;
                    }
                }
                ExtrasClass.Swap(arr, i, k);
            }
            return arr;
        }

        public static int[] QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
                return arr;

            int index = Partition(arr, start, end);

            arr = QuickSort(arr, start, index - 1);

            arr = QuickSort(arr, index + 1, end);

            return arr;
        }

        private static int Partition(int[] arr, int start, int end)
        {

            // start = 0, end = arr.length-1
            int pivotIndex = start; // pivotIndex = 0

            int pivotValue = arr[end]; // pivotValue = slut af arrayet

            for (int i = start; i < end; i++)
            {
                // i = 0
                if(arr[i] < pivotValue) // Hvis arr[i] er mindere end slutning
                {
                    arr = ExtrasClass.Swap(arr, i, pivotIndex); // skal arr[i] bytte med arr[0]

                    pivotIndex++; // pivotIndex går fra 0 til 1
                }
            }

            ExtrasClass.Swap(arr, pivotIndex, end);

            return pivotIndex;
        }

        public static int[] MergeSort(int[] arr)
        {
            int[] left;
            int[] right;
            int[] result = new int[arr.Length];

            if (arr.Length <= 1)
                return arr;

            int midPoint = arr.Length / 2;

            left = new int[midPoint];


            if (arr.Length % 2 == 0)
                right = new int[midPoint];
            else
                right = new int[midPoint + 1];

            for (int i = 0; i < midPoint; i++)
                left[i] = arr[i];

            int x = 0;

            for (int i = midPoint; i < arr.Length; i++)
            {
                right[x] = arr[i];
                x++;
            }

            left = MergeSort(left);
            right = MergeSort(right);

            result = Merge(left, right);
            return result;

        }

        private static int[] Merge(int[] left, int[] right)
        {
            int resultLenght = right.Length + left.Length;
            int[] result = new int[resultLenght];

            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while(indexLeft < left.Length || indexRight < right.Length)
            {
                // If both arrays have elements
                if(indexLeft < left.Length && indexRight < right.Length)
                {
                    // If item on left array is less than item on right array, add that
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }

                else if( indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if(indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        public static int[] HybridSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i-1] > arr[i])
                {
                    arr = ExtrasClass.Swap(arr, i, i - 1);
                    if(i != 1)
                    {
                        i -= 2;
                    }
                }
            }
            return arr;
        }

        public static int[] Hybrid(int[] arr)
        {
            if (arr.Length >= 10)
                SelectionSort(arr);
            else if (arr.Length >= 100 && arr.Length < 1_000)
                InsertionSort(arr);
            else if (arr.Length >= 1_000)
                QuickSort(arr, 0, arr.Length - 1);
            return arr;
        }
    }
}
