using Blazor.FileReader;
using Mentoring.OfficeBuilder.Models;
using Mentoring.OfficeBuilder.Services.UploadFile;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace Mentoring.OfficeBuilder.Pages.SVG
{
    public class SVGBase : ComponentBase
    {
        [Inject]
        public IUploadService uploadService { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public OfficeAreaModel Area { get; set; }

        public List<OfficeItemModel> UploudedSvgs { get; set; }

        public ElementReference inputTypeFileElement;

        protected async Task OnClick(OfficeItemModel model)
        {
            Area = await LoadModelsAsync(model.AreaToMove);
        }

        protected async Task OnReadFile()
        {
            UploudedSvgs = await uploadService.ReadFile(inputTypeFileElement);
        }

        protected override async Task OnInitializedAsync()
        {
            var mainModel = await LoadModelsAsync(1);

            Area = mainModel;
        }

        private async Task<OfficeAreaModel> LoadModelsAsync(int areaModelId)
        {
            return await Http.GetJsonAsync<OfficeAreaModel>("https://localhost:44327/" + "api/Svg/" + areaModelId);
        }
    }
}
