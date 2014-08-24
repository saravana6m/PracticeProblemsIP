using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeProblems
{
    class Decoder
    {
        // dictionary to hold the key and code mappings
        private Dictionary<string, char> codeToLetterMap = new Dictionary<string, char>();

        // code length assume 26 letters only

        private const int CODE_LENGTH = 26;
        public Decoder()
        {
            char character = 'a';
            for (int code = 1; code <= CODE_LENGTH; code++)
            {
                codeToLetterMap.Add(code.ToString(), character);
                character++;
            }
        }

        public int Decode(string inputText) 
        {
            return 0;
        }        
    }
}
