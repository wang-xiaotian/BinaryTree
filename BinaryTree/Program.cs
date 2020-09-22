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
            List<object> treeValue = new List<object>{1, 2, null, 4, 5, 6, 7, 8, 9, 10 };
            for(int i = 0; i < treeValue.Count; i++) Console.WriteLine(treeValue[i]);

            BinaryTree<int> binaryST = Solution.BuildBinaryTreeFromList<int>(treeValue);
            binaryST.InOrderTravers(binaryST.Root);
        }
    }
}
