using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using BlazorProducts.Client.HttpRepository;
using Tewr.Blazor.FileReader;

namespace BlazorProducts.Client.Shared
{
    public partial class ImageUpload
    {
        private ElementReference _input;

        [Parameter]
        public string ImgUrl { get; set; }
        [Parameter]
        public EventCallback<string> OnChange { get; set; }
        [Inject]
        public IFileReaderService FileReaderService { get; set; }
        [Inject]
        public IProductHttpRepository Repository { get; set; }


        private async Task HandleSelected()
        {
            foreach (var file in await FileReaderService.CreateReference(_input).EnumerateFilesAsync())
            {
                if (file != null)
                {
                    var fileInfo = await file.ReadFileInfoAsync();
                    using (var ms = await file.CreateMemoryStreamAsync(4 * 1024))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(ms.Length)), "image", fileInfo.Name);

                        ImgUrl = await Repository.UploadProductImage(content);

                        await OnChange.InvokeAsync(ImgUrl);
                    }
                }
            }
        }
    }
}
