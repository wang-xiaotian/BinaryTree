using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Tree
{
    public static class Solution
    {

        /// <summary>
        /// iterate all nodes starting from root of the tree with in-order traversal;
        /// 
        /// if left node is bigger than parent, return false
        /// else if right node is smaller and equal to parent, return false
        /// else go to next node
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        internal static bool IsValidBST(Node<int> root)
        {
            int min = int.MinValue; // store the current minimum value; be caution with edge cases (first input == int.MinValue)
            bool result = true; // store the result of this BST's validation - true or false;
            int count = 0; // store the number of nodes that have been validated;
            if (root == null) return true; // empty tree - return true; depends on function requirements;
            else
            {
                if (root.Left == null && root.Right == null) return result; // single node tree -> return true
                IsValidBSTNode(root, ref min, ref result, ref count); // check all nodes starting from root node;
                Console.WriteLine();
                return result; // return final result
            }
        }

        /// <summary>
        /// check all nodes in in-order traverse;
        /// next value shouldn't be smaller than previous one;
        /// assume no duplicate value in this binary tree;
        /// </summary>
        /// <param name="node">validate this node</param>
        /// <param name="minimum">comparing node.Data with current minimum value</param>
        /// <param name="result">result's default value is true; change result to false if at least one violation has been found</param>
        /// <param name="count">number of nodes that have been validated</param>
        private static void IsValidBSTNode(Node<int> node, ref int minimum, ref bool result, ref int count)
        {
            if (node.Left != null) IsValidBSTNode(node.Left, ref minimum, ref result, ref count); // check left child node
            if (node.Data > minimum || count == 0) minimum = node.Data; // check myself; bigger than the minimum -> assign myself to minimum;
            else result = false; // node's value smaller or equal than current minimum 
            count++; // number of nodes that have been validated
            if (node.Right != null) { IsValidBSTNode(node.Right, ref minimum, ref result, ref count); } // check right node
        }

        /// <summary>
        /// generic method reading an array representation of a binary tree and bui
        /// node = array[n]; node.left = array[2n]; node.right = array[2n+1]
        /// root of the input binary tree is array[0]
        /// </summary>
        /// <typeparam name="T">can be data type or reference type</typeparam>
        /// <param name="array">an array representation of a binary tree</param>
        /// <return name="Node"> return a reference of the root node</return>
        internal static BinaryTree<T> BuildBinaryTreeFromList<T>(List<object> list)
        {
            if (list == null) return null;
            else
            {
                BinaryTree<T> bt = new BinaryTree<T>();
                foreach (object i in list)
                {
                    Node<T> temNode;
                    if (i == null) temNode = null;
                    else temNode = new Node<T>(i);
                    bt.Insert(temNode);
                }
                return bt;
            }
            /*
             * Parent(r) =⌊(r−1)/ 2⌋ if r≠0.
             * Left child(r) = 2r + 1 if 2r + 1 < n.
             * Right child(r) = 2r + 2 if 2r + 2 < n.
             * Left sibling(r) = r−1 if r is even and r≠0.
             * Right sibling(r) = r + 1 if r is odd and r + 1 < n.
             */
        }

        /// <summary>
        ///  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        internal static BST<T> BuildBSTFromList<T>(List<object> list)
        {
            if (list == null) return null;
            else
            {
                BST<T> bSt = new BST<T>();
                foreach (object i in list)
                {
                    Node<T> temNode;
                    if (i == null) temNode = null;
                    else temNode = new Node<T>(i);
                    bSt.Insert(temNode);
                }
                return bSt;
            }
        }
    }
}
