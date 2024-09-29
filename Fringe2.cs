using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AliacSearchAlgo;

namespace AISearchSample
{
    class Fringe2 : Fringes
    {
        Queue<Node> s;
        private HashSet<Node> visited;
        public Fringe2()
        {
            s = new Queue<Node>();
            visited = new HashSet<Node>();
        }

        public void add(Node n, Node origin)
        {

            if (visited.Contains(n))
            {
                n.Origin = n.Origin;
            }
            else
            {
                //s.Push(n);
                n.Origin = origin;
                s.Enqueue(n);
                visited.Add(n);
            }
        }

        public Node remove()
        {
            if (s.Count != 0)
                return s.Dequeue();
            //return s.Pop();
            return null;
        }
    }
}