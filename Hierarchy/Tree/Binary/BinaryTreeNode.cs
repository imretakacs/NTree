using System;
using System.Collections.Generic;

namespace Hierarchy.Tree.Binary
{
    public class BinaryTreeNode<TItem> : IBinaryTreeNode<TItem>
        where TItem : IComparable
    {
        public BinaryTreeNode(TItem item)
        {
            Item = item;
        }
        public IBinaryTreeNode<TItem> LeftNode { get; set; }

        public IBinaryTreeNode<TItem> RightNode { get; set; }

        public TItem Item { get; internal protected set; }

        public void Add(IBinaryTreeNode<TItem> node)
        {
            if (Item.CompareTo(node.Item) > 0)
            {
                if (LeftNode == null)
                    LeftNode = node;
                else
                    LeftNode.Add(node);
            }
            else if (Item.CompareTo(node.Item) < 0)
            {
                if (RightNode == null)
                    RightNode = node;
                else
                    RightNode.Add(node);
            }
        }

        public void Remove(IBinaryTreeNode<TItem> node, IBinaryTreeNode<TItem> parent)
        {
            if (node.Item.CompareTo(Item) < 0)
            {
                LeftNode?.Remove(node, this);
            }
            else if (node.Item.CompareTo(Item) > 0)
            {
                RightNode?.Remove(node, this);
            }
            else {
                if (LeftNode != null && RightNode != null)
                {
                    parent.RightNode = MinItem;
                }
                else if (parent.LeftNode == this)
                {
                    parent.LeftNode = LeftNode ?? RightNode;
                }
                else if (parent.RightNode == this)
                {
                    parent.RightNode = LeftNode ?? RightNode;
                }
            }
        }

        public IBinaryTreeNode<TItem> MaxItem
        {
            get
            {
                if (RightNode == null)
                    return this;
                return RightNode.MaxItem;
            }
        }

        public IBinaryTreeNode<TItem> MinItem
        {
            get
            {
                if (LeftNode == null)
                    return this;
                return LeftNode.MinItem;
            }
        }

        public IEnumerable<IHaveChildren<IBinaryTreeNode<TItem>>> Children
        {
            get
            {
                if (LeftNode == null && RightNode == null)
                {
                    return null;
                }
                if (LeftNode != null)
                {
                    return new IHaveChildren<IBinaryTreeNode<TItem>>[] { LeftNode };
                }
                return RightNode != null ? new IHaveChildren<IBinaryTreeNode<TItem>>[] { RightNode } : new IHaveChildren<IBinaryTreeNode<TItem>>[] { LeftNode, RightNode };
            }
        } 

        public IEnumerable<IBinaryTreeNode<TItem>> Traverse(TreeTraverseType traverseType)
        {
            switch (traverseType)
            {
                case TreeTraverseType.InOrder:
                    return TraverseInorder();
                case TreeTraverseType.PostOrder:
                    return TraversePostorder();
                default:
                    return TraversePreOrder();
            }
        }

        public IEnumerable<IBinaryTreeNode<TItem>> TraversePreOrder()
        {
            var nodes = new List<IBinaryTreeNode<TItem>>();
            if (LeftNode != null)
            {
                nodes.AddRange(LeftNode.TraversePreOrder());
            }
            nodes.Add(this);
            if (RightNode != null)
                nodes.AddRange(RightNode.TraversePreOrder());
            return nodes;
        }

        public IEnumerable<IBinaryTreeNode<TItem>> TraversePostorder()
        {
            var nodes = new List<IBinaryTreeNode<TItem>>();
            if (RightNode != null)
                nodes.AddRange(RightNode.TraversePostorder());
            nodes.Add(this);
            if (LeftNode != null)
                nodes.AddRange(LeftNode.TraversePostorder());
            return nodes;
        }

        public IEnumerable<IBinaryTreeNode<TItem>> TraverseInorder()
        {
            var nodes = new List<IBinaryTreeNode<TItem>>();
            nodes.Add(this);
            if (LeftNode != null)
                nodes.AddRange(LeftNode.TraverseInorder());
            if (RightNode != null)
                nodes.AddRange(RightNode.TraverseInorder());
            return nodes;
        }
    }

    public class BinaryTreeNode<TKey, TValue> : BinaryTreeNode<KeyValuePair<TKey, TValue>>
        where TKey : IComparable
    {
        public BinaryTreeNode(TKey key, TValue value) : base(new KeyValuePair<TKey, TValue>(key, value))
        {
        }
    }
}