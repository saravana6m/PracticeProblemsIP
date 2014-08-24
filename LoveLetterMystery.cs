using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    public class LoveLetterMystery
    {
        public const int BASE_CHAR_VALUE = (int) 'a';
        public int CountReductions(string inputText)
        {
            int reductionCount = 0;
            int start = 0;
            int minReduction;
            int end = inputText.Length - 1;
            while (start < end)
            {
                minReduction = Math.Abs(Value(inputText[start]) - Value(inputText[end]));
                reductionCount += minReduction;
                start++;
                end--;
            }
            return reductionCount;
        }

        int Value(char letter)
        {
            return (int)letter - BASE_CHAR_VALUE;
        }
    }
}
