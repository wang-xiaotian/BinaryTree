
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
  - [Code Sample](#code)
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
<!-- !curl -X POST HTTP://127.0.0.1:5000/test --header "Content-Type: application/json" --data {\"string_to_cut\":\"EXAMPLE_STRING\"} -->
---

## Screenshot
<!--![demo GIF by GIF MAKER](https://user-images.githubusercontent.com/56288794/88518703-c501bb80-cfa5-11ea-92a5-67ba192951b1.gif) -->
---
## Code

#### How to validate whether a binary tree is a binary search tree?

---
```csharp
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
