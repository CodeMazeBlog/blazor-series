using BlazorProducts.Client.HttpRepository;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestParameters;
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
        public MetaData MetaData { get; set; } = new MetaData();

        private ProductParameters _productParameters = new ProductParameters();

        [Inject]
        public IProductHttpRepository ProductRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task SelectedPage(int page)
        {
            _productParameters.PageNumber = page;
            await GetProducts();
        }

        private async Task GetProducts()
        {
            var pagingResponse = await ProductRepo.GetProducts(_productParameters);
            ProductList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _productParameters.PageNumber = 1;
            _productParameters.SearchTerm = searchTerm;
            await GetProducts();
        }

        private async Task SortChanged(string orderBy)
        {
            Console.WriteLine(orderBy);
            _productParameters.OrderBy = orderBy;
            await GetProducts();
        }
    }
}
