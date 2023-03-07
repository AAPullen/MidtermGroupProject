using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermGroupProject
{
    internal class Validation
    {
        // Create a method to handle yes/no answers from the user
        public bool CheckAnswer(string answer)
        {
            answer = answer.ToLower();
            if (answer == "y" || answer == "n")
            {
                return true;
            }
            return false;
        }

        public bool CheckIntent(string intent)
        {
            intent = intent.ToLower();
            if (intent == "search" || intent == "return")
            {
                return true;
            }
            return false;
        }
    }
}
