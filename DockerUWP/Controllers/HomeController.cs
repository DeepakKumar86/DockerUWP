using System.Diagnostics;
using DockerUWP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

namespace DockerUWP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ProductDb;Trusted_Connection=True;";

            // Define the SQL query
            string query = "select top 1  * from ProductTable";

            // Create a connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Read and display the data
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}, {reader[1]}"); // Adjust indexes or column names as needed
                        string str = reader[2].ToString(); 
                        ViewBag.str = str;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
