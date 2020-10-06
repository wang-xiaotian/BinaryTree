using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tree
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Binary Tree!");
            List<object> treeValue = new List<object> { 4, 7, null, 10, 5, 1, 2, 8, 3, 6 }; ;
            BinaryTreeTest(in treeValue);
            //BinarySearchTreeTest(treeValue);
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
            binarySearchT = Solution.BuildBSTFromList<int>(treeValue);

            Console.WriteLine("In-order Traverse(Recursion):");
            binarySearchT.InOrderTraverse(binarySearchT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("In-order Traverse(Iteration):");
            IList<int> list = binarySearchT.InOrderTraverse2(binarySearchT.Root);
            foreach (int i in list) Console.Write($"{i} - ");
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("Post-order Traverse:");
            binarySearchT.PostOrderTraverse(binarySearchT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("Pre-order Traverse:");
            binarySearchT.PreOrderTraverse(binarySearchT.Root);
            Console.WriteLine("\n---------------------------------");

            Node<int> testNode = new Node<int>(5);
            Node<int> resultNode = binarySearchT.InOrderSuccessor(binarySearchT.Root, testNode);
            Console.WriteLine($"Node-{testNode}'s in-order successor {resultNode}");
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("BST's Iterator:");
            BSTIterator<int> iterator = new BSTIterator<int>(binarySearchT.Root);
            while (iterator.HasNext())
            {
                int i_value = iterator.Next();
                Console.WriteLine($"Iterator Valu:{i_value}.");
            }


            Console.WriteLine("level-order Traverse-BFS:");
            IList<IList<int>> levelOrder = binarySearchT.LevelOrder(binarySearchT.Root);
            foreach (IList<int> t in levelOrder)
            {
                foreach (int i in t)
                    Console.Write($"{i} - ");
                Console.WriteLine();
            }
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("level-order Traverse-BFS:");
            IList<IList<int>> ZigzagLevelOrder = binarySearchT.ZigzagLevelOrder(binarySearchT.Root);
            foreach (IList<int> t in ZigzagLevelOrder)
            {
                foreach (int i in t)
                    Console.Write($"{i} - ");
                Console.WriteLine();
            }

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
            Console.WriteLine("In-order Traverse:");
            binaryT.InOrderTraverse(binaryT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("Post-order Traverse:");
            binaryT.PostOrderTraverse(binaryT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("Pre-order Traverse:");
            binaryT.PreOrderTraverse(binaryT.Root);
            Console.WriteLine("\n---------------------------------");

            Console.WriteLine("LowestCommonAnsestor: Pre-order Traverse:");
            foreach (object i in treeValue)
            {
                if (i == null) continue;
                foreach (object j in treeValue)
                {
                    if (j == null) continue;
                    binaryT.LowestCommonAncestorRecursion(binaryT.Root, new Node<int>((int)i), new Node<int>((int)j));
                }
            }
            Console.WriteLine("\n---------------------------------");


        }
    }
}
