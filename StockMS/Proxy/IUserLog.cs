using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS
{
    public interface IUserLog
    {
        void Log(UserLogModel newLog);
    }
}
