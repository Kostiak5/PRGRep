using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {

        class Node
        {
            private int index;
            private List<Node> neighbors;

            public Node(int index)
            {
                this.index = index;
                neighbors = new List<Node>();
            }

            public void AddNeighbor(Node node)
            {

                if (neighbors.Contains(node))
                    Console.WriteLine("Node " + node.index + " is already a neighbor.");
                else
                {
                    neighbors.Add(node);
                    node.AddNeighbor(this);
                    Console.WriteLine("Node " + node.index + " was added.");
                }
            }

            public int GetIndex()
            {
                return index;
            }

            public int[] getNeighborIndices()
            {
                int[] indices = new int[neighbors.Count];
                for(int i = 0; i < neighbors.Count; i++)
                {
                    indices[i] = neighbors[i].index;
                }
                return indices; 
            }

            public Node MoveToNeighbor(int index)
            {
                foreach(Node neighbor in neighbors)
                {
                    if (neighbor.index == index)
                        return neighbor;
                }
                Console.WriteLine("This node is not a neighbor of " + this.index);
                return this;
            }
        }


        
        static void Main(string[] args)
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);

            node1.AddNeighbor(node4);
            node1.AddNeighbor(node6);
            node2.AddNeighbor(node3);
            node2.AddNeighbor(node5);
            node2.AddNeighbor(node6);
            //node3.AddNeighbor(node2);
            node3.AddNeighbor(node5);
            //node4.AddNeighbor(node1);
            node4.AddNeighbor(node6);
            //node5.AddNeighbor(node2);
            //node5.AddNeighbor(node3);
            //node6.AddNeighbor(node4);
            //node6.AddNeighbor(node1);

            Node currentNode = node1;
            while(true)
            {
                Console.WriteLine("Current node: " + currentNode.GetIndex());
                Console.WriteLine("Neighbors: ");
                foreach (int neighborIndex in currentNode.getNeighborIndices())
                {
                    Console.WriteLine(neighborIndex);
                }
                Console.WriteLine("Choose where to go.");
                int desiredNeighbor = Int32.Parse(Console.ReadLine());
                currentNode = currentNode.MoveToNeighbor(desiredNeighbor);
            }

            Console.ReadKey();
        }
    }
}
