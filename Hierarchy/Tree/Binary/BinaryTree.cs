using System;
using System.Collections;
using System.Collections.Generic;

namespace Hierarchy.Tree.Binary
{
    public class BinaryTree<TValue> : IBinaryTree<TValue>
        where TValue : IComparable
    {
        public void Add(IBinaryTreeNode<TValue> node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Root.Add(node);
            }
        }

        public void Remove(IBinaryTreeNode<TValue> node)
        {
            if (Root == null) return;
            if (Root.Item.CompareTo(node.Item) == 0)
            {
                throw new Exception();//a node with a same value already exist
            }
            Root.Remove(node, null);
        }

        public IEnumerable<IBinaryTreeNode<TValue>> Traverse(TreeTraverseType traverseType)
        {
            return Root.Traverse(traverseType);
        }

        private IEnumerable<IBinaryTreeNode<TValue>> TraversePostorder()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<IBinaryTreeNode<TValue>> TraverseInorder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBinaryTreeNode<TValue>> Find(IBinaryTreeNode<TValue> node, TreeTraverseType traverseType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBinaryTreeNode<TValue>> Find(IBinaryTreeNode<TValue> node)
        {
            throw new NotImplementedException();
        }

        public bool Contains(IBinaryTreeNode<TValue> node, TreeTraverseType traverseType)
        {
            throw new NotImplementedException();
        }

        public IBinaryTreeNode<TValue> Root { get; private set; }

        public IBinaryTreeNode<TValue> MaxItem => Root.MaxItem;

        public IBinaryTreeNode<TValue> MinItem => Root.MinItem;

        public IEnumerator<TValue> GetEnumerator()
        {
            return new BinaryTreeEnumerator<TValue>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BinaryTree<TKey, TValue> : BinaryTree<KeyValuePair<TKey, TValue>> where TKey : IComparable
    {
        
    }
}
