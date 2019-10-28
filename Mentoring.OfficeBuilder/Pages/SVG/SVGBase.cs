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
        public List<SvgModel> Svgs { get; private set; }

        public SvgModel Svg { get; set; }

        public ElementReference inputTypeFileElement;

        public List<string> SvgIds { get; set; }

        protected async Task OnClick(string id)
        {
            Svg = await LoadModelsAsync(id);
        }

        protected async Task OnReadFile()
        {
            Svgs = await uploadService.ReadFile(inputTypeFileElement);
        }

        private async Task<SvgModel> LoadModelsAsync(string id)
        {
            return await Http.GetJsonAsync<SvgModel>("https://localhost:44327/" + "api/Svg/" + id);
        }

        public async Task SaveModelsAsync()
        {
            await Http.PostJsonAsync("https://localhost:44327/" + "api/Svg", Svgs);
        }


        protected override async Task OnInitializedAsync()
        {
            SvgIds = await Http.GetJsonAsync<List<string>>("https://localhost:44327/" + "api/Settings/GetSvgIds");
        }

        public async Task SvgClicked(ChangeEventArgs cityEvent)
        {
            var id = cityEvent.Value.ToString();

            Svg = await LoadModelsAsync(id);

            this.StateHasChanged();
        }
    }
}
