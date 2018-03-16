using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseScheduler
{
    class Graph
    {
        private String[] graphEl;
        private bool[,] graph; //baris ditunjuk, kolom menunjuk
        private int[] solution;
        private int[] nodeDestroyed; //for timestamp

        public Graph(String filename)
        {
            readFromFile(filename);
        }

        private void readFromFile(String filename)
        {
            
        }

        public void DFSSolution()
        {
            //find first node
            int firstNode = -1;
            for(int row = 0; row < graph.Length; row++)
            {
                bool found = true;
                for(int col = 0; col < graph.Length; col++)
                {
                    if (graph[row,col])
                    {
                        found = false;
                    }
                }
                if (found)
                {
                    firstNode = row;
                    break;
                }
            }

            int count = 0;
            if (firstNode != -1)
            {
                DFS(firstNode, ref count);
            }

            //find adjacentless nodes 
            for(int i=0; i<graph.Length; i++)
            {
                bool found = false;
                for(int j=0; j<graph.Length; j++)
                {
                    if(graph[i,j])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    for(int j=0; j<graph.Length; j++)
                    {
                        if (graph[j,i])
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    count++;
                    nodeDestroyed[i] = count;
                }
            }

            int index = 0;
            while(nodeDestroyed.Length != 0)
            {
                int maxval = nodeDestroyed.Max();
                int max_el_idx = Array.IndexOf(nodeDestroyed, maxval);
                solution[index] = max_el_idx;
                nodeDestroyed = nodeDestroyed.Where(val => val != maxval).ToArray();
                index++;
            }

            for(int i=0; i<graphEl.Length; i++)
            {
                Console.WriteLine(graphEl[solution[i]] + ' ');
            }
            Console.WriteLine("Press any key to terminate..\n");
            Console.ReadKey();
            //Console.WriteLine(nodeDestroyed);
        
        }

        private void DFS(int node, ref int counter)
        {
            counter++;
            for(int branch = 0; branch < graph.Length; branch++)
            {
                if(graph[branch, node])
                {
                    DFS(branch, ref counter);
                }
            }
            counter++;
            nodeDestroyed[node] = counter;
        }

        public void BFS()
        {

        }

        public void Visualize()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tes!\n");
            Console.ReadKey();
        }
    }
}
