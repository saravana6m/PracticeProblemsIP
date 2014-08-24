using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
namespace PracticeProblems
{
    
    class Segmentor
    {
        private List<string> correctWords = new List<string>();

        private Stack outputList = new Stack();
        public bool Segment(string s, IDictionary<string, bool> words)
        {           
            if (string.IsNullOrEmpty(s))
                return true;
            if (words.ContainsKey(s))
            {
                outputList.Push(s);
                return true;
            }
                
            bool result = false;
            for (int i = 0; i < s.Length; i++)
            {
                string substring = s.Substring(0, i + 1);
                if (words.ContainsKey(substring))
                {
                    Console.WriteLine(correctWords.Count);
                    // correctWords.Add(substring);
                    outputList.Push(substring);
                    string nextString = s.Substring(i + 1);
                    result = result || Segment(nextString, words);
                    if (!result) 
                        outputList.Pop();                   
                }
            }
            return result;
        }

        public string SegmentedString()
        {
            int stackSize = outputList.Count;
            string output = string.Empty;
            while (stackSize > 0)
            {
                output = outputList.Pop().ToString() + " " + output;
                stackSize--;
            }
            return output;           
        }

    }
}
