using Mentoring.OfficeBuilder.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.Services.UploadFile
{
    public interface IUploadService
    {
        Task<List<OfficeItemModel>> ReadFile(ElementReference elementReference);
    }
}