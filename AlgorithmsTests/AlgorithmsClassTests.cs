using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms.Tests
{
    [TestClass()]
    public class AlgorithmsClassTests
    {
        //[TestMethod()]
        //public void LinearSearchTest()
        //{
        //    int[] arr = new int[1_000_000_000];
        //    for (int i = 0; i < 1_000_000_000; i++)
        //    {
        //        arr[i] = i + 1;
        //    }

        //    Stopwatch stopwatch = new();
        //    stopwatch.Start();

        //    int actual = AlgorithmsClass.LinearSearch(arr, 1000000000);

        //    stopwatch.Stop();
        //    Debug.WriteLine(stopwatch.ElapsedTicks);

        //    Assert.AreEqual(9, actual, "Forkert");
        //}

        //[TestMethod()]
        //public void BinarySearchTest()
        //{
        //    int[] arr = new int[1_000_000_000];
        //    for (int i = 0; i < 1_000_000_000; i++)
        //    {
        //        arr[i] = i + 1;
        //    }

        //    Stopwatch stopwatch = new();
        //    stopwatch.Start();

        //    int actual = AlgorithmsClass.BinarySearch(arr, 1000000000);

        //    stopwatch.Stop();
        //    Debug.WriteLine(stopwatch.ElapsedTicks);

        //    Assert.AreEqual(9, actual, "Forkert");
        //}

        //[TestMethod()]
        //public void BubbleSortTest()
        //{
        //    int[] myArray = ExtrasClass.MakeRandomArray(10, 10);
        //    myArray = AlgorithmsClass.BubbleSort(myArray);
        //}

        //[TestMethod()]
        //public void InsertionSortTest()
        //{
        //    Stopwatch stopwatch = new();
        //    int[] myArray = ExtrasClass.MakeRandomArray(10, 100);
        //    stopwatch.Start();
        //    myArray = AlgorithmsClass.InsertionSort(myArray);
        //    stopwatch.Stop();
        //    Debug.WriteLine(stopwatch.ElapsedTicks);
        //}

        [TestMethod()]
        public void SelectionSortTest()
        {
            Stopwatch stopwatch = new();
            int[] myArray = ExtrasClass.MakeRandomArray(10, 10);

            stopwatch.Start();
            myArray = AlgorithmsClass.SelectionSort(myArray);
            stopwatch.Stop();
            Debug.WriteLine(stopwatch.ElapsedTicks);
        }

        [TestMethod()]
        public void QuickSortTest()
        {
            Stopwatch stopwatch = new();
            int[] myArray = ExtrasClass.MakeRandomArray(10, 10);
            foreach (var item in myArray)
            {
                Debug.WriteLine(item);
            }
            myArray = AlgorithmsClass.QuickSort(myArray, 0, myArray.Length - 1);
            Debug.WriteLine("");
            foreach (var item in myArray)
            {
                Debug.WriteLine(item);
            }
        }

        [TestMethod()]
        public void MergeSortTest()
        {
            int nubmer = 10;
            Stopwatch stopwatch = new();
            int[] myArray = ExtrasClass.MakeRandomArray(nubmer, nubmer);

            stopwatch.Start();
            myArray = AlgorithmsClass.MergeSort(myArray);
            stopwatch.Stop();
            Debug.WriteLine(stopwatch.ElapsedTicks);
        }

        [TestMethod()]
        public void HybridSortTest()
        {
            int number = 10;
            int[] arr = ExtrasClass.MakeRandomArray(number, number);

            Stopwatch stopwatch = new();
            stopwatch.Start();
            arr = AlgorithmsClass.Hybrid(arr);
            stopwatch.Stop();
            Debug.WriteLine(stopwatch.ElapsedTicks);
        }

        [TestMethod()]
        public void TestArraySort()
        {
            int number = 1_000_000_000;
            int[] arr = ExtrasClass.MakeRandomArray(number, number);

            Stopwatch stopwatch = new();
            stopwatch.Start();
            Array.Sort(arr);
            stopwatch.Stop();
            Debug.WriteLine(stopwatch.ElapsedTicks);
        }
    }
}