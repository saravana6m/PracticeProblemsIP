using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PracticeProblems
{
    public class CommonChild
    {
        int[,] lcsMap; // map used to memoize the results

        private const int UNDEFINED = int.MinValue;

        void Init(int lengthX, int lengthY)
        {
            lcsMap = new int[lengthX, lengthY];

            for (int row = 0; row < lengthX; row++)
            {
                for (int column = 0; column < lengthY; column++)
                {
                    lcsMap[row, column] = UNDEFINED;
                }

            }
        }

        public int commonChildLength(string x, string y)
        {
            Init(x.Length, y.Length);
            
            return commonChildLengthFinder(x, y, x.Length - 1, y.Length - 1);

            
        }

        int Cost(char a, char b)
        {
            // if the characters matches then increase the lcs length by 1 otherwise 0.
            return a == b ? 1 : 0;
        }

        int commonChildLengthFinder(string X, string Y, int xIndex, int yIndex)
        {
            if (xIndex == -1 || yIndex == -1) return 0;
            
            if (lcsMap[xIndex, yIndex] != UNDEFINED)
                return lcsMap[xIndex, yIndex];

            int lcsExcludingLastCharOfXandY = Cost(X[xIndex], Y[yIndex]) + commonChildLengthFinder(X, Y, xIndex - 1, yIndex - 1);
            int lcsSkippingLastCharOfX = commonChildLengthFinder(X, Y, xIndex - 1, yIndex);
            int lcsSkippingLastCharOfY = commonChildLengthFinder(X, Y, xIndex, yIndex - 1);

            lcsMap[xIndex, yIndex] = Math.Max(
                lcsExcludingLastCharOfXandY,
                Math.Max(lcsSkippingLastCharOfX, 
                lcsSkippingLastCharOfY)
                );
             
            return lcsMap[xIndex, yIndex];
        }
    }
}
