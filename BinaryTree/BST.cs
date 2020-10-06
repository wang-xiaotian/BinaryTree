using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Tree
{
    class BST<T> : BinaryTree<T>
    {
        public BST(Node<T> root = null) : base(root) { }

        /// <summary>
        /// to insert a node in a tree
        /// check root: 
        ///     if empty -> root=new node;
        ///     else insert new node in this tree 
        ///         by recursion method Node.insertNode(Node n);
        /// </summary>
        /// <param name="n">added node</param>
        public override void Insert(Node<T> n)
        {
            // don't insert null in binary search tree
            if (n != null)
            {
                if (base.IsEmpty()) this.Root = n;
                else base.Root.InsertNodeBinarySearchT(n);
            }
        }

        /// <summary>
        /// FIND EXISTING Node's inorder successor, inorder searching Node and return its successor
        /// </summary>
        /// <param name="root">starting from tree's root</param>
        /// <param name="target">target node</param>
        /// <returns>return target's successor</returns>
        public Node<T> InOrderSuccessor(Node<T> root, Node<T> target)
        {
            bool gate = false; // gate will be true when find target node
            Node<T> result = null; // strore successor node if we find it
            InOrderSuccessorFinder(root, target, ref gate, ref result); 
            return result;
        }


        /// <summary>
        /// locate target node and iterate one step further to locate successor node;
        /// store the successor node in reference, then return
        /// </summary>
        /// <param name="root">start searching from root</param>
        /// <param name="target">target node</param>
        /// <param name="gate">true if we found target node; one more step is the successor node</param>
        /// <param name="result">store the successor if we have one</param>
        public void InOrderSuccessorFinder(Node<T> root, Node<T> target, ref bool gate, ref Node<T> result)
        {
            if (root.Left != null) InOrderSuccessorFinder(root.Left, target, ref gate, ref result); // search root's left child
            
            if (gate) { result = root; gate = false; return; } // located the inorder successor -> stop searching return
            if (root.CompareTo(target) == 0) gate=true; // located the same node -> open gate and next node is inorder successor 

            if (root.Right != null) InOrderSuccessorFinder(root.Right, target, ref gate, ref result); // search root's right child
        }


    }
}
