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

namespace Mentoring.OfficeBuilder.Services.UploadFile
{
    public class UploadService : IUploadService
    {
        private readonly IFileReaderService fileReaderService;

        public UploadService(IFileReaderService fileReaderService)
        {
            this.fileReaderService = fileReaderService;
        }

        public async Task<List<OfficeAreaModel>> ReadFile(ElementReference elementReference)
        {
            var tasks = new List<Task<string>>();
            foreach (var file in await fileReaderService.CreateReference(elementReference).EnumerateFilesAsync())
            {
                tasks.Add(ReadFile(file));
            }

            var allTasks = await Task.WhenAll(tasks);

            var svgDocument = new HtmlDocument();

            var uploadedAreas = new List<OfficeAreaModel>();

            foreach (var file in allTasks)
            {
                svgDocument.LoadHtml(file);
                var documentElement = svgDocument.DocumentNode;

                var nodes = documentElement.ChildNodes;

                foreach (var node in nodes)
                {
                    var uploadedGroups = new List<OfficeItemGroup>();
                    foreach (var gGroup in node.ChildNodes)
                    {
                        var uploudedSvgs = new List<OfficeItemModel>();
                        foreach (var innerNode in node.ChildNodes)
                        {
                            var model = new OfficeItemModel
                            {
                                Svg = innerNode.InnerHtml
                            };

                            uploudedSvgs.Add(model);
                        }

                        var group = new OfficeItemGroup { Items = uploudedSvgs };
                        uploadedGroups.Add(group);
                    }

                    var (height, heightUnitRatio) = node.GetAttributeValue("height");
                    var (width, widthUnitRatio) = node.GetAttributeValue("width");
                    var area = new OfficeAreaModel
                    {
                        Size = new Size
                        {
                            Height = (int)Math.Round(height * heightUnitRatio, 0, MidpointRounding.AwayFromZero),
                            Width = (int)Math.Round(width * widthUnitRatio, 0, MidpointRounding.AwayFromZero)
                        },
                        Groups = uploadedGroups
                    };


                    uploadedAreas.Add(area);
                }
                
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
