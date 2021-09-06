using System;

namespace Extras
{
    public class ExtrasClass
    {
        public static int[] Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
            return arr;
        }

        public static int[] MakeRandomArray(int length, int largestValue)
        {
            int[] randomArray = new int[length];
            Random rnd = new();
            for (int i = 0; i < length; i++)
            {
                randomArray[i] = rnd.Next(0, largestValue);
            }
            return randomArray;
        }
    }
}
