﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;

namespace TimeCheckerWPF.Classes
{
    class ConnectionSQL
    {

        public static string GetConnectionsStrings()
        {
            string strConString = Properties.Settings.Default.TimeCheckerConnectionString;
            //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            return strConString;
        }



        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static DataTable tblData;
        public static SqlDataAdapter sql_adapt;

        //public static string ReadToTextBox()
        //{
        //    SqlCommand command = new SqlCommand("use TimeChecker select * from Timeentry", con);
        //    SqlDataReader reader = null;
        //    reader = command.ExecuteReader();

        //    string s = " ";


        //    while (reader.Read())
        //    {

        //        s = s + reader["Comment"] + " " + reader["User"] + " \n".ToString();

        //    }

        //    return s;
        //}

        //public static string ReadToListBox()
        //{
        //    SqlCommand command = new SqlCommand("use TimeChecker select * from Timeentry", con);
        //    SqlDataReader reader = null;
        //    reader = command.ExecuteReader();

        //    string s = " ";


        //    while (reader.Read())
        //    {

        //        // s = s + reader["Comment"] + " " + reader["User"] + " \n".ToString();
        //        s = s + reader["Type"];

        //    }

        //    return s;
        //}


        public static void openConnection()
        {

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetConnectionsStrings();
                    con.Open();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("The system failed to establish a connection." + Environment.NewLine +
                                "Descriptions: " + ex.Message.ToString(), "C# Connect to SQL Server", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }

        }

        public static void closeConnection()
        {

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("The connection could not closed." + Environment.NewLine +
                "Descriptions: " + ex.Message.ToString(), "C# Connect to SQL Server", MessageBoxButton.OK,
                MessageBoxImage.Error);

            }


        }

    }
}



