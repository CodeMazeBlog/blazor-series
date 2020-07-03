using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Client.Components.ProductTable
{
    public partial class ProductTable
    {
        [Parameter]
        public List<Product> Products { get; set; }
    }
}
