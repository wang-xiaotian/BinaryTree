using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    class BSTIterator<T>
    {
        // list of nodes in ascending order
        public List<Node<T>> NodeList { get; private set; } // maintain the node list in descending order

        public int Index {get; private set;} // store position of iterator

        public BSTIterator(Node<T> root = null)
        {
            if(root == null)
            {
                NodeList = null; 
                Index = -1; // list is empty
            } else
            {
                NodeList = new List<Node<T>>();
                BuildListASC(root); // build list of nodes in ascending order 
                Index = 0; // iterator is on the first node of NodeList
            }

        }

        /// <summary>
        /// move iterator to next node and return its reference
        /// </summary>
        /// <returns>reference of next node if it exists</returns>
        public T Next()
        {
            if (HasNext()) { return  NodeList[Index++].Data; } // dont use ++Index;
            else return default;
        }

        public bool HasNext()
        {
            if (NodeList == null) return false;
            if (Index == (NodeList.Count)) return false; // iterator is on the last node
            else return true;
        }

        /// <summary>
        /// inorder traverse to store nodes in the descending order
        /// </summary>
        /// <param name="root">root node</param>
        private void BuildListASC(Node<T> root)
        {
            if (root.Left != null) BuildListASC(root.Left); // check left child
            NodeList.Add(root); // add node into list
            if (root.Right != null) BuildListASC(root.Right); // check right child
        }

    }
}
