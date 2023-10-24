using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS.Models
{
    public class Item : Database
    {
        public int Id;
        public string Name;
        public double Price;

        protected override string[,] Fields()
        {
            return new string[,]
            {
                { "id", Id.ToString() },
                {"name", Name.ToString() },
                {"price", Price.ToString() },
            };
        }

        public Item()
        {
            TYPE = "item";
        }
    }
}
