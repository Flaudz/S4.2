using System;
using System.Collections;

namespace DataStructures
{
    public abstract class LinearDataStructe<T>
    {
        private T[] array = new T[0];
        protected int length;
        protected int count;

        public int Count { get => count; set => count = value; }
        protected LinearDataStructe()
        {

        }

        protected LinearDataStructe(int initialLength)
        {
            length = initialLength;
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.array[index1];
            this.array[index1] = this.array[index2];
            this.array[index2] = temp;
        }

        public void Insert(T data)
        {
            this.array[array.Length - 1] = data;
        }

        public T GetItem(int index)
        {
            return this.array[index];
        }

        // ResizeTo List Method
        public void ResizeTo(int newLength)
        {
            T[] newArr = new T[newLength];
            if (newLength < this.Count)
            {

                for (int i = 0; i < newLength; i++)
                {
                    newArr[i] = this.array[i];
                }

                this.count = newLength;

            }
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    newArr[i] = this.array[i];
                }
            }
            this.length = newLength;
            this.array = newArr;
        }

        // ResizeTo List Method
        public void ResizeStart(int newLength)
        {
            T[] newArr = new T[newLength];
            if (newLength < this.Count)
            {

                for (int i = 1; i < newLength+1; i++)
                {
                    newArr[i-1] = this.array[i];
                }

                this.count = newLength;

            }
            else
            {
                for (int i = 1; i < this.Count+1; i++)
                {
                    newArr[i-1] = this.array[i];
                }
            }
            this.length = newLength;
            this.array = newArr;
        }
        // Backwards method
        public void Backwards()
        {
            T[] newArr = new T[this.Count];
            int j = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                newArr[j] = this.array[i];
                j++;
            }
            this.array = newArr;
        }
    }

    public class List<T> : LinearDataStructe<T>
    {
        public List()
        {

        }

        public void Add(T item)
        {
            base.ResizeTo(base.length + 1);
            base.Insert(item);
            base.Count++;
        }

        // Get List Method
        public T Get(int index)
        {
            return base.GetItem(index);
        }

        // Remove List Method
        public void Remove(int index)
        {
            for (int i = index; i < base.Count-1; i++)
            {
                base.Swap(i, i + 1);
            }
            base.ResizeTo(base.Count - 1);
        }

        public IEnumerator GetEnumerator()
        {
            int index = 0;
            T current = this.Get(index);
            
            while (index != this.length)
            {
                yield return current;
                current = this.Get(index);
                index++;
            }
        }
    }

    public class Stack<T> : LinearDataStructe<T>
    {
        public void Push(T item)
        {
            base.ResizeTo(base.length + 1);
            base.Insert(item);
            base.Count++;
        }

        public T ElementAt(int index)
        {
            return base.GetItem(index);
        }

        public T Pop()
        {
            T element = this.ElementAt(this.Count - 1);
            this.ResizeTo(base.Count - 1);
            return element;
        }

        public bool CheckIfPalindrom(int index)
        {
            if (this.ElementAt(index) is string)
            {
                string backString = "";
                string oldString = this.ElementAt(index).ToString();
                for (int i = oldString.Length; i > 0; i--)
                {
                    backString += oldString[i - 1];
                }
                if (backString == oldString)
                    return true;
            }
            return false;
        }

    }

    public class Queue<T> : LinearDataStructe<T>
    {
        public void Enqueue(T item)
        {
            this.ResizeTo(base.length + 1);
            base.Insert(item);
            base.Count++;
        }

        public T Dequeue()
        {
            T element = this.Peek();
            base.ResizeStart(base.Count - 1);
            return element;
        }

        public T Peek()
        {
            return base.GetItem(0);
        }
    }

    public class LinkedListNode<T>
    {
        private LinkedListNode<T> next;
        private T data;

        public LinkedListNode<T> Next { get => next; set => next = value; }
        public T Data { get => data; set => data = value; }

        public LinkedListNode()
        {
            Next = null;
        }
        public LinkedListNode(T value)
        {
            Data = value;
        }
    }

    public class LinkedList<T>
    {
        private int length;
        private LinkedListNode<T> head = new();
        public LinkedListNode<T> Head { get => head; set => head = value; }
        public int Length { get => length; set => length = value; }

        public LinkedList()
        {
            Head.Next = null;
        }

        public void AddLast(LinkedListNode<T> LinkedListNode)
        {
            if (this.Head.Next == null)
                Head.Next = LinkedListNode;
            else
            {
                LinkedListNode<T> Temp = Head.Next;
                bool NoNull = true;
                while (NoNull)
                {
                    if (Temp.Next == null)
                    {
                        Temp.Next = LinkedListNode;
                        NoNull = false;
                    }
                    else
                    {
                        Temp = Temp.Next;
                    }
                }
            }
            this.Length++;
        }

        public void AddFirst(LinkedListNode<T> LinkedListNode)
        {
            LinkedListNode.Next = Head.Next;
            Head.Next = LinkedListNode;
            this.Length++;
        }

        public bool Contains(T value)
        {
            bool ContainsBool = false;
            LinkedListNode<T> temp = Head.Next;
            while(!temp.Data.Equals(null))
            {
                if (temp.Data.Equals(value))
                {
                    ContainsBool = true;
                    break;
                }
                else
                {
                    if (temp.Next != null)
                    {

                        temp = temp.Next;
                    }
                    else
                        break;
                }
            }
            return ContainsBool;
        }

        public LinkedListNode<T> Find(T data)
        {
            LinkedListNode<T> temp = Head;
            LinkedListNode<int> failedLinkedListNode = new(-1);
            bool found = true;
            while (found)
            {
                if (temp.Next is null)
                {
                    break;
                }
                if(temp.Next.Data.Equals(data))
                {
                    return temp.Next;
                }
                else
                {
                    temp = temp.Next;
                }
            }
            return (LinkedListNode<T>)Convert.ChangeType(failedLinkedListNode, typeof(LinkedListNode<T>));
        }
        
        public LinkedListNode<T> FindLast(T value)
        {
            LinkedListNode<T> currentLinkedListNode = Head.Next;
            LinkedListNode<T> foundLinkedListNode = Head;
            LinkedListNode<int> failedLinkedListNode = new(-1);
            while(currentLinkedListNode.Next is null == false)
            {
                if (currentLinkedListNode.Data.Equals(value))
                {
                    foundLinkedListNode = currentLinkedListNode;
                }
                currentLinkedListNode = currentLinkedListNode.Next;
            }
            if(foundLinkedListNode != Head)
            {
                return foundLinkedListNode;
            }
            return (LinkedListNode<T>)Convert.ChangeType(failedLinkedListNode, typeof(LinkedListNode<T>));
        }

        public void Remove(LinkedListNode<T> LinkedListNode)
        {
            LinkedListNode<T> currentLinkedListNode = Head;
            while (currentLinkedListNode.Next is null == false)
            {
                if(currentLinkedListNode.Next == LinkedListNode)
                {
                    currentLinkedListNode.Next = LinkedListNode.Next;
                    Length--;
                    break;
                }
                else
                {
                    currentLinkedListNode = currentLinkedListNode.Next;
                }
            }
        }

        public T this[int i]
        {
            get
            {
                i++;
                int index = 0;
                LinkedListNode<T> temp = Head;
                while(temp.Next != null)
                {
                    if(index == i)
                    {
                        if(temp.Data != null)
                        {
                            return (T)temp.Data;
                        }
                    }
                    temp = temp.Next;
                    index++;
                }
                return (T)temp.Data;
            }
            set
            {
                i++;
                int index = 0;
                LinkedListNode<T> temp = Head;
                while(temp.Next != null)
                {
                    if(index == i)
                    {
                        temp.Data = value;
                    }
                    temp = temp.Next;
                    index++;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            LinkedListNode<T> current = Head.Next;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }

}
