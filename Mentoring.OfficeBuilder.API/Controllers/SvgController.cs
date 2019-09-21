using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentoring.OfficeBuilder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mentoring.OfficeBuilder.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SvgController : ControllerBase
    {
        private List<OfficeItemModel> Models;

        public SvgController()
        {
            Models = new List<OfficeItemModel>
            {
                new OfficeItemModel
                {
                    Id = 1,
                    Svg = $@"<rect width='100' height='100' {style}/>",
                    Children = new List<int>{2, 3}
                },
                new OfficeItemModel
                {
                    Id = 2,
                    Svg = $@"<rect width='10' height='10' x='20' y='50' {style}/>",
                    Parent = 1,
                    Children = new List<int>{4}
                },
                new OfficeItemModel
                {
                    Id = 3,
                    Svg = $@"<rect width='10' height='10' x='50' y='20' {style}/>",
                    Parent = 1,
                    Children = new List<int>{5, 6}
                },
                new OfficeItemModel
                {
                    Id = 4,
                    Svg = $@"<rect width='10' height='10' x='50' y='40' {style}/>",
                    Parent = 2,
                    Children = new List<int>{1}
                },
                new OfficeItemModel
                {
                    Id = 5,
                    Svg = $@"<rect width='10' height='10' x='50' y='80' {style}/>",
                    Parent = 3,
                    Children = new List<int>{1}
                },
                new OfficeItemModel
                {
                    Id = 6,
                    Svg = $@"<rect width='10' height='10' x='70' y='20' {style}/>",
                    Parent = 3,
                    Children = new List<int>{1}
                },
            };
        }

        // GET: api/Svg
        [HttpGet]
        public async Task<OfficeItemModel> GetMainSvg()
        {
            return Models.Single(x => x.Parent == null);
        }

        // POST: api/Svg
        [HttpPost]
        public async Task<List<OfficeItemModel>> Post([FromBody] GetItemsRequest request)
        {
            return Models.Where(x => request.Ids.Any(y => y == x.Id)).ToList();
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
