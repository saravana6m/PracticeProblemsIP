using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    public class GemStones
    {

        public const int MAX_CHARSET_SIZE = 26;
        public const int BASE_CHAR_VALUE = (int) 'a';

        bool[] gemStonesMap = new bool[MAX_CHARSET_SIZE];
        bool[] compositionMap = new bool[MAX_CHARSET_SIZE];

        
        private void Init(bool[] array, bool value)
        {
            for (int current = 0; current < array.Length; current++)
            {
                array[current] = value;
            }
        }

        private void InterSect(bool[] compositionMap)
        {
            for (int current = 0; current < MAX_CHARSET_SIZE; current++)
            {
                gemStonesMap[current] &= compositionMap[current];
            }
        }
       
        int CountGemStones(List<string> compositionList)
        {
            int location;
            Init(gemStonesMap, true);

            foreach (string rock in compositionList)
            {
                Init(compositionMap, false);

                foreach (char element in rock)
                {
                    location = (int)element - BASE_CHAR_VALUE;
                    compositionMap[location] = true;
                }
                
                InterSect(compositionMap);                
            }

            int gemStonesCount = 0;
            for (int current = 0; current < MAX_CHARSET_SIZE; current++)
            {
                if (gemStonesMap[current])
                {
                    gemStonesCount++;
                }
            }

            return gemStonesCount;
        }

        private int readInt()
        {
            return Int32.Parse(Console.ReadLine());
        }

        public void readInputAndPrint()
        {
            int rocksCount;
            rocksCount = readInt();

            List<string> compositionList = new List<string>(rocksCount);
            for (int p = 0; p < rocksCount; p++)
            {
                compositionList.Add(Console.ReadLine());
            }
            Console.WriteLine(CountGemStones(compositionList));
        }     
    }
}
