using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    class Program
    {
        static void Main(string[] args)
        {

            /*CommonChild c = new CommonChild();
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            int lcs = c.commonChildLength(firstString, secondString);

            Console.WriteLine(lcs); */


            MinimumWindow m = new MinimumWindow();
            string output = m.GetMinimumWindow("adobecodebanc", "abc");
            Console.WriteLine(output);
        }
    }
    


}
