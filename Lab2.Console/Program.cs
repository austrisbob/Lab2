using Lab2.DataAccess;
using Lab2.DataAccess.Migrations;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Metrics;
using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Lab2.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            connection.Open();
            /*
            var command = connection.CreateCommand();
            command.CommandText = "SELECT";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(i: 0));
            }*/
            connection.Close();
        }
    }

}
