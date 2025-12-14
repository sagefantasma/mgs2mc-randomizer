using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    class RandomizedItem
    {
        public byte Index;
        public byte Count;
        public string Name;

        public RandomizedItem()
        {

        }

        public RandomizedItem(RandomizedItem item)
        {
            Index = item.Index;
            Count = item.Count;
            Name = item.Name;
        }
    }
}
