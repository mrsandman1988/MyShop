using MyShop.Data;
using MyShop.Data.Entities;
using MyShop.Models;
using MyShop.Services;
namespace MyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            var result = productService.GetByFilter(new ProductFilterModel() {FromPrice = 2000 });
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Name} {item.Price}");
            }
        }
    }
}