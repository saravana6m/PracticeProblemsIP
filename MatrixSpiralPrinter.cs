using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    class MatrixSpiralPrinter
    {
        int[,] elements;
        public void ReadMatrix(int rowSize, int columnSize)
        {
            elements = new int[rowSize, columnSize];
            for (int row = 0; row < rowSize; row++)
            {
                for (int column = 0; column < columnSize; column++)
                {
                    elements[row, column] = readInt();
                }
            }
        }
        
        private int readInt()
        {
            return Int32.Parse(Console.ReadLine());            
        }

        public void PrintSpiral(int rowSize, int columnSize)
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int column = 0; column < columnSize; column++)
                {
                    Console.Write(elements[row, column] + " ");
                }
                Console.WriteLine();
            }            
        }
    }
}
