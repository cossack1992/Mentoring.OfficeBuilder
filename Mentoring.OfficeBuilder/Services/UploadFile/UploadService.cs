using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Blazor.FileReader;
using Mentoring.OfficeBuilder.Models;
using Microsoft.AspNetCore.Components;
using Mentoring.OfficeBuilder.Extensions;
using HtmlAgilityPack;
using Mentoring.OfficeBuilder.Helpers;

namespace Mentoring.OfficeBuilder.Services.UploadFile
{
    public class UploadService : IUploadService
    {
        private readonly IFileReaderService fileReaderService;

        public UploadService(IFileReaderService fileReaderService)
        {
            this.fileReaderService = fileReaderService;
        }

        public async Task<List<SvgModel>> ReadFile(ElementReference elementReference)
        {
            var tasks = new List<Task<string>>();
            foreach (var file in await fileReaderService.CreateReference(elementReference).EnumerateFilesAsync())
            {
                tasks.Add(ReadFile(file));
            }

            var allTasks = await Task.WhenAll(tasks);

            var uploadedAreas = new List<SvgModel>();

            foreach (var file in allTasks)
            {
                var documentElement = HtmlDocumentHelpers.ReadHtml(file);

                HtmlDocumentHelpers.LoopAllNodes(documentElement, n => n.Id = Guid.NewGuid().ToString());

                SvgModel item = new SvgModel { Id = documentElement.Id, Html = documentElement.InnerHtml };
                uploadedAreas.Add(item);


                Console.WriteLine(item.Id);
                Console.WriteLine(item.Html);
            }

            return uploadedAreas;
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
