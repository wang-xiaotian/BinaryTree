using System;
using System.Collections.Generic;
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
        ///     if empty -> root=new node
        ///     else insert new node in this tree
        ///         by recursion method Node.insertNode(Node n)
        /// </summary>
        /// <param name="n"></param>
        public override void Insert(Node<T> n)
        {
            if (base.IsEmpty()) this.Root = n;
            else base.Root.InsertNodeBinarySearchT(n);
        }


    }
}
