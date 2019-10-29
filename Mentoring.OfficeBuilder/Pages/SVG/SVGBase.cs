using Mentoring.OfficeBuilder.Models;
using Mentoring.OfficeBuilder.Services.UploadFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.Pages.SVG
{
    public class SVGBase : ComponentBase
    {
        [Inject]
        public IUploadService uploadService { get; set; }

        [Inject]
        public HttpClient Http { get; set; }
        public SvgModel UploadedSvg { get; private set; }

        public SvgModel Svg { get; set; }

        public ElementReference inputTypeFileElement;

        public List<string> SvgIds { get; set; }

        protected async Task OnClick(string id)
        {
            Svg = await LoadModelsAsync(id);
        }

        protected async Task OnReadFile()
        {
            UploadedSvg = (await uploadService.ReadFile(inputTypeFileElement)).Single();
        }

        private async Task<SvgModel> LoadModelsAsync(string id)
        {
            return await Http.GetJsonAsync<SvgModel>("https://localhost:44327/" + "api/Svg/" + id);
        }

        public async Task SaveModelsAsync()
        {
            await Http.PostJsonAsync("https://localhost:44327/" + "api/Svg", UploadedSvg);
        }


        protected override async Task OnInitializedAsync()
        {
            SvgIds = await LoadIds();
        }

        private async Task<List<string>> LoadIds()
        {
            return await Http.GetJsonAsync<List<string>>("https://localhost:44327/" + "api/Svg");
        }

        public async Task SvgClicked(ChangeEventArgs e)
        {
            var id = e.Value.ToString();

            Svg = await LoadModelsAsync(id);
            SvgIds = await LoadIds();

            this.StateHasChanged();
        }
    }
}
