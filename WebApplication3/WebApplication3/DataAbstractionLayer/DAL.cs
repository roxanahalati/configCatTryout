using MySql.Data.MySqlClient;
using WebApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.DataAbstractionLayer
{
    public class DAL
    {
        public User GetUserByName(string name)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=wp;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where name='" + name + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                User us = new User();
                if (myreader.Read())
                {
                    us.name = myreader.GetString("name");
                    us.username = myreader.GetString("username");
                    us.role = myreader.GetString("role");
                    us.age = myreader.GetInt16("age");
                    us.email = myreader.GetString("email");
                }
                myreader.Close();
                return us;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return null;

        }

        public List<User> GetAllUsers()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=wp;";
            List<User> slist = new List<User>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    User us = new User();

                    us.name = myreader.GetString("name");
                    us.username = myreader.GetString("username");
                    us.role = myreader.GetString("role");
                    us.age = myreader.GetInt16("age");
                    us.email = myreader.GetString("email");
                    slist.Add(us);
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return slist;

        }

        public List<User> GetUsersByRole(string role)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=wp;";
            List<User> slist = new List<User>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where role='" + role + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    User us = new User();

                    us.name = myreader.GetString("name");
                    us.username = myreader.GetString("username");
                    us.role = myreader.GetString("role");
                    us.age = myreader.GetInt16("age");
                    us.email = myreader.GetString("email");
                    slist.Add(us);
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return slist;

        }

        public void SaveUser(User user)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=wp;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into users values(" + "NULL" + ",'" + user.name + "','" + user.username + "','" + user.age + "','" + user.role + "','" + user.email + "')";
                cmd.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

        }


        public void DeleteUser(string user)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=wp;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from users where name ='" + user + "'";

                cmd.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

        }

        public void UpdateUser(string username, string role)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=wp;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update users set role='" + role + "' where username='" + username + "'";
                cmd.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

        }


        internal bool login(string name, string password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=localhost;uid=root;pwd=;database=wp;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string commandText = "select * from auth where name = @name and password = @password";
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@username", name);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader myreader = cmd.ExecuteReader();
                int cnt = 0;
                while (myreader.Read())
                {
                    cnt++;
                }
                conn.Close();
                return cnt == 1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

    }
}
