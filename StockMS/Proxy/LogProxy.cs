using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS
{
    internal class LogProxy: IUserLog
    {
        private IUserLog _Log;

        public LogProxy()
        {
            // Instantiate the user log implementation
            _Log = new UserLog();
        }

        //public void Log(int userId, int rowId, string tableName, string type)
        public void Log(UserLogModel newLog)
        {
            // Additional functionality before logging
            newLog.Date = DateTime.Now.ToString();

            try
            {
                // Call the actual log implementation
                _Log.Log(newLog);
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                Console.WriteLine($"Error logging user operations: {ex.Message}");
            }

            // Additional functionality after logging
        }
    }
}
