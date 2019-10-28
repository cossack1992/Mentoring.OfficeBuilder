using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentoring.OfficeBuilder.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mentoring.OfficeBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private OfficeDbContext _context;

        public SettingsController(OfficeDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<List<Guid>> GetSvgIds()
        {
            var svgIds = _context.DbAreas.Select(x => x.Id);

            return svgIds.ToList();
        }
    }
}
