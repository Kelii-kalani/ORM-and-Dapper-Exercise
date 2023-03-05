using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.IO;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            #region department region
            //var departmentRepo = new DapperDepartmentRepository(conn);

            //departmentRepo.InsertDepartment("mikes new department");

            // var departments = departmentRepo.GetAllDepartments();

            //foreach (var department in departments)
            //{
            // Console.WriteLine($"Dept.ID: {department.DepartmentID}");
            //Console.WriteLine($"Dept.Name: {department.Name}");
            // Console.WriteLine();
            //Console.WriteLine();
            //}
            #endregion
            #region Product region
            var productRepo = new DapperProuctRepository(conn);

            //var productToUpdate = productRepo.GetProduct(940);

            //productToUpdate.Name = "UPDATED!!!";
            //productToUpdate.Price = 10.99;
            //productToUpdate.CategoryID = 1;
            //productToUpdate.OnSale = false;
            //productToUpdate.StockLevel = 1000;

            //productRepo.UpdateProduct(productToUpdate);

            productRepo.DeleteProduct(940);

            var products = productRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductID}");
                Console.WriteLine($"Product name: {product.Name}");
                Console.WriteLine($"Product price: {product.Price}");
                Console.WriteLine($"Product categoryID: {product.CategoryID}");
                Console.WriteLine($"Product on sale: {product.OnSale}");
                Console.WriteLine($"Product stock level: {product.StockLevel}");
                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion
        }
    }
}
