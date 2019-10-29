using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentoring.OfficeBuilder.DAL;
using Mentoring.OfficeBuilder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mentoring.OfficeBuilder.API;
using Mentoring.OfficeBuilder.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Mentoring.OfficeBuilder.DAL.Services;

namespace Mentoring.OfficeBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SvgController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public SvgController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<List<Guid>> Get()
        {
            var svgRepository = this.unitOfWork.SvgRepository;
            var svgIds = svgRepository.GetAll().Select(x => x.Id);

            return await svgIds.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<SvgModel> Get(Guid id)
        {
            var svgRepository = this.unitOfWork.SvgRepository;
            var dbSvg = await svgRepository.Get(id);

            if (dbSvg == null)
            {
                throw new Exception("Svg was not found.");
            }

            var model = new SvgModel
            {
                Id = dbSvg.Id,
                Name = dbSvg.Name,
                Html = dbSvg.Html
            };

            return model;
        }

        [HttpPost()]
        public async Task Post(SvgModel svg)
        {
            var svgRepository = this.unitOfWork.SvgRepository;

            svgRepository.Create(new DAL.DbModels.DbSvg { Html = svg.Html, Name = svg.Name });

            await this.unitOfWork.SaveAsync();
        }
    }
}
