using System;
using System.Collections.Generic;

namespace Hierarchy.Tree.Binary
{
    public interface IBinaryTreeNode<TKey, TValue> : IHaveChildren<IBinaryTreeNode<TKey, TValue>>
        where TKey : IComparable
    {
        TKey Key { get; }

        TValue Value { get; }

        IBinaryTreeNode<TKey, TValue> LeftNode { get; set; }

        IBinaryTreeNode<TKey, TValue> RightNode { get; set; }

        TValue MaxValue { get; }

        TValue MinValue { get; }

        void Add(IBinaryTreeNode<TKey, TValue> node);

        void Remove(IBinaryTreeNode<TKey, TValue> node, IBinaryTreeNode<TKey, TValue> parent);

        IEnumerable<IBinaryTreeNode<TKey, TValue>> Traverse(TreeTraverseType traverseType);

        IEnumerable<IBinaryTreeNode<TKey, TValue>> TraversePreOrder();

        IEnumerable<IBinaryTreeNode<TKey, TValue>> TraversePostorder();

        IEnumerable<IBinaryTreeNode<TKey, TValue>> TraverseInorder();
    }

    public interface IBinaryTreeNode<TItem> : IHaveChildren<IBinaryTreeNode<TItem>>
        where TItem : IComparable
    {
        TItem Item { get; }

        IBinaryTreeNode<TItem> LeftNode { get; set; }

        IBinaryTreeNode<TItem> RightNode { get; set; }

        IBinaryTreeNode<TItem> MaxItem { get; }

        IBinaryTreeNode<TItem> MinItem { get; }

        void Add(IBinaryTreeNode<TItem> node);

        void Remove(IBinaryTreeNode<TItem> node, IBinaryTreeNode<TItem> parent);

        IEnumerable<IBinaryTreeNode<TItem>> Traverse(TreeTraverseType traverseType);

        IEnumerable<IBinaryTreeNode<TItem>> TraversePreOrder();

        IEnumerable<IBinaryTreeNode<TItem>> TraversePostorder();

        IEnumerable<IBinaryTreeNode<TItem>> TraverseInorder();
    }
}