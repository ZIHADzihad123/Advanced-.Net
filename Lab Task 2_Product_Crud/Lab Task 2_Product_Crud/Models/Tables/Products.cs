using Lab_Task_2_Product_Crud.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab_Task_2_Product_Crud.Models.Tables
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Create(Product p)
        {
            conn.Open();
            String query = String.Format("insert into Product values ('{0}','{1}','{2}','{3}')", p.Name, p.Qty, p.Price, p.Desc);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }


        public List<Product> Get()
        {
            conn.Open();
            String query = "select * from Product";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                    Price = reader.GetDouble(reader.GetOrdinal("Price")),
                    Desc = reader.GetString(reader.GetOrdinal("Desc"))
                };
                products.Add(p);
            }

            conn.Close();
            return products;
        }
        public Product Get(int id)
        {
            conn.Open();
            String query = String.Format("select * from Product where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product p = null;
            while (reader.Read())
            {
                p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                    Price = reader.GetDouble(reader.GetOrdinal("Price")),
                    Desc = reader.GetString(reader.GetOrdinal("Desc"))
                };
            }
            conn.Close();
            return p;

        }
        public void Edit(Product p)
        {
            conn.Open();
            string query = string.Format("UPDATE Product SET Name = '{0}', Qty = '{1}', Price = '{2}', Desc = '{3}' where Id = {4}", p.Name, p.Qty, p.Price, p.Desc, p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            conn.Open();
            string query = String.Format("DELETE FROM Product WHERE id = '{0}'", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }


    }
}