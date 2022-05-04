using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class Data
    {
        MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
        MySqlConnection connection;

        void InitializeConnection()
        {
            stringBuilder.Server = "127.0.0.1";
            stringBuilder.UserID = "root";
            stringBuilder.Password = "";
            stringBuilder.Database = "labex4";
            connection = new MySqlConnection(stringBuilder.ConnectionString);
        }

        public string InsertData(string name, string surname, string gender, string email)
        {
            try
            {
                InitializeConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO `details`(" +
                    "`Name`, " +
                    "`Surname`, `Gender`, `Email`) VALUES (" +
                    "'" + name + "'," +
                    "'" + surname + "'," +
                    "'" + gender + "'," +
                    "'" + email + "')";
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                //return stringBuilder.ToString();
                return "";
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }
  
        public string UpdateData(int id, string name, string surname, string gender, string email)
        {
            try
            {
                InitializeConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE `details` SET `Name`='" + name + "',`Surname`='" + surname + "',`Gender`='" + gender + "',`Email`='" + email + "' WHERE `ID`='" + id + "'";
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                //return stringBuilder.ToString();
                return "";
            }
            catch (Exception error)
            {

                return error.Message;
            }

        }
        public string DeleteData(int id) //id, string name, string surname, string gender, string email)
        {
            try
            {
                InitializeConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM `details` WHERE `ID`='"+id+"'";
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                //return stringBuilder.ToString();
                return "";
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }

        public DataTable ReadData()
        {
            InitializeConnection();
            connection.Open();
            string query = "SELECT * FROM `details`";
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand(query, connection);

            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
    }
}
