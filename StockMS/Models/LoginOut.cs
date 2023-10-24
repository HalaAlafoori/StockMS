using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS.Models
{
    public class LoginOut : Database
    {
        //public int Id;
        public int UserId;
        public int InOut;
        public string Date;



        protected override string[,] Fields()
        {
            return new string[,]
            {
                //{ "id", Id.ToString() },
                {"user_id", UserId.ToString() },
                {"in_out", InOut.ToString() },
                {"date", Date.ToString() },
            };
        }

        public LoginOut()
        {
            TYPE = "loginout";
        }
    }
}
