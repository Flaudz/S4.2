using System;
using DataStructures;

namespace LinkedList
{
    public class LinkedList<T> : LinearDataStructe<T>
    {
        internal class Node
        {
            internal T data;
            internal Node next;
            public Node(T d)
            {
                data = d;
                next = null;
            }
        }

    }

}
