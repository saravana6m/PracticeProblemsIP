using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    // http://community.topcoder.com/stat?c=problem_statement&pm=12155&rd=15177&rm=314191&cr=22639266
    public class CuttingBitString
    {
        private IDictionary<string, bool> powerOfFiveBits = new Dictionary<string, bool>();

        private const int INFINITY = 99999;
        private const int NOT_POSSIBLE = -1;
        public CuttingBitString() 
        {
            powerOfFiveBits.Add("1", true);
            powerOfFiveBits.Add("101", true);
            powerOfFiveBits.Add("11001", true);
            powerOfFiveBits.Add("1111101", true);
            powerOfFiveBits.Add("1001110001", true);
            powerOfFiveBits.Add("110000110101", true);
            powerOfFiveBits.Add("11110100001001", true);
            powerOfFiveBits.Add("10011000100101101", true);
            powerOfFiveBits.Add("1011111010111100001", true);
            powerOfFiveBits.Add("111011100110101100101", true);
        }

        public int GetMin(string bitString)
        {
            int minCuts = INFINITY;

            if(powerOfFiveBits.ContainsKey(bitString))
                return 1;
            else 
            {
                string subBits, remainingBits;
                int minCutsForRest;
                for(int currentBit = 0; currentBit < bitString.Length; currentBit++) 
                {
                    subBits = bitString.Substring(0, currentBit + 1);
                    if(powerOfFiveBits.ContainsKey(subBits)) 
                    {
                        remainingBits = bitString.Substring(currentBit + 1);
                        minCutsForRest = GetMin(remainingBits);
                        if(minCutsForRest != NOT_POSSIBLE)
                            minCuts = Math.Min(minCuts, 1 + minCutsForRest);
                    }
                }                
            }

            return (minCuts == INFINITY) ? NOT_POSSIBLE : minCuts;
        }

        public void Drive() 
        {
            string inputString = "111011100110101100101110111";
            Console.WriteLine(GetMin(inputString));
        }
    }
}
