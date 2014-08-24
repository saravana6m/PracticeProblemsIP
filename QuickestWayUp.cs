using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    // https://www.hackerrank.com/challenges/the-quickest-way-up

    class QuickestWayUp
    {
        private const int BOARD_SIZE = 101;
        int[] shortestDistance = new int[BOARD_SIZE];
        int[] laddersPositions = new int[BOARD_SIZE];
        int[] snakesPositions = new int[BOARD_SIZE];


        public QuickestWayUp()
        {
            Init(shortestDistance);
        }

        private void Init(int[] array, int value = 0)
        {
            for (int current = 0; current < array.Length; current++)
            {
                array[current] = value;
            }
        }

        public int FindShortestDistance(int pos)
        {
            Printer(shortestDistance);

            if(pos == 1)  
            {
                shortestDistance[pos] = 0;
                return shortestDistance[pos];
            }
            if (pos >= 2 && pos <= 7)
            {
                shortestDistance[pos] = 1;
                return shortestDistance[pos];
            }

            if (shortestDistance[pos] != 0 && shortestDistance[pos] != int.MaxValue)
                return shortestDistance[pos];
           
            if(snakesPositions[pos] != 0) return int.MaxValue;

            int minDistance = int.MaxValue;
            if(laddersPositions[pos] != 0)
                minDistance = FindShortestDistance(laddersPositions[pos]);

            int currentDistance = 1;
            for(int diceValue = 1; diceValue <= 6; diceValue++) 
            {
                currentDistance += FindShortestDistance(pos - diceValue);

                if(currentDistance < minDistance)
                    minDistance = currentDistance;
            }
            shortestDistance[pos] = minDistance;

            return shortestDistance[pos];
        }

        public int FindShortestSteps()
        {
            Init(shortestDistance);
            shortestDistance[1] = 0;
            for (int cellNo = 2; cellNo < 8; cellNo++)
                shortestDistance[cellNo] = 1;

            int minDistance = int.MaxValue;

            for (int cellNo = 1; cellNo < BOARD_SIZE; cellNo++)
            {
                if (snakesPositions[cellNo] != 0)
                    shortestDistance[cellNo] = int.MaxValue;
            }

            int position; 
            for (int cellNo = 8; cellNo < BOARD_SIZE; cellNo++)
            {
                minDistance = int.MaxValue;
                if (laddersPositions[cellNo] != 0)
                {
                    minDistance = Math.Min(shortestDistance[laddersPositions[cellNo]], minDistance);
                }
                for (int diceValue = 1; diceValue <= 6; diceValue++)
                {
                    position = cellNo - diceValue;
                    if(snakesPositions[position] == 0)
                        minDistance = Math.Min( 1 + shortestDistance[position] , minDistance);                                                   
                }
                //Printer(shortestDistance);
                //Console.ReadLine();
                shortestDistance[cellNo] = minDistance;
            }           

            return shortestDistance[100];
        }
        public void ReadInput(string a, string b, string c)
        {
            int ladders, snakes;
            
            string temp = a;//Console.ReadLine();
            string[] results = temp.Split(',');
            ladders = Int32.Parse(results[0]);
            snakes = Int32.Parse(results[1]);
            
            temp = b;// Console.ReadLine();
            results = temp.Split(' ');
            string[] startAndEnd;

            Init(snakesPositions);
            Init(laddersPositions);

            // ladder positions
            int start, end;
            foreach (string pair in results)
            {
                startAndEnd = pair.Split(',');
                start = Int32.Parse(startAndEnd[0]);
                end = Int32.Parse(startAndEnd[1]); // its possible to reach end from start
                laddersPositions[end] = start;
            }
           
            temp = c; // Console.ReadLine();
            results = temp.Split(' ');
            // ladder positions
            
            foreach (string pair in results)
            {
                startAndEnd = pair.Split(',');
                start = Int32.Parse(startAndEnd[0]);
                end = Int32.Parse(startAndEnd[1]); // its possible to reach end from start
                snakesPositions[start] = end;
            }                 
          
        }

        void Printer(int[] array)
        {
            int counter = 1;
            for (int current = 1; current < array.Length; current++)
            {
                counter++;
                Console.Write(array[current] + " ");
                if (counter % 10 == 0)
                    Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
        }

    }
}
