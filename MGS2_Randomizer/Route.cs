using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    internal class Route
    {
        public int Id;
        public int Indices;

        public Route(int id, int indices)
        {
            Id = id;
            Indices = indices;
        }
    }
}
