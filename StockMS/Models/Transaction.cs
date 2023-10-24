using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS.Models
{
    public class Transaction : Database
    {
        public int Id;
        public int ItemID;
        public int StockId;
        public string Date;
        public int Quantitiy;
        public int Type;
        public string Details;



        protected override string[,] Fields()
        {
            return new string[,]
            {
                { "id", Id.ToString() },
                {"item_id", ItemID.ToString() },
                {"stock_id", StockId.ToString() },
                {"date", Date.ToString() },
                {"quantity", Quantitiy.ToString() },
                {"type", Type.ToString() },
                {"details", Details.ToString() },
            };
        }

        public Transaction()
        {
            TYPE = "transaction";
        }
    }
}
