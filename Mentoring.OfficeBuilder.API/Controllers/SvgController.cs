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

namespace Mentoring.OfficeBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SvgController : ControllerBase
    {
        private OfficeDbContext _context;

        public SvgController(OfficeDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<List<Guid>> Get()
        {
            var svgIds = _context.DbAreas.Select(x => x.Id);

            return svgIds.ToList();
        }

        [HttpGet("{id}")]
        public async Task<SvgModel> Get(Guid id)
        {
            var dbSvg = _context.DbAreas
                .SingleOrDefault(svg => svg.Id == id);

            if (dbSvg == null)
            {
                throw new Exception();
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
            _context.DbAreas.Add(new DAL.DbModels.DbSvg {Id = Guid.NewGuid(), Html = svg.Html, Name = svg.Name });

            await _context.SaveChangesAsync();
        }
    }
}
