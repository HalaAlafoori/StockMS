using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockMS.Models
{
    public class UserLogModel : Database
    {
        public int Id;
        public int userId;
        public int UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }
        public int rowId;
        public int RowId
        {
            get
            {
                return this.rowId;
            }
            set
            {
                this.rowId = value;
            }
        }
        public string tableName;
        public string TableName
        {
            get
            {
                return this.tableName;
            }
            set
            {
                this.tableName = value;
            }
        }
        public string type;
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        public string date;
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }



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

        public UserLogModel()
        {
            TYPE = "userlog";
        }
    }
}
