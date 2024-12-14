using Lab2.DataAccess;
using Lab2.DataAccess.Migrations;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Metrics;
using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
namespace Lab2.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new DepartmentDbContext();

            db.Database.EnsureCreated();

            var results = db.Departments.Where(d => d.Nosaukums == "RTU");
            
            foreach (var Departments in results)
            {
                System.Console.WriteLine(Departments);
            }
        }
    }

}
