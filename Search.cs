using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AliacSearchAlgo;

namespace AISearchSample
{
    class Search
    {
        Fringes fringe;
        ArrayList n;
        bool start=false;

        public Search(ArrayList nodes,int type) 
        {
           if(type==1)//DFS 
            fringe = new Fringe2();
           if(type==2)//BFS
            fringe = new Fringe();
            n = nodes;
            

        }

        public void setStart(Node n)
        {
            n.Start = true;
        }

        public void setGoal(Node n) 
        {
            n.Goal = true;
        }

        public Node search()
        {
            MessageBox.Show("Search being used");
            Dictionary<Node, int> nodeSteps = new Dictionary<Node, int>();

            Node explored = null;
            Node goalNode = null;
            int minSteps = int.MaxValue;

            // Find Start node and add to fringe with initial step count = 0
            foreach (Node node in n)
            {
                if (node.Start == true)
                {
                    fringe.add(node, null); // Add the start node to the fringe
                    nodeSteps[node] = 0;    // Start node at step 0
                    break;
                }
            }

            Node explorer = null;

            while ((explorer = fringe.remove()) != null)
            {
                int currentStep = nodeSteps[explorer]; // Get the current node's step count

                if (explorer.Goal == true) // If goal is found
                {
                    explorer.Expanded = true;

                    // Compare if it is better than the minimum
                    if (currentStep < minSteps)
                    {
                        minSteps = currentStep;
                        goalNode = explorer;
                    }
                }

                // Get neighbors and add them to the fringe
                ArrayList neighbors = explorer.getNeighbor();
                foreach (Node neighbor in neighbors)
                {
                    if (!neighbor.Expanded && !nodeSteps.ContainsKey(neighbor)) // Only add unexplored nodes
                    {
                        fringe.add(neighbor, explorer); // Add neighbor to the fringe
                        nodeSteps[neighbor] = currentStep + 1; // Increment step count for neighbor
                    }
                }

                explorer.Expanded = true;
                explored = explorer;
            }

            // Return the goal node found with the least steps, or null if no goal was found
            if (goalNode != null)
            {
                MessageBox.Show("Goal found at " + goalNode.Name + " in " + (minSteps) + " steps");
            }
            else
            {
                MessageBox.Show("Goal not found");
            }

            return goalNode; // Return the node to the goal with the least steps
        }



        public Node searchone()
        {
            //MessageBox.Show("Search One being used"); wala nagamit :((

            Node explored = null;

            // Find Start node and add to fringe
            foreach (Node node in n)
            {
                // If only one node
                if (node.Start == true)
                {
                    fringe.add(node, null); 
                    break;
                }
            }

            Node explorer = null;
            ArrayList neighbors;
            Object[] neighborArray;

            // Not only one nodes
            while ((explorer = fringe.remove()) != null)
            {
                if (explorer.Goal == true)
                {
                    explorer.Expanded = true;
                    MessageBox.Show("Goal found at " + explorer.Name);
                    return explorer;
                }

                // Get neighbors and add them to the fringe
                neighbors = explorer.getNeighbor();
                neighborArray = neighbors.ToArray();

                foreach (Node neighbor in neighborArray)
                {
                    if (!neighbor.Expanded)
                    {
                        fringe.add(neighbor, explorer);
                    }
                }

                explorer.Expanded = true;
                explored = explorer;
            }

            return explored;
        }
    }
}
