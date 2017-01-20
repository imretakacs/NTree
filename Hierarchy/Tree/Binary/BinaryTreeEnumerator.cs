using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hierarchy.Tree.Binary
{
    public class BinaryTreeEnumerator<TValue> : IEnumerator<TValue> where TValue : IComparable
    {
        private IBinaryTreeNode<TValue> _node;
        private IBinaryTreeNode<TValue> _current;
        private Stack<IBinaryTreeNode<TValue>> _stack = new Stack<IBinaryTreeNode<TValue>>();
        private readonly BinaryTree<TValue> _binaryTree;

        public BinaryTreeEnumerator(BinaryTree<TValue> binaryTree)
        {
            _binaryTree = binaryTree;
            _node = binaryTree.Root;
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            _current = null;
            while ((_stack.Count > 0 || _node !=null) && _current == null)
            {
                if (_node != null)
                {
                    _stack.Push(_node);
                    _node = _node.LeftNode;
                }
                else
                {
                    _current = _stack.Pop();
                    _node = _current.RightNode;
                }
            }
            return _current != null;
        }

        public void Reset()
        {
            _stack = new Stack<IBinaryTreeNode<TValue>>();
            _node = _binaryTree.Root;
        }

        public TValue Current => _current.Item;

        object IEnumerator.Current => Current;
    }
}