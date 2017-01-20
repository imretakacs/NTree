using System;
using System.Collections.Generic;
using System.Linq;

namespace Hierarchy.Linq
{
    public static class HierarchyExtension
    {
        public static IEnumerable<IHaveParent<T>> PathToRoot<T>(this IHaveParent<T> node)
        {
            if (!node.HasParent)
            {
                yield return node;
            }
            IList<IHaveParent<T>> nodes = new List<IHaveParent<T>>();
            nodes.Add(node);
            while (nodes.Count > 0)
            {
                var current = nodes.ElementAt(nodes.Count-1);
                nodes.RemoveAt(nodes.Count - 1);
                if (current != null)
                {
                    yield return current;
                    if (node.HasParent)
                        nodes.Add(current.Parent);
                }
            }
        }

        public static IEnumerable<IHaveChildren<T>> PathToFirstLeafBreathFirst<T>(this IHaveChildren<T> node)
        {
            if (node == null)
            {
                throw new Exception("Node is null");
            }
            if (node.Children == null)
            {
                throw new Exception("node.Children is null");
            }
            if (!node.Children.Any())
            {
                yield return node;
            }
            IList<IHaveChildren<T>> nodes = new List<IHaveChildren<T>>();
            nodes.Add(node);
            while (nodes.Count > 0)
            {
                var current = nodes.ElementAt(nodes.Count-1);
                nodes.RemoveAt(nodes.Count - 1);
                if (current != null)
                {
                    yield return current;
                    foreach (var child in current.Children)
                    {
                        nodes.Add(child);
                    }
                }
            }
        }
    }
}
