using System;
using System.Collections.Generic;
using System.Linq;
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
        /// this is the insert for Binary Tree
        /// insert node in the next avaiable spot by filling up each level first;
        /// </summary>
        /// <param name="node">added node</param>
        public virtual void Insert(Node<T> node)
        {
            if (IsEmpty()) { /*Console.WriteLine($"Root Node {node} is inserted.");*/ this.Root = node; }// empty tree; insert node at Root
            else
            {
                Queue<Node<T>> q = new Queue<Node<T>>(); // store unchecked nodes; each node in this queue can potentially have an empty spot;
                q.Enqueue(this.Root); // add root as first node in the queue
                Node<T> temNode = null; // store temparury node
                while (q.Count != 0) // always have at least one node in the queue
                {
                    temNode = q.Dequeue(); // check the bottom node of this queue
                    if (temNode.InsertNodeBinaryT(node)) { /*Console.WriteLine($"Node {node} inserted below its parent {temNode};");*/ break; }// break if the insertion was successful
                    else { q.Enqueue(temNode.Left); q.Enqueue(temNode.Right); } // temNode is full; add its children in the queue and check them later;
                }
            }
        }

        /// <summary>
        /// traverse the tree with In-order sequence with recursion 
        /// Left Child -> Parent -> Right child
        /// </summary>
        /// <param name="node">parent node</param>
        public void InOrderTraverse(Node<T> node)
        {
            if (IsEmpty()) Console.WriteLine("Empty Tree");
            else
            {
                if(node.Left != null) InOrderTraverse(node.Left); // visit left
                Console.Write($"{node} - "); // visit parent
                if (node.Right != null) InOrderTraverse(node.Right); // visit right
            }
        }

        /// <summary>
        /// iterative solution
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IList<T> InOrderTraverse2(Node<T> node)
        {
            IList<Node<T>> stackList = new List<Node<T>>(); // tempraryly store unfinished nodes in here; first in last out            IList<T> result = new List<T>();
            Node<T> iterator = new Node<T>(default); // store the iterator node; it will traverse inorder
            IList<T> result = new List<T>();

            if (node == null) return null;
            stackList.Add(new Node<T>(node.Data, node.Left, node.Right));
            while (stackList.Count != 0)
            { 
                iterator = stackList[stackList.Count - 1];
                if (iterator.Left != null)
                {
                    stackList.Add(new Node<T>(iterator.Left.Data, iterator.Left.Left, iterator.Left.Right));
                    iterator.Left = null;
                }else
                {
                    result.Add(iterator.Data);
                    stackList.RemoveAt(stackList.Count - 1);
                    if (iterator.Right != null)
                    {
                        stackList.Add(new Node<T>(iterator.Right.Data, iterator.Right.Left, iterator.Right.Right));
                        iterator.Right = null;
                    }
                } 
            }
            return result;
        }

        /// <summary>
        /// traverse binary tree by levels-BFS
        /// from top to bottom, level by level, from left to right 
        /// </summary>
        /// <param name="root">root node</param>
        /// <returns></returns>
        public IList<IList<T>> LevelOrder(Node<T> root)
        {
            IList<Node<T>> level = new List<Node<T>>(); // store nodes for current level
            IList<Node<T>> nextLevel = new List<Node<T>>(); // store nodes for next level
            IList<IList<T>> nodesByLevel = new List<IList<T>>(); // store nodes by levels
            
            if(root != null) level.Add(root); // initial current level by adding root node of a binary tree

            while (level.Count != 0)
            {
                IList<T> valueLevel = new List<T>(); // store nodes for current level
                // iterate all nodes in this level
                foreach(Node<T> n in level)
                {
                    valueLevel.Add(n.Data); // record nodes's value in a list 
                    if (n.Left != null) nextLevel.Add(n.Left); // add left child in next level
                    if (n.Right != null) nextLevel.Add(n.Right); // add right child in next level
                }
                nodesByLevel.Add(valueLevel); // record curretn level's nodes' value list
                level = nextLevel; // move to next level
                nextLevel = new List<Node<T>>(); // reset next level's next level
            }
            return nodesByLevel;
        }

        /// <summary>
        /// Zigzag traverse binary tree by levels-BFS
        /// from top to bottom, level by level
        /// odd level - from left to right 
        /// even level - from right to right
        /// </summary>
        /// <param name="root">root node</param>
        /// <returns></returns>
        public IList<IList<T>> ZigzagLevelOrder(Node<T> root)
        {
            IList<Node<T>> level = new List<Node<T>>(); // store nodes for current level
            IList<Node<T>> nextLevel = new List<Node<T>>(); // store nodes for next level
            IList<IList<T>> nodesByLevel = new List<IList<T>>(); // store nodes by levels
            int levelNum = 1;

            if (root != null) level.Add(root); // initial current level by adding root node of a binary tree

            while (level.Count != 0)
            {
                IList<T> valueLevel = new List<T>(); // store nodes for current level
                // iterate all nodes in this level
                for(int i = 0; i < level.Count; i++)
                {
                    if (levelNum % 2 != 0) valueLevel.Add(level[i].Data); // odd level - from left to right to record nodes's value in a list 
                    else valueLevel.Add(level[level.Count - i - 1].Data); // even level - from right to left to record nodes's value in a list
                    if (level[i].Left != null) nextLevel.Add(level[i].Left); // add left child in next level
                    if (level[i].Right != null) nextLevel.Add(level[i].Right); // add right child in next level
                }
                nodesByLevel.Add(valueLevel); // record curretn level's nodes' value list
                level = nextLevel; // move to next level
                nextLevel = new List<Node<T>>(); // reset next level's next level
                levelNum += 1;
            }
            return nodesByLevel;
        }

        /// <summary>
        /// point each node to its next node 
        /// level order traverse
        /// on each level, if you have next node then it is your 'next node' 
        /// </summary>
        /// <param name="root">root node of a tree</param>
        /// <returns>optional-for recursion method</returns>
        public Node<T> Connect(Node<T> root)
        {
            IList<Node<T>> level = new List<Node<T>>(); // store nodes for current level

            if (root != null) level.Add(root); // initial current level by adding root node of a binary tree

            while (level.Count != 0)
            {
                // iterate all nodes in this level
                int size = level.Count;
                for(int i = 0; i < size; i++)
                {
                    if (i + 1 != size) level[i].Next = level[i + 1]; // if you have next, point your 'Next' to it
                    else level[i].Next = null; // if not, point to null;

                    if (level[i].Left != null) level.Add(level[i].Left); // add left child in next level
                    if (level[i].Right != null) level.Add(level[i].Right); // add right child in next level
                    level.RemoveAt(0);
                }
            }
            return root;
        }

        /// <summary>
        /// Assumption : perfect binary tree
        /// This solution is fast but more space 
        /// point each node to its next node 
        /// level order traverse
        /// root's next = null
        /// root->left->next = root->right
        /// root->right->next = if(root->next != null) root->next->left
        /// </summary>
        /// <param name="root">root node of a tree</param>
        /// <returns>optional-for recursion method</returns>
        public Node<T> Connect2(Node<T> root)
        {
            if (root != null) root.Next = null; 
            else return root; // empty tree
            Node<T> current = root; // initialize current node = root
            Node<T> headNextL = new Node<T>(default); // next level's head
            bool firstNode = true; // when current node is the first node on its level, value = true;

            while(current.Left != null)
            {
                if (firstNode) { headNextL = current.Left; firstNode = false; }
                current.Left.Next = current.Right; // left child->next = parent -> right node
                if (current.Next != null) current.Right.Next = current.Next.Left;
                else current.Right.Next = null; // right child -> next = parent->next->left

                // iterate to next node
                if (current.Next == null) { current = headNextL; firstNode = true; } // go to next level
                else current = current.Next; // go to its next
            }
            return root;
        }

        /// <summary>
        /// traverse the tree with Pre-order sequence with recursion 
        /// Parent -> Left Child -> Right child
        /// </summary>
        /// <param name="node">parent node</param>
        public void PreOrderTraverse(Node<T> node)
        {
            if (IsEmpty()) Console.WriteLine("Empty Tree");
            else
            {
                Console.Write($"{node} - "); // visit parent
                if (node.Left != null) PreOrderTraverse(node.Left); // visit left
                if (node.Right != null) PreOrderTraverse(node.Right); // visit right
            }
        }

        /// <summary>
        /// traverse the tree with Post-order sequence with recursion 
        /// Left Child -> Right child -> Parent
        /// </summary>
        /// <param name="node">parent node</param>
        public void PostOrderTraverse(Node<T> node)
        {
            if (IsEmpty()) Console.WriteLine("Empty Tree");
            else
            {
                if (node.Left != null) PostOrderTraverse(node.Left); // visit left
                if (node.Right != null) PostOrderTraverse(node.Right); // visit right
                Console.Write($"{node} - "); // visit parent
            }
        }
    }
}
