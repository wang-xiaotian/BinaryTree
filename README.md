
<!-- Title Image Starts-->
[![CoverPicture](https://user-images.githubusercontent.com/56288794/94039010-06cb9a00-fd7c-11ea-9877-e61000f1c1d4.PNG)](https://wang-xiaotian.github.io/)
<!-- Title Image Ends-->

<!-- Title Starts-->
# Binary Tree Solutions
> Binary Tree Basic Features and Operations: Search, Insert, and Delete; <br />
> Binary Tree Traversal: In-order, Pre-order, and Post-order; <br />
> Binary Search Tree: Searching an Object and Return its In-order Successor; <br />
> Updating more actions... <br />

<!-- Title Ends-->

<!-- Badges Starts-->
[![made-with-c#](https://img.shields.io/badge/Made%20with-C%23-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![microsoft-powerpoint](https://img.shields.io/badge/MICROSOFT-POWERPOINT-green)](http://microsoft.org)
[![shields-io](https://img.shields.io/badge/Shields-IO-orange)](http://shields.org)
[![binaryTree](https://img.shields.io/badge/Data%20Structure-Binary%20Tree-red)](http://shields.org)
[![recordit-rec](https://img.shields.io/badge/Recordit-REC-red)](https://recordit.co/)
<!-- Badges Ends-->

<!-- spacer starts -->
---
<!-- spacer ends -->

<!-- DEMO starts -->
***Check it out!***
> Tree Traversal Demo is coming ...
<!--![demo GIF by GIF MAKER](https://user-images.githubusercontent.com/56288794/88509309-a1367980-cf95-11ea-9c9d-b58eb657662d.gif)-->

---
<!-- DEMO ENDS -->

## Table of Contents
  - [Installation](#installation)
    - [Environment Setup](#environment-Setup)
    - [Testing](#testing)
  - [Screenshot](#screenshot)
  - [Binary Search Tree Validation](#binary-search-tree-validation)
  - [Breadth-first Tree Traversal](#breadth-frist-search)
  - [Inorder Depth-first Tree Traversal](#depth-frist-search-inorder-by-iteration)
  - [Preorder Depth-first Tree Traversal](#depth-frist-search-preorder)
  - [Postorder Depth-first Tree Traversal](#depth-frist-search-postorder)
  - [Search Node's Inorder Successor](#locate-an-object-and-return-its-inorder-successor)
  - [Challenges](#challenges)
  - [Resource](#resource)
  - [License](#license)


---
## Installation

### Environment Setup

> <a href="https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2019" target="_blank"> Install Visual Studio </a> <br/>

> <a href="https://www.tutorialspoint.com/executing-chash-code-in-linux" target="_blank"> How to run C# on Linux </a> <br/>

> Step 1 (Visual Studio Windows):
```
C:\>
```
> Step 1 (Linux):
```
$
```

### Testing
```shell
>
```
---

## Screenshot
<!--![demo GIF by GIF MAKER](https://user-images.githubusercontent.com/56288794/88518703-c501bb80-cfa5-11ea-92a5-67ba192951b1.gif) -->
---
## Binary Search Tree Validation

#### How to validate whether a binary tree is a binary search tree?

---
```csharp
/// <summary>
/// iterate all nodes starting from root with in-order traversal;
/// inorder traversal of BST is in ascending order.
/// if current node's value is bigger than next, then this is not BST
/// </summary>
internal static bool IsValidBST(Node<int> root)
{
  int min = int.MinValue; // store the current minimum value; caution: edge cases
  bool result = true; // store the result of this BST's validation - true or false;
  int count = 0; // store the number of nodes that have been validated;

  if (root == null) return true; // empty tree - return true; depends on requirements;
  else
  {
    if (root.Left == null && root.Right == null) return result; // single node tree -> return true
    IsValidBSTNode(root, ref min, ref result, ref count); // check all nodes starting from root node;
    return result; // return final result
  }
}

private static void IsValidBSTNode(Node<int> node, ref int minimum, ref bool result, ref int count)
{
  if (node.Left != null) IsValidBSTNode(node.Left, ref minimum, ref result, ref count); // check left child;

  if (node.Data > minimum || count == 0) minimum = node.Data; // current value is bigger than the minimum -> assign myself to minimum;
  else result = false;
  count++; // number of nodes that have been validated

  if (node.Right != null) { IsValidBSTNode(node.Right, ref minimum, ref result, ref count); } // check right child;
}
```
## Binary Tree Traversal
### Breadth-frist Search
```cs
/// <summary>
/// traverse binary tree by levels-BFS
/// from top to bottom, level by level, from left to right
/// </summary>
public IList<IList<T>> LevelOrder(Node<T> root)
{
  IList<Node<T>> level = new List<Node<T>>(); // store nodes for current level
  IList<Node<T>> nextLevel = new List<Node<T>>(); // store nodes for next level
  IList<IList<T>> nodesByLevel = new List<IList<T>>(); // store nodes by levels
  
  if(root != null) level.Add(root); // initial current level by adding root node of a binary tree
  while (level.Count != 0)
  {
    IList<T> valueLevel = new List<T>(); // store nodes for current level
    foreach(Node<T> n in level) // iterate all nodes in this level
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
```
### Depth-frist Search (Inorder by Iteration)
```cs
/// <summary>
/// iterative solution
/// </summary>
public IList<T> InOrderTraverse2(Node<T> node)
{
  IList<Node<T>> stackList = new List<Node<T>>(); // tempraryly store unfinished nodes in here; first in last out            IList<T> result = new List<T>();
  Node<T> iterator = new Node<T>(default); // store the iterator node; it will traverse inorder
  IList<T> result = new List<T>();

  if (node == null) return null;
  stackList.Add(new Node<T>(node.Data, node.Left, node.Right));
  while (stackList.Count != 0)
  {
    iterator = stackList[stackList.Count - 1]; // last in first out
    if (iterator.Left != null)
    {
    stackList.Add(new Node<T>(iterator.Left.Data, iterator.Left.Left, iterator.Left.Right));
    iterator.Left = null; // left child has been added
    } 
    else {
      result.Add(iterator.Data);
      stackList.RemoveAt(stackList.Count - 1);
      if (iterator.Right != null)
      {
        stackList.Add(new Node<T>(iterator.Right.Data, iterator.Right.Left, iterator.Right.Right));
        iterator.Right = null; // left child has been added
      }
    }
  }
  return result;
}
```

### Depth-frist Search (Preorder)
```csharp
/// <summary>
/// traverse the tree with Pre-order sequence with recursion 
/// Parent -> Left Child -> Right child
/// </summary>
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
```

### Depth-frist Search (Postorder)
```csharp
/// <summary>
/// traverse the tree with Post-order sequence with recursion
/// Left Child -> Right child -> Parent
/// </summary>
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
```

### Locate an Object and Return its Inorder Successor
```csharp
/// <summary>
/// FIND EXISTING Node's inorder successor, inorder searching Node and return its successor
/// </summary>
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
public void InOrderSuccessorFinder(Node<T> root, Node<T> target, ref bool gate, ref Node<T> result)
{
  if (root.Left != null) InOrderSuccessorFinder(root.Left, target, ref gate, ref result); // search root's left child
            
  if (gate) { result = root; gate = false; return; } // located the inorder successor -> stop searching return
  if (root.CompareTo(target) == 0) gate=true; // located the same node -> open gate and next node is inorder successor 

  if (root.Right != null) InOrderSuccessorFinder(root.Right, target, ref gate, ref result); // search root's right child
}
```


## Challenges

> TODO 1: How to use unit test to test my program? <br/>
> TODO 2: Demo GIF <br/>
> TODO 3: Update Installation Instructions <br/>

---

## Resource
<a href="https://docs.microsoft.com/en-us/dotnet/csharp/" target="_blank"> C# Microsoft Documentation </a> <br>
<a href="https://www.tutorialspoint.com/csharp/index.htm" target="_blank"> C# Tutorial at TutorialsPoint </a><br>
<a href="https://leetcode.com/" target="_blank"> LeetCode </a> <br>

---
## License
> Oops! Coming soon !!!

---
