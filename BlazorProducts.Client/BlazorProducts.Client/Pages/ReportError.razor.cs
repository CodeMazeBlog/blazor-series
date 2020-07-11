using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Client.Pages
{
    public partial class ReportError
    {
        [Parameter]
        public int ErrorCode { get; set; }

        [Parameter]
        public string ErrorDescription { get; set; }
    }
}
