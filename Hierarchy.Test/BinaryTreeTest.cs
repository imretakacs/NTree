using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Hierarchy.Tree;
using Hierarchy.Tree.Binary;
using NUnit.Framework;

namespace Hierarchy.Test
{
    [TestFixture]
    public class BinaryTreeTest
    {
        [Test]
        public void Add()
        {
            var binaryTree = new BinaryTree<int>();
            var root = new BinaryTreeNode<int>(10);
            binaryTree.Add(root);
            var leftChild = new BinaryTreeNode<int>(9);
            binaryTree.Add(leftChild);
            var rightChild = new BinaryTreeNode<int>(11);
            binaryTree.Add(rightChild);

            Assert.AreEqual(leftChild, root.LeftNode);
            Assert.AreEqual(rightChild, root.RightNode);
        }

        [Test]
        public void PreOrder()
        {
            var binaryTree = new BinaryTree<int>();
            var root = new BinaryTreeNode<int>(10);
            binaryTree.Add(root);
            var leftChild = new BinaryTreeNode<int>(9);
            binaryTree.Add(leftChild);
            var rightChild = new BinaryTreeNode<int>(11);
            binaryTree.Add(rightChild);
            var leftLeftChild = new BinaryTreeNode<int>(6);
            binaryTree.Add(leftLeftChild);
            var leftRightChild = new BinaryTreeNode<int>(8);
            binaryTree.Add(leftRightChild);
            var leftLeftLeftChild = new BinaryTreeNode<int>(5);
            binaryTree.Add(leftLeftLeftChild);
            var rightRightRightChild = new BinaryTreeNode<int>(12);
            binaryTree.Add(rightRightRightChild);

            Assert.AreEqual(new [] {5,6,8,9,10,11,12},binaryTree.Traverse(TreeTraverseType.PreOrder).Select(n => n.Item).ToArray());
        }

        [Test]
        public void Iterator()
        {
            var binaryTree = new BinaryTree<int>();
            var root = new BinaryTreeNode<int>(10);
            binaryTree.Add(root);
            var leftChild = new BinaryTreeNode<int>(9);
            binaryTree.Add(leftChild);
            var rightChild = new BinaryTreeNode<int>(11);
            binaryTree.Add(rightChild);
            var leftLeftChild = new BinaryTreeNode<int>(6);
            binaryTree.Add(leftLeftChild);
            var leftRightChild = new BinaryTreeNode<int>(8);
            binaryTree.Add(leftRightChild);
            var leftLeftLeftChild = new BinaryTreeNode<int>(5);
            binaryTree.Add(leftLeftLeftChild);
            var rightRightRightChild = new BinaryTreeNode<int>(12);
            binaryTree.Add(rightRightRightChild);

            Assert.AreEqual(new[] { 5, 6, 8, 9, 10, 11, 12 }, binaryTree.ToArray());
        }

        [Test]
        public void IteratorKeyValue()
        {
            var binaryTree = new BinaryTree<int,object>();
            var root = new BinaryTreeNode<int, object>(10, new {Name = "root"});
            binaryTree.Add(root);
            var leftChild = new BinaryTreeNode< int,object> (9, new { Name = "leftChild" });
            binaryTree.Add(leftChild);
            var rightChild = new BinaryTreeNode<int, object> (11, new { Name = "rightChild" });
            binaryTree.Add(rightChild);

            Assert.AreEqual(new[] {9, 10, 11}, binaryTree.ToArray().Select(n => n.Key));
        }

        [Test]
        public void StringTree()
        {
            var binaryTree = new BinaryTree<string, object>();
            binaryTree.Add(new BinaryTreeNode<Tree.Binary.KeyValuePair<string, object>>(new Tree.Binary.KeyValuePair<string, object>("alma",new {})));
            binaryTree.Add(new BinaryTreeNode<Tree.Binary.KeyValuePair<string, object>>(new Tree.Binary.KeyValuePair<string, object>("korte", new {})));
            binaryTree.Add(new BinaryTreeNode<Tree.Binary.KeyValuePair<string, object>>(new Tree.Binary.KeyValuePair<string, object>("barack", new {})));

            Assert.AreEqual(new [] {"alma", "barack", "korte"}, binaryTree.Select(n => n.Key).ToArray());
        }
    }
}
