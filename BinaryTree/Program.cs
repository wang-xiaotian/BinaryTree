using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Binary Tree!");
            List<object> treeValue = new List<object> { 1, 2, null, 4, 5, 6, 7, 8, 9, 10 }; ;
            BinaryTreeTest(in treeValue);
            BinarySearchTreeTest(treeValue);
        }

        /// <summary>
        /// test binary search tree features
        /// </summary>
        /// <param name="treeValue"></param>
        private static void BinarySearchTreeTest(in List<object> treeValue)
        {
            Console.WriteLine("==============Binary Search Tree Test==============");
            // read list of numbers into a binary search tree
            BST<int> binarySearchT = new BST<int>();
            binarySearchT = Solution.BuildBinarySearchTreeFromList<int>(treeValue);

            Console.WriteLine("In-order Travers:");
            binarySearchT.InOrderTravers(binarySearchT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("Post-order Travers:");
            binarySearchT.PostOrderTravers(binarySearchT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("Pre-order Travers:");
            binarySearchT.PreOrderTravers(binarySearchT.Root);
            Console.WriteLine("\n---------------------------------");
        }

        /// <summary>
        /// test binary tree features
        /// </summary>
        /// <param name="treeValue"></param>
        private static void BinaryTreeTest(in List<object> treeValue)
        {
            Console.WriteLine("==============Binary Tree Test==============");
            BinaryTree<int> binaryT = new BinaryTree<int>();
            binaryT = Solution.BuildBinaryTreeFromList<int>(treeValue);
            Console.WriteLine("In-order Travers:");
            binaryT.InOrderTravers(binaryT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("Post-order Travers:");
            binaryT.PostOrderTravers(binaryT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("Pre-order Travers:");
            binaryT.PreOrderTravers(binaryT.Root);
            Console.WriteLine("\n---------------------------------");
        }
    }
}
