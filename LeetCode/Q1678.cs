using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1678
{
    public class Solution
    {
        public string Interpret(string command)
        {
            return command.Replace("(al)", "al").Replace("()", "o");
        }
    }
}
