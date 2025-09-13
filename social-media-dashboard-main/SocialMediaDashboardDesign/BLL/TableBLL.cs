using SocialMediaDashboardDesign.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaDashboardDesign.BLL
{
    public class TableBLL
    {
        private readonly TableDAL tableDAL;

        public TableBLL()
        {
            tableDAL = new TableDAL();
        }

        public DataTable GetAllTables()
        {
            return tableDAL.GetAllTables();
        }

        public DataRow GetTableById(int tableId)
        {
            return tableDAL.GetTableById(tableId);
        }

        public bool AddTable(string tableNumber, string status)
        {
            if (string.IsNullOrWhiteSpace(tableNumber)) return false;
            return tableDAL.InsertTable(tableNumber, status);
        }

        public bool UpdateTableStatus(int tableId, string status)
        {
            if (tableId <= 0) return false;
            return tableDAL.UpdateTable(tableId, status);
        }

        public bool DeleteTable(int tableId)
        {
            if (tableId <= 0) return false;
            return tableDAL.DeleteTable(tableId);
        }
    }
}
