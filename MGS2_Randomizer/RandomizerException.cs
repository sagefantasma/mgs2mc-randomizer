using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    public class RandomizerException : Exception
    {
        public RandomizerException(string message) : base(message)
        {
        }
    }
}
