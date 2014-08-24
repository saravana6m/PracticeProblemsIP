using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    // start time 2:12, 2:37

    public class MinimumWindow
    {
        const int CHAR_SIZE = 26;

        const int CHAR_A = (int) 'a';

        int[] currentMap = new int[CHAR_SIZE];
        int[] targetMap = new int[CHAR_SIZE];


        void Init(int[] array, int value = 0)
        {
            for (int current = 0; current < array.Length; current++)
            {
                array[current] = value;
            }
        }

        public string GetMinimumWindow(string subject, string target)
        {
            int start = 0;
            int end = subject.Length - 1;

            int tempStart;
            int tempEnd;

            int windowLength = end - start + 1;
            int currentWindowLength;
            // temporary start location
            Init(currentMap);
            Init(targetMap);

            // build the target Map

            int location;
            foreach (char letter in target)
            {
                Add(targetMap, letter);
            }

            for (int current = 0; current < subject.Length; current++)
            {
                location = (int) subject[current] - CHAR_A;

                if (targetMap[location] != 0)
                {
                    Console.WriteLine("Processing: " + current + " value:" + subject[current]);
                    currentMap[location] += 1;
                    if (lessThanOrEqual(targetMap, currentMap))
                    {
                        tempEnd = current; // reset the new end point
                        // advance start as much as possible
                        // remove the subject[start] from the window and then check
                        tempStart = start;

                        while (lessThanOrEqual(targetMap, currentMap))
                        {
                            Console.WriteLine("target map Before");  Print(targetMap);
                            Console.WriteLine("current map Before"); Print(currentMap);
                            Console.WriteLine("Advancing start to: " + tempStart);
                            Remove(currentMap, subject[tempStart]);
                            Console.WriteLine("current map After"); Print(currentMap);
                            tempStart++;
                        }
                        for (int t = tempStart - 1; t >= start; t--)
                        {
                            Console.WriteLine("Adding " + subject[tempStart] + " back to table");
                            location = (int)subject[t] - CHAR_A;
                            if(targetMap[location] != 0) 
                                Add(currentMap, subject[tempStart]);
                        }

                        tempStart = tempStart - 1;

                        currentWindowLength = tempEnd - tempStart + 1;

                        if (currentWindowLength < windowLength)
                        {
                            start = tempStart;
                            end = tempEnd;
                            windowLength = currentWindowLength;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" Else : Processing: " + current + " value:" + subject[current]);
                }
            }

            return subject.Substring(start, windowLength);
        }

        // helper methods

        void Add(int[] map, char letter)
        {
            int location = (int)letter - CHAR_A;
            map[location] += 1;
        }

        void Remove(int[] map, char letter)
        {
            int location = (int)letter - CHAR_A;
            if(map[location] > 0 )
                map[location] -= 1;
        }
        
        bool lessThanOrEqual(int[] mapA, int[] mapB)
        {
            for (int current = 0; current < mapA.Length; current++)
            {
                if (mapA[current] > mapB[current])
                    return false;
            }

            return true;
        }

        void Print(int[] map)
        {
            for (int current = 0; current < map.Length; current++)
            {
                Console.Write(map[current]);
            }
            Console.WriteLine();
        }
    }
}
