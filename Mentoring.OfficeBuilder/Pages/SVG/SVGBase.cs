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

        private string selectedId;

        public SvgModel Svg { get; set; }

        public ElementReference inputTypeFileElement;

        public List<string> SvgIds { get; set; }

        protected async Task OnClickApplyTransaction(string id)
        {
            Svg = await LoadTransactionSvgAsync(id);
        }

        protected async Task OnClickAddTransaction(string id)
        {
            await SaveTransaction(id);
        }

        private async Task SaveTransaction(string id)
        {
            Console.WriteLine(id + ":" + selectedId);
            await Http.PostJsonAsync(
                "https://localhost:44327/" + "api/Transition",
                new Transition {ElementId = Guid.Parse(id), SvgId = Guid.Parse(selectedId) });
            Console.WriteLine("klv;ovi;");
        }

        protected async Task OnReadFile()
        {
            UploadedSvg = (await uploadService.ReadFile(inputTypeFileElement)).Single();
        }

        private async Task<SvgModel> LoadSvgAsync(string id)
        {
            return await Http.GetJsonAsync<SvgModel>("https://localhost:44327/" + "api/Svg/" + id);
        }

        private async Task<SvgModel> LoadTransactionSvgAsync(string id)
        {
            return await Http.GetJsonAsync<SvgModel>("https://localhost:44327/" + "api/Transition/" + id);
        }

        public async Task SaveModelsAsync()
        {
            await Http.PostJsonAsync("https://localhost:44327/" + "api/Svg", UploadedSvg);

            SvgIds = await LoadIds();

            this.StateHasChanged();
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
            selectedId = e.Value.ToString();

            Svg = await LoadSvgAsync(selectedId);

            this.StateHasChanged();
        }
    }
}
