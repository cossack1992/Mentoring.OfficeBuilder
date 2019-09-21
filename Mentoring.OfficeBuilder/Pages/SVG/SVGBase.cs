using Blazor.FileReader;
using Mentoring.OfficeBuilder.Models;
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
        public IFileReaderService fileReaderService { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public List<OfficeItemModel> Models { get; set; }

        public List<OfficeItemModel> UploudedSvgs { get; set; }

        public ElementReference inputTypeFileElement;

        protected async Task OnClick(OfficeItemModel model)
        {
            Models = await LoadModelsAsync(model.Children);
        }

        protected async Task ReadFile()
        {
            var svgs = new List<string>
                ();
            var tasks = new List<Task<string>>();
            foreach (var file in await fileReaderService.CreateReference(inputTypeFileElement).EnumerateFilesAsync())
            {
                tasks.Add(ReadFile(file));
            }

            var processingTasks = tasks.Select(AwaitAndProcessAsync).ToList();

            var allTasks = await Task.WhenAll(processingTasks);

            UploudedSvgs = new List<OfficeItemModel>();

            foreach (var file in allTasks)
            {
                Console.WriteLine(file);

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(file);

                Console.WriteLine(xmlDocument.FirstChild.FirstChild.InnerXml);
                XmlNodeList nodes = xmlDocument.GetElementsByTagName("g");

                Console.WriteLine(nodes.Count);

                foreach (XmlNode node in nodes)
                {
                    var model = new OfficeItemModel
                    {
                        Svg = node.InnerXml
                    };
                    UploudedSvgs.Add(
                        model
                        );
                    Console.WriteLine(model.Svg);
                }
            }
        }

        async Task<string> AwaitAndProcessAsync(Task<string> task)
        {
            try
            {
                return await task;
            }
            catch
            {
                throw new Exception();
            }
        }

        private async Task<string> ReadFile(IFileReference file)
        {
            using (MemoryStream memoryStream = await file.CreateMemoryStreamAsync(4096))
            {
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var mainModel = await Http.GetJsonAsync<OfficeItemModel>("https://localhost:44327/" + "api/Svg/GetMainSvg");

            Models = new List<OfficeItemModel> { mainModel };
        }

        private async Task<List<OfficeItemModel>> LoadModelsAsync(List<int> ids)
        {
            var request = new GetItemsRequest { Ids = ids };
            return await Http.PostJsonAsync<List<OfficeItemModel>>("https://localhost:44327/" + "api/Svg/Post", request);
        }
    }
}
