using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS.Models
{
    internal class Stock : Database
    {
        public int Id;
        public string Name;
        public string Location;



        protected override string[,] Fields()
        {
            return new string[,]
            {
                { "id", Id.ToString() },
                {"name", Name.ToString() },
                {"location", Location.ToString() },
            };
        }

        public Stock()
        {
            TYPE = "Stock";
        }
    }
}
