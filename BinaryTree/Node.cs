using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
	class Node<T> : IComparable<Node<T>>
	{
		/// <summary>
		/// store node's value
		/// </summary>
		public T Data { get; set; }

		/// <summary>
		/// store node's left child
		/// </summary>
		public Node<T> Left { get; set; }

		/// <summary>
		/// store node's right child
		/// </summary>
		public Node<T> Right { get; set; }

		/// <summary>
		/// point to next right node
		/// level order traverse - on each level, if your next node is your 'next right node'
		/// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// construction of Node with default values
        /// </summary>
        /// <param name="data"></param>
        public Node(T data, Node<T> left = null, Node<T> right = null)
		{
			this.Data = data; // assign input value to this.Data;
			this.Left = left; // left node is empty
			this.Right = right; // right node is empty
		}

		public Node(object data, Node<T> left = null, Node<T> right = null)
		{
			this.Data = (T)data; // assign input value to this.Data;
			this.Left = left; // left node is empty
			this.Right = right; // right node is empty
		}

		public override string ToString()
		{
			return this.Data.ToString(); // regers to the current instance; using this keyword (vs base); 
		}

		/// <summary>
		/// insert a node into existing node
		/// Logic: if input value is smaller to this Node's value, store input value in this Node's left node
		/// vise versa
		/// 
		/// Input: Node n - reference
		/// Output: void - Node n will be inserted into left or right of this.Node
		/// 
		/// Edge Cases: 
		/// 1. input Node = null : 
		/// 2. input Node.Data = null :
		/// 3. input Node.Data = current.Data : no update in this specific application
		/// </summary>
		/// <param name="n"></param>
		protected internal void InsertNodeBinarySearchT(Node<T> n)
		{
			if (this.CompareTo(n) == 1)
			{
				if (this.Left != null)
				{
					this.Left.InsertNodeBinarySearchT(n);
				} // insert left if smaller than

				else this.Left = n;
			}
			else
			{
				if (this.Right != null)
				{
					this.Right.InsertNodeBinarySearchT(n);
				}
				else this.Right = n;
			}
		}

		/// <summary>
		/// insert node as Binary Tree not Binary Search Tree
		/// this insertion is only for single node;
		/// if left is empty, insert in left
		/// else if right is empty, insert in right
		/// else both occupied 
		/// </summary>
		/// <param name="n"></param>
		protected internal bool InsertNodeBinaryT(Node<T> n)
		{
			//TODO: INTER NODE IN NEXT AVAIABLE SPOT
			//Console.WriteLine("Insert Node in next available spot");
			if (this.Left == null) { this.Left = n; return true; }
			else if (this.Left != null && this.Right == null) { this.Right = n; return true; }
			else return false;
		}

		/// <summary>
		/// it is a leaf node if it has no children
		/// </summary>
		/// <returns>true - no children; false - at least one child</returns>
		protected internal bool IsLeafNode()
		{
			if (this.Left == null && this.Right == null) return true;
			else return false;
		}

		/// <summary>
		/// interface implementation of IComparable
		/// compare the values of two nodes
		/// </summary>
		/// <param name="node">compare input node with this.Node</param>
		/// <returns>return 1 this > than input node; -1 less; 0 equal </returns>
		public int CompareTo(Node<T> other)
		{
			if (other == null) return -2;
			else
			{
				try { return Convert.ToInt32(this.Data).CompareTo(Convert.ToInt32(other.Data)); }
				catch (FormatException e) { Console.WriteLine(e); return -2; }
			}
		}
	}
}