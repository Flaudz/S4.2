using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    interface INonLinearDataStructure<T>
    {
        int Count { get; set; }
    }

    public class Node<T>
    {
        private T item;

        public T Item { get => item; set => item = value; }

        public Node()
        {

        }

        public Node(T item)
        {
            Item = item;
        }
    }

    public class TreeNode<T> : Node<T>
    {
        private BinaryTreeNode<T> parent;

        public BinaryTreeNode<T> Parent { get => parent; set => parent = value; }

        public TreeNode()
        {

        }

        public TreeNode(T item)
        {
            Item = item;
        }

        public TreeNode(T item, BinaryTreeNode<T> parent)
        {
            Item = item;
            Parent = parent;
        }

        public TreeNode(BinaryTreeNode<T> parent)
        {
            Parent = parent;
        }
    }

    public class BinaryTreeNode<T> : TreeNode<T>
    {
        private BinaryTreeNode<T> leftChild, rightChild;

        public BinaryTreeNode<T> LeftChild { get => leftChild; private set => leftChild = value; }
        public BinaryTreeNode<T> RightChild { get => rightChild; private set => rightChild = value; }

        public BinaryTreeNode()
        {

        }

        public BinaryTreeNode(T item)
        {
            Item = item;
        }

        public void AddLeftChild(T item)
        {
            BinaryTreeNode<T> leftChild = new(item);
            leftChild.Parent = this;
            this.LeftChild = leftChild;
        }

        public void AddRightChild(T item)
        {
            BinaryTreeNode<T> rightChild = new(item);
            rightChild.Parent = this;
            this.RightChild = rightChild;
            
        }

        public void Insert(T item)
        {
            if(Comparer<T>.Default.Compare(item, this.Item) < 0)
            {
                if(this.LeftChild == null)
                {
                    this.AddLeftChild(item);
                }
                else
                {
                    this.LeftChild.Insert(item);
                }
            }
            else if(Comparer<T>.Default.Compare(item, this.Item) > 0)
            {
                if(this.RightChild == null)
                {
                    this.AddRightChild(item);
                }
                else
                {
                    this.RightChild.Insert(item);
                }
            }
        }
    }

    interface IBinaryTree<T> : INonLinearDataStructure<T>
    {
        BinaryTreeNode<T> Root { get; set; }

        public int GetHeight(BinaryTreeNode<T> root);
        public string ToStringLevel(int level, BinaryTreeNode<T> root);
        public string ToStringLevelOrder();

        public void AddLeftChildTo(BinaryTreeNode<T> parent, T leftChildItem);

        public void AddRightChildTo(BinaryTreeNode<T> parent, T rightChildItem);

    }

    public class BinaryTree<T> : IBinaryTree<T>
    {
        private BinaryTreeNode<T> root = new();

        public BinaryTreeNode<T> Root { get => root; set => root = value; }

        public int Count { get; set; }
        
        public void Insert(T item)
        {
            if(Root.Item == null || Root.Item.Equals(0))
            {
                Root.Item = item;
                this.Count++;
            }
            else
            {
                this.Count++;
                Root.Insert(item);
            }
        }

        public void InsertMany(List<T> List)
        {
            foreach (var item in List)
            {
                this.Insert((T)item);
            }
        }

        public void AddLeftChildTo(BinaryTreeNode<T> parent, T leftChildItem)
        {
            if(parent.LeftChild == null)
            {
                parent.AddLeftChild(leftChildItem);
            }
            else
            {
                throw new Exception("The parent already have a child");
            }
        }

        public void AddRightChildTo(BinaryTreeNode<T> parent, T rightChildItem)
        {
            if(parent.RightChild == null)
            {
                parent.AddRightChild(rightChildItem);
            }
            else
            {
                throw new Exception("The parent already have a child");
            }
        }

        public int GetHeight(BinaryTreeNode<T> root)
        {
            if (root == null)
                return 0;
            else
            {
                int lheight = GetHeight(root.LeftChild);
                int rheight = GetHeight(root.RightChild);
                if (lheight > rheight)
                    return lheight+1;
                else
                    return rheight+1;
            }
        }

        public string ToStringLevel(int level, BinaryTreeNode<T> root)
        {
            string result = "";
            if (root == null)
                return "";
            if (level == 1)
                return root.Item.ToString();
            else if(level > 1)
            {
                result += ToStringLevel(level - 1, root.LeftChild);
                result += ToStringLevel(level - 1, root.RightChild);
            }
            return result;
        }

        public string ToStringLevelOrder()
        {
            string insideLoop = "";
            int h = GetHeight(Root);
            int i;
            for (i = 2; i <= h; i++)
            {
                insideLoop += ToStringLevel(i, Root);
            }
            return insideLoop;
        }

        public string TraversePreOrder(BinaryTreeNode<T> parent)
        {
            string result = "";
            if (parent != null)
            {
                result += parent.Item.ToString() + " ";
                result += TraversePreOrder(parent.LeftChild);
                result += TraversePreOrder(parent.RightChild);
            }
            return result;
        }

        public string TraverseInOrder(BinaryTreeNode<T> parent)
        {
            string result = "";
            if (parent != null)
            {
                result += TraverseInOrder(parent.LeftChild);
                result += parent.Item.ToString() + " ";
                result += TraverseInOrder(parent.RightChild);
            }
            return result;
        }

        public string TraversePostOrder(BinaryTreeNode<T> parent)
        {
            string result = "";
            if (parent != null)
            {
                result += TraversePostOrder(parent.LeftChild);
                result += TraversePostOrder(parent.RightChild);
                result += parent.Item.ToString() + " ";
            }
            return result;
        }
    }

    
}
