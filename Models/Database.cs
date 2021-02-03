using System;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Database
    {
        readonly SqlConnection sqlConnection;
        public Database()
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
            Debug.WriteLine("connected to database");
        }
        public int GetMaxId()
        {
            var dataCommand = new SqlCommand();
            dataCommand.Connection = sqlConnection;
            dataCommand.CommandText = "SELECT MAX(Id) From Tree";
            dataCommand.ExecuteNonQuery();
            int id = Convert.ToInt32(dataCommand.ExecuteScalar());
            return id;
        }
        public int GetData(int id)
        {
            var dataCommand = new SqlCommand();
            dataCommand.Connection = sqlConnection;
            dataCommand.CommandText = "SELECT Data From Tree Where id=" + id;
            dataCommand.ExecuteNonQuery();
            int data = Convert.ToInt32(dataCommand.ExecuteScalar());
            return data;
        }
        public int GetParentId(int id)
        {
            var dataCommand = new SqlCommand();
            dataCommand.Connection = sqlConnection;
            dataCommand.CommandText = "SELECT ParentId From Tree Where id=" + id;
            dataCommand.ExecuteNonQuery();
            int parentId = Convert.ToInt32(dataCommand.ExecuteScalar());
            return parentId;
        }
        public int GetHeight(int id)
        {
            var dataCommand = new SqlCommand();
            dataCommand.Connection = sqlConnection;
            dataCommand.CommandText = "SELECT height From Tree Where id=" + id;
            dataCommand.ExecuteNonQuery();
            int height = Convert.ToInt32(dataCommand.ExecuteScalar());
            return height;
        }
        public TreeModel<int> CreateList()
        {
            TreeModel<int> list = new TreeModel<int>(GetData(1),0,1);
            for (int i = 2; i < GetMaxId()+1; i++)
            {
                list.AddChild(GetData(i), GetParentId(i), GetHeight(i));
                Debug.WriteLine(list.Children[i-2].Data); 
            }
            return list;
        }
        public void EditingData(int id,int data)
        {
            var dataCommand = new SqlCommand();
            dataCommand.Connection = sqlConnection;
            dataCommand.CommandText = "UPDATE Tree SET Data ="+data+" Where id=" + id;
            dataCommand.ExecuteNonQuery();            
        }
        public void Delete(int id)
        {
            var dataCommand = new SqlCommand();
            dataCommand.Connection = sqlConnection;
            dataCommand.CommandText = "DELETE FROM Tree WHERE Id = "+id;
            dataCommand.ExecuteNonQuery();
        }

     /*   public static string ConnectionString
        {
            get
            {
                return  ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            set { }
        }*/
    }
}
