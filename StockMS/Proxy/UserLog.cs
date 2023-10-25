using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS
{
    internal class UserLog : IUserLog
    {
        public void Log(UserLogModel newLog)
        {
            UserFacade.AddUserLog(newLog);
        }
    }
}
