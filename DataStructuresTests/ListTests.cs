using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System.Diagnostics;
using System;

namespace DataStructures.Tests
{
    [TestClass()]
    public class ListTests
    {
        [TestMethod()]
        public void ListTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);

            for (int i = 0; i < list.Count; i++)
            {
                Debug.WriteLine(list.Get(i));
            }
            Debug.WriteLine("");
            list.Remove(3);
            for (int i = 0; i < list.Count; i++)
            {
                Debug.WriteLine(list.Get(i));
            }
        }

        [TestMethod()]
        public void StackTest()
        {
            Stack<int> stack = new();
            stack.Push(123542);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Debug.WriteLine(stack.CheckIfPalindrom(0));
        }

        [TestMethod()]
        public void QueueTest()
        {
            Queue<int> queue = new();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Peek());
        }

        [TestMethod()]
        public void LinkedListTest()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            
            //binaryTree.Insert(2);
            //binaryTree.Insert(-1);
            //binaryTree.Insert(1);
            //binaryTree.Insert(21);
            //binaryTree.Insert(55);
            //binaryTree.Insert(23);
            //binaryTree.Insert(21);
            //binaryTree.Insert(25);
            //binaryTree.Insert(71);

            List<int> list = new();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                list.Add(rnd.Next(1, 100));
            }

            binaryTree.InsertMany(list);

            Debug.WriteLine(binaryTree.GetHeight(binaryTree.Root));

        }

        [TestMethod()]
        public void MinHeapTest()
        {
            MinHeap<int> minHeap = new();
        }
    }
}