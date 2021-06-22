using Microsoft.AspNetCore.Components;

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
