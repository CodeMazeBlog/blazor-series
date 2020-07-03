using BlazorProducts.Client.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Client.Pages
{
    public partial class Products
    {
        public List<Product> ProductList { get; set; } = new List<Product>();

        [Inject]
        public IProductHttpRepository ProductRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            ProductList = await ProductRepo.GetProducts();

            //just for testing
            foreach (var product in ProductList)
            {
                Console.WriteLine(product.Name);
            }
        }

    }
}
