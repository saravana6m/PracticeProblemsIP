using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PracticeProblems
{

    public class ReverseParentTree
    {

        /* array to hold tree nodes */
       
        private int[] tree;

        /* maximum no of nodes as per the problem definition */

        public const int MAX_NODES = 50;
       
        public const int UNDEFINED = -9999;

        public const int CHILDREN_COUNT = 2;

        public const int LEFT_CHILD = 0;

        public const int PARENT_OF_ROOT = -1;

        public const int RIGHT_CHILD = 1;

        public const int EOL = 9999; //End of level
        
        private int[,] parentChildrenMap = new int[MAX_NODES, CHILDREN_COUNT];

        public ReverseParentTree()
        {
            Init();
        }
      

        public void Init()
        {
            for (int nodeNo = 0; nodeNo < MAX_NODES; nodeNo++)
            {
                for (int childNo = 0; childNo < CHILDREN_COUNT; childNo++)
                {
                   parentChildrenMap[nodeNo, childNo] = UNDEFINED;
                }             
            }        
        }

        int[] levelOrderWalkQueue = new int[2 * MAX_NODES];
        private int readInt()
        {
            return Int32.Parse(Console.ReadLine());
        }
       
        public void PrintLevelOrderWalkReverse(int[] tree)
        {
           
            /* transform the tree into convenient structure to look up 
             * here is the structure
             * [parent] -> [leftchild, rightchild]
             */

            int parentId;
            int rootNodeId = 0;

            for (int nodeId = 0; nodeId < tree.Length; nodeId++)
            {
                parentId = tree[nodeId];
                if (parentId == PARENT_OF_ROOT)
                {
                    rootNodeId = nodeId;
                } 
                else if (parentChildrenMap[parentId, LEFT_CHILD] == UNDEFINED)
                {
                    parentChildrenMap[parentId, LEFT_CHILD] = nodeId;
                }
                else if (parentChildrenMap[parentId, RIGHT_CHILD] == UNDEFINED)
                {
                    parentChildrenMap[parentId, RIGHT_CHILD] = nodeId;
                }
            }         

            PrintLevelOrderWalkReverseHelper(rootNodeId, tree.Length);
        }

        public void PrintLevelOrderWalkReverseHelper(int rootId, int totalNoOfNodes)
        {
            /* walk through the map and print level order walk */

           
            int currentNodeId;
            int queueRear = 0;
            int queueFront = 1;
            int nodesProcessed = 0;
            levelOrderWalkQueue[++queueRear] = EOL;
            levelOrderWalkQueue[++queueRear] = rootId;
            levelOrderWalkQueue[++queueRear] = EOL;
                        
            while(nodesProcessed < totalNoOfNodes)
            {
                currentNodeId = levelOrderWalkQueue[queueFront++];
                if (currentNodeId == EOL)
                {
                    levelOrderWalkQueue[++queueRear] = EOL;
                }
                else
                {
                    nodesProcessed++;

                    if (parentChildrenMap[currentNodeId, LEFT_CHILD] != UNDEFINED)
                        levelOrderWalkQueue[++queueRear] = parentChildrenMap[currentNodeId, LEFT_CHILD];
                    
                    if (parentChildrenMap[currentNodeId, RIGHT_CHILD] != UNDEFINED)
                        levelOrderWalkQueue[++queueRear] = parentChildrenMap[currentNodeId, RIGHT_CHILD];                   
                    
                }                                
            }

            /* print the level order from the level order walk queue */
           
            int end = queueRear;
            int start = 0;
            for (int nodeIndex = queueRear - 1; nodeIndex >= 0; nodeIndex--)
            {
                if (levelOrderWalkQueue[nodeIndex] == EOL)
                {
                    start = nodeIndex;
                    PrintOrder(levelOrderWalkQueue, start, end);
                    end = start;
                }

            }            
        }

        void PrintOrder(int[] levelOrder, int start, int end)
        {
            for (int current = start + 1; current < end; current++)
            {
                Console.Write(levelOrder[current]);
            }
            Console.Write("\n");
        }

        public void Drive()
        {
            /* no of nodes in the tree */
            int nodeCount = readInt();
            tree = new int[nodeCount];
            /* denotes the index of the array, in other words, holds the node number */
            int nodeNo = 0;
            string inputLine = Console.ReadLine();
            string[] nodeIds = inputLine.Split(' ');
            while (nodeNo < nodeCount)
            {
                tree[nodeNo] = int.Parse(nodeIds[nodeNo]);
                nodeNo++;                
            }

            PrintLevelOrderWalkReverse(tree);
        }

    }
}
