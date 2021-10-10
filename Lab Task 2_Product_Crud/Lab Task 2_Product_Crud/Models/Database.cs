using Lab_Task_2_Product_Crud.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab_Task_2_Product_Crud.Models
{

    public class Database
    {
        SqlConnection conn;

        public Products Products { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-UDSS3BQ\SQLEXPRESS; Database=UMS; Integrated Security=true ";
            conn = new SqlConnection(connString);
            Products = new Products(conn);
        }
    }
}