using Entities.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorProducts.Client.Components.ProductTable
{
	public partial class ProductTable
    {
        [Parameter]
        public List<Product> Products { get; set; }
    }
}
