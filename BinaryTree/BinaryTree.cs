using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    class BinaryTree<T>
    {
        public Node<T> Root { get; set; }

        //assign Root of tree
        public BinaryTree(Node<T> root = null) => this.Root = root;

        /// <summary>
        /// check whether this tree is empty or not
        /// </summary>
        /// <returns>true=empty or false=non empty</returns>
        public bool IsEmpty() { return this.Root == null ? true : false; }

        /// <summary>
        /// clear all the nodes in this tree
        /// </summary>
        public void Clear() => this.Root = null; // delete root node; garbage collection will earse all


        /// <summary>
        /// insert node in the next avaiable spot by filling up each level first;
        /// </summary>
        /// <param name="node">added node</param>
        public virtual void Insert(Node<T> node)
        {
            if (IsEmpty()) this.Root = node; // empty tree; insert node at Root
            else
            {
                Queue<Node<T>> q = new Queue<Node<T>>(); // store unchecked nodes; each node in this queue can potentially have an empty spot;
                q.Enqueue(this.Root); // add root as first node in the queue
                Node<T> temNode = null; // store temparury node
                while (q.Count != 0) // always have at least one node in the queue
                {
                    temNode = q.Dequeue(); // check the bottom node of this queue
                    if (temNode.InsertNodeBinaryT(node)) { Console.WriteLine($"Node {node} inserted;"); break; }// break if the insertion was successful
                    else { q.Enqueue(temNode.Left); q.Enqueue(temNode.Right); } // temNode is full; add its children in the queue and check them later;
                }
            }
        }

        public void InOrderTravers(Node<T> node)
        {
            if (IsEmpty()) Console.WriteLine("Empty Tree");
            else
            {
                if(node.Left != null) InOrderTravers(node.Left);
                if (node == null) Console.WriteLine("null");
                else Console.WriteLine(node);
                if (node.Right != null) InOrderTravers(node.Right);
            }
        }
    }
}
