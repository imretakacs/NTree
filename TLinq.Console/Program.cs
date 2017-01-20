using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;
using System.IO;
using TLinq.Hierarchy;

namespace TLinq.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Users\imretakacs\OneDrive\Visual Studio Projects\Bardrobe.Api\TLinq.Console\TLinq.Console\log.txt";
            var simpleTreeRoot = new SimpleTree
            {
                Name = "Root1",
                Children = new List<SimpleTree>()
            };

            
            for (int j = 0; j < 10; j++)
            {
                var simpleNode = new SimpleTree
                {
                    Name = "Node0",
                    Parent = simpleTreeRoot,
                    Children = new List<SimpleTree>()
                };
                simpleTreeRoot.Children = new List<SimpleTree>();
                simpleTreeRoot.AddChildren(simpleNode);
                SimpleTree tree = simpleNode;
                for (int i = 1; i < 10000; i++)
                {
                    var node = new SimpleTree
                    {
                        Name = $"Node{i}",
                        Parent = tree,
                        Children = new List<SimpleTree>()
                    };
                    tree.AddChildren(node);
                    tree = node;
                }

                Stopwatch sw = new Stopwatch();
                sw.Start();
                foreach (var child in simpleTreeRoot.PathToFirstLeafBreathFirst())
                {
                    
                }
                sw.Stop();

                File.AppendAllText(path, sw.Elapsed.TotalMilliseconds + Environment.NewLine);
                System.Console.WriteLine("Elapsed={0}", sw.Elapsed.TotalMilliseconds);
            }
            System.Console.ReadKey();
        }
    }

    public class SimpleTree : IHasParent<SimpleTree>, IHasChildren<SimpleTree>
    {
        private IList<IHasChildren<SimpleTree>> _children;
        private IHasParent<SimpleTree> _parent;

        public bool HasParent { get; private set; }

        public IHasParent<SimpleTree> Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                HasParent = _parent != null;
            }
        }

        public string Name { get; set; }

        public IEnumerable<IHasChildren<SimpleTree>> Children
        {
            get { return _children; }
            set { _children = value.ToList(); }
        }

        public void AddChildren(SimpleTree node)
        {
            _children.Add(node);
        }
    }
}
