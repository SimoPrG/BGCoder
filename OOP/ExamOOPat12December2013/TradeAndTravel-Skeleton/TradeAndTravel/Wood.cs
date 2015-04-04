using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null) : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }
    }
}
