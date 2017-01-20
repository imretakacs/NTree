using System;
using System.Collections.Generic;

namespace Hierarchy.Tree.Binary
{
    public interface IBinaryTree<TKey, TValue> : IEnumerable<TValue>
        where TKey : IComparable
    {
        void AddNode(IBinaryTreeNode<TKey, TValue> node);

        void Remove(IBinaryTreeNode<TKey, TValue> node);

        IEnumerable<IBinaryTreeNode<TKey, TValue>> Traverse(TreeTraverseType traverseType);

        IEnumerable<IBinaryTreeNode<TKey, TValue>> Find(IBinaryTreeNode<TKey, TValue> node, TreeTraverseType traverseType);

        IEnumerable<IBinaryTreeNode<TKey, TValue>> Find(IBinaryTreeNode<TKey, TValue> node);

        bool Contains(IBinaryTreeNode<TKey, TValue> node, TreeTraverseType traverseType);

        IBinaryTreeNode<TKey, TValue> Root { get; }

        IBinaryTreeNode<TKey, TValue> MaxValue { get; }

        IBinaryTreeNode<TKey, TValue> MinValue { get; }
    }

    public interface IBinaryTree<TValue> : IEnumerable<TValue>
        where TValue : IComparable
    {
        void Add(IBinaryTreeNode<TValue> node);

        void Remove(IBinaryTreeNode<TValue> node);

        IEnumerable<IBinaryTreeNode<TValue>> Traverse(TreeTraverseType traverseType);

        IEnumerable<IBinaryTreeNode<TValue>> Find(IBinaryTreeNode<TValue> node, TreeTraverseType traverseType);

        IEnumerable<IBinaryTreeNode<TValue>> Find(IBinaryTreeNode<TValue> node);

        bool Contains(IBinaryTreeNode<TValue> node, TreeTraverseType traverseType);

        IBinaryTreeNode<TValue> Root { get; }

        IBinaryTreeNode<TValue> MaxItem { get; }

        IBinaryTreeNode<TValue> MinItem { get; }
    }
}