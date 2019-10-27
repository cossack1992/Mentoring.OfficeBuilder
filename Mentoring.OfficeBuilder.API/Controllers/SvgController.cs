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

        [HttpGet("{id}")]
        public async Task<SvgModel> Get(string id)
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
        public async Task Post(List<SvgModel> svgs)
        {
        }
    }
}
