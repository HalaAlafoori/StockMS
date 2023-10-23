using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS.Models
{
    internal class UserLog : Database
    {
        public int Id;
        public int UserId;
        public int RowId;
        public string TableName;
        public string Type;
        public string Date;



        protected override string[,] Fields()
        {
            return new string[,]
            {
                { "id", Id.ToString() },
                {"user_id", UserId.ToString() },
                {"row_id", RowId.ToString() },
                {"table_name", TableName.ToString() },
                {"type", Type.ToString() },
                {"date", Date.ToString() },
            };
        }

        public UserLog()
        {
            TYPE = "UserLog";
        }
    }
}
