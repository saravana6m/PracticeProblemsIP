using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    public class Encryptor
    {
        char[,] grid = new char[9, 9];

        public string Encrypt(string text)
        {
            StringBuilder encryptedText = new StringBuilder();
            double sqrt = Math.Sqrt(text.Length);
            int rowSize = (int) Math.Floor(sqrt);
            int columnSize = (int) Math.Ceiling(sqrt);
            int currentCharIndex = 0;
            if (rowSize * columnSize < text.Length)
            {
                rowSize += 1;
            }
            char currentChar;
            for (int row = 0; row < rowSize; row++)
            {
                for (int column = 0; column < columnSize; column++)
                {
                    currentChar = (currentCharIndex < text.Length) ? text[currentCharIndex] : '-';
                    grid[row, column] = currentChar;
                    currentCharIndex++;              
                }
            }

            for (int column = 0; column < columnSize; column++)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    currentChar = grid[row, column];
                    if (currentChar != '-')
                    {
                        encryptedText.Append(grid[row, column]);
                    }
                }
                encryptedText.Append(' ');
            }

            return encryptedText.ToString();     
        }

        string Decrypt(string encryptedText)
        {
            return encryptedText;
        }

    }
}
