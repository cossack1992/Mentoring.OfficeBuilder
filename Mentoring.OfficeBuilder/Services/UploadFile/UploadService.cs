using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Blazor.FileReader;
using Mentoring.OfficeBuilder.Models;
using Microsoft.AspNetCore.Components;

namespace Mentoring.OfficeBuilder.Services.UploadFile
{
    public class UploadService : IUploadService
    {
        private readonly IFileReaderService fileReaderService;

        public UploadService(IFileReaderService fileReaderService)
        {
            this.fileReaderService = fileReaderService;
        }

        public async Task<List<OfficeItemModel>> ReadFile(ElementReference elementReference)
        {
            var tasks = new List<Task<string>>();
            foreach (var file in await fileReaderService.CreateReference(elementReference).EnumerateFilesAsync())
            {
                tasks.Add(ReadFile(file));
            }

            var allTasks = await Task.WhenAll(tasks);

            var UploudedSvgs = new List<OfficeItemModel>();

            foreach (var file in allTasks)
            {
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

                    UploudedSvgs.Add(model);
                }
            }

            return UploudedSvgs;
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
    }
}
