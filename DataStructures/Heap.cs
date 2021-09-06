using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HeapNode<T>
    {
        private T data;
        private HeapNode<T> parent, leftChild, rightChild;

        public T Data { get => data; set => data = value; }
        public HeapNode<T> Parent { get => parent; set => parent = value; }
        public HeapNode<T> LeftChild { get => leftChild; set => leftChild = value; }
        public HeapNode<T> RightChild { get => rightChild; set => rightChild = value; }

        public HeapNode() { }

    }
    public class Heap<T>
    {
        private int maxRowChild;
        private int currentRowChild;
        private int row;
        private HeapNode<T> root = new();

        public int MaxRowChild { get => maxRowChild; set => maxRowChild = value; }
        public int CurrentRowChild { get => currentRowChild; set => currentRowChild = value; }
        public HeapNode<T> Root { get => root; set => root = value; }
        public int Row { get => row; set => row = value; }

        public Heap()
        {
            Row = 1;
            MaxRowChild = 1;
            CurrentRowChild = 1;
        }

        public void Insert(T item)
        {
            if (Root.Data.Equals(null))
            {
                Root.Data = item;
            }
            else
            {

            }
        }
    }
}
