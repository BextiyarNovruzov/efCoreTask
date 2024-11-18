using EFCore.Context;
using EFCore.Helpers.Exceptions;
using EFCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Helpers
{
    public class SqlHelper
    {

        //create , register
        public static void RegisterUser(string Name, string UserName,string Password)
        {
            using (AppDbContext contect = new AppDbContext())
            {
                var user = new users
                {
                    Name = Name,
                    UserName = UserName,
                    Password = Password
                };

                contect.Users.Add(user);
                contect.SaveChanges();

            }
        }



        //read, login

        public static bool ReadUser(string userName, string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    var user = context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

                    if (user == null)
                    {
                        throw new UserNotFoundException($"User with UserName '{userName}' or given Password was not found.");
                        return false;
                    }

                    Console.WriteLine("Login successful.");
                    return true; 
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    return false;
                }
            }
        }




        /*   1 - daxil olunan zaman bütün məhsullar "Id. Name - Price" şəklində düzülsün 
               və istifadəçidən Consoledan ədəd (Id) qəbul etsin.
               Daxil olunan id-li product bazamızda varsa o zaman onu səbətə əlavə etsin.
               Məhsul tapılmadıqda isə ProductNotFoundException throwlasın.
               İstifadəçi 0 daxil edən zaman əvvəlki menyu görsənsin.
        */

        public static void GetAllProducts()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var prodcut = context.Products.ToList();
                if (prodcut.Count > 0)
                {

                    foreach (var product in prodcut)
                    {
                        Console.WriteLine($"{product.Id}. {product.Name} - {product.Price} AZN");
                    }

                }
            }

        }
        public static void AddProductToBasket(int Id, string? Name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    var product = context.Products.Find(Id);

                    if (product != null)
                    {
                        Name = Name ?? "Unknown Product";

                        context.Baskets.Add(new baskets
                        {
                            Name = Name,
                            ProductId = Id
                        });

                        context.SaveChanges();
                        Console.WriteLine("Product successfully added to the basket.");
                    }
                    else
                    {
                        throw new ProductNotFoundException("The requested product was not found.");
                    }
                }
                catch (ProductNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void GetProductsInBasket()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var baskets = context.Baskets.ToList();
                if (baskets.Count > 0)
                {

                    foreach (var product in baskets)
                    {
                        Console.WriteLine($" {product.Name} - {product.ProductId}");
                    }

                }

            }
            

        }
    }
}