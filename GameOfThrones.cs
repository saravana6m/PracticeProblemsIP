using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    public class GameOfThrones
    {
        public const int MAX_CHARSET_SIZE = 26;
        public const char BASE_CHAR = 'a';

        int[] map = new int[MAX_CHARSET_SIZE];
        int MOD_VALUE = 1000000007;

        private void initMap()
        {
            for (int current = 0; current < MAX_CHARSET_SIZE; current++)
            {
                map[current] = 0;
            }
        }

        public bool PalindromeChecker(string text)
        {
            initMap();
            int location;
            int baseLocation = (int) BASE_CHAR;
            foreach (char letter in text)
            {
                location = (int)letter - baseLocation;
                map[location] = (map[location] + 1) % 2;
            }

            int oddCount = 0;

            for (int current = 0; current < MAX_CHARSET_SIZE; current++)
            {
                if (map[current] > 0)
                    oddCount++;
            }
            return oddCount <= 1 ? true : false;            
        }

        // 9:59

        void swap(int[] array, int i, int j)
        {
            int temp;
            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public int CountPalindromes(string text)
        {
            int palindromes = 1;
            initMap();
            int location;
            int baseLocation = (int) BASE_CHAR;
            foreach (char letter in text)
            {
                location = (int)letter - baseLocation;
                map[location] += 1;
            }

            int length = 0;
            for (int current = 0; current < MAX_CHARSET_SIZE; current++)
            {
                map[current] /= 2;
                length += map[current];
            }

            Console.WriteLine("Length:" + length);
            int nonZeroIndex = -1;
        
            for (int current = 0; current < MAX_CHARSET_SIZE; current++)
            {
                if (map[current] > 0)
                {
                    nonZeroIndex++;
                    swap(map, nonZeroIndex, current);
                }
            }           
           
            int temp = 2;
            int k = 0;
            for (int current = 2; current <= length; current++)
            {
                palindromes *= current;
                if (current % 5 == 0)
                {
                    Console.WriteLine("K=" + k + "Temp: " + temp + "value:" + map[k]);
                    Console.WriteLine(palindromes);
                    Console.ReadLine();
                }

                while (palindromes % temp == 0 && k <= nonZeroIndex && temp <= map[k])
                {
                    palindromes /= temp;
                    temp++;
                }
                if (k <= nonZeroIndex && temp > map[k])
                {
                    temp = 2;
                    k++;
                }
            }



            /*while (k <= nonZeroIndex)
            {
                while (palindromes % temp == 0 && temp <= map[k])
                {
                    palindromes /= temp;
                    temp++;
                }

                if (temp > map[k])
                {
                    temp = 2;
                    k++;
                }               
            }*/

            Console.WriteLine("Final value:" + palindromes % MOD_VALUE);

            return palindromes % MOD_VALUE;
        }
    }  
}
