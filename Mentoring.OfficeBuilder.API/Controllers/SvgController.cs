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

            _context.ApplyDefaultData();
        }

        [HttpGet("{id}")]
        public async Task<OfficeAreaModel> Get(int id)
        {
            var dbModel = _context.DbAreas
                .Include(x => x.Items)
                .SingleOrDefault(x => x.Id == id);

            if (dbModel == null)
            {
                throw new Exception();
            }

            var model = dbModel.GetAreaFromDbModel();

            return model;
        }

        // PUT: api/Svg/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string style = @"style='fill:white;stroke:black;stroke-width:3'";
    }
}
