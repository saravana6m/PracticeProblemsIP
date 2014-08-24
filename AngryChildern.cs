using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            AngryChildern a = new AngryChildern();
            a.readInputAndPrint();
        }
    }
    class AngryChildern
    {
        int FindMinFairness(List<int> packets, int k)
        {
            packets.Sort();
           
            int minSofar = int.MaxValue;
            int maxIndex = k - 1;
            int minIndex = 0;
            int diff;
            while (maxIndex < packets.Count)
            {
                diff = packets[maxIndex] - packets[minIndex];
                if (diff < minSofar)
                    minSofar = diff;

                maxIndex++;
                minIndex++;
            }
            return minSofar;
        }

        private int readInt() 
        {
            return Int32.Parse(Console.ReadLine());
        }

        public void readInputAndPrint()
        {
            int totalPackets;
            int childrenCount;
            totalPackets = Int32.Parse(Console.ReadLine());
            childrenCount = Int32.Parse(Console.ReadLine());
            List<int> packetValues = new List<int>(totalPackets);
            for (int p = 0; p < totalPackets; p++)
            {
                packetValues.Add(readInt());
            }
            Console.WriteLine(FindMinFairness(packetValues, childrenCount));
        }        
    }
}
