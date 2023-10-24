using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMS.Models
{
    public abstract class Database
    {
        public static string TYPE;
        /// <summary>
        /// Fields 
        /// </summary>
        /// <returns></returns>
        protected abstract string[,] Fields();
        public static void Add(string[,] parameters)
        {
            Connector.Operate("insert", Connector.ArrayToString(parameters), TYPE);
        }
        public static void Remove(string key, string column = "")
        {
            if (column == "") column = "name";
            string query = $"&{column}={key}";
            Connector.Operate("delete", query, TYPE);
        }
        public static string Update(string[,] parameters)
        {
            return Connector.Operate("update", Connector.ArrayToString(parameters), TYPE);
        }
        public string Update()
        {
            return Connector.Operate("update", Connector.ArrayToString(Fields()), TYPE);
            // ?? to save ??
        }
        public static string Activate(int id)
        {
            return Connector.Operate("activate", $"&id={id}", TYPE);
        }
        public static DataTable Find(string key, string column = "")
        //public static DataTable? Find(string key, string column = "")
        {
            if (column == "") column = "name";
            string query = $"&{column}={key}";
            string data = Connector.Operate("select", query, TYPE);
            if (data != "0")
            {
                var temp = JsonConvert.DeserializeObject<DataTable>(data);
                return temp;
            }
            else
            {
                return new DataTable();
            }
        }
        public static DataTable All()
        {
            string data = Connector.Operate("select", "", TYPE);
            if (data != "0")
            {
                return JsonConvert.DeserializeObject<DataTable>(data);
            }
            else
            {
                return new DataTable();
            }
        }
        public string Save()
        {
            return Connector.Operate("insert", Connector.ArrayToString(Fields()), TYPE);
        }
    }
}
