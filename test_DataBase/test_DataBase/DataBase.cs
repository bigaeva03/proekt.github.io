using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace test_DataBase
{
    class DataBase
    {
        //строка подключения
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-7R5M2K96\SQLEXPRESS; Initial Catalog=test;  Integrated Security=True"); // 1 имя сервера, 2 имя бд, 3 true

        // создание методов

        public void openConnection()// открытие связи с бд
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()// закрытие связи с бд
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection() //возвращение строки
        {
            return sqlConnection;
        }

    }

}
