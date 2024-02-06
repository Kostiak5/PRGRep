using System;

namespace GraphPlayground
{
    internal class Program
    {
        public static void DFS(Graph graph, Node startNode, Node targetNode = null)
        {
            startNode.visited = true;
            Node currentNode = startNode;
            while(true)
            {
                Console.WriteLine(currentNode.index + " je aktualni uzel");
                Node availableNeighbor = null;
                foreach(Node neighbor in currentNode.neighbors)
                {
                    if(!neighbor.visited)
                    {
                        availableNeighbor = neighbor;
                        break;
                    }
                        
                }
                if(availableNeighbor == null)
                {
                    if(currentNode == startNode)
                    {
                        Console.WriteLine("Konec");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Navrat do uzlu " + currentNode.cameFrom.index);
                        currentNode = currentNode.cameFrom;
                    }
                        
                }
                else
                {
                    Console.WriteLine("Jdu od " + currentNode.index + " do " + availableNeighbor.index);
                    availableNeighbor.visited = true;
                    availableNeighbor.cameFrom = currentNode;
                    currentNode = availableNeighbor;
                }
            }
        }

        public static void BFS(Graph graph, Node startNode, Node targetNode = null) 
        {
            for(int i = 0; i < startNode.neighbors.Count; i++)
            {
                Console.WriteLine(startNode.neighbors[i]);
            }
        }

        static void Main(string[] args)
        {
            //Create and print the graph
            Graph graph = new Graph();
            graph.PrintGraph();
            graph.PrintGraphForVisualization();

            //Call both algorithms with a random starting node
            Random rng = new Random();
            DFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);
            BFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);

            Console.ReadKey();
        }
    }
}
