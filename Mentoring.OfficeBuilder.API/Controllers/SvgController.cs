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
                    Svg = $@"<rect width='1000' height='1000' {style}/>",
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
                    Svg = $@"<rect width='10' height='10' x='50' y='400' {style}/>",
                    Parent = 2
                },
                new OfficeItemModel
                {
                    Id = 5,
                    Svg = $@"<rect width='10' height='10' x='50' y='800' {style}/>",
                    Parent = 3
                },
                new OfficeItemModel
                {
                    Id = 6,
                    Svg = $@"<rect width='10' height='10' x='700' y='20' {style}/>",
                    Parent = 3
                },
            };
        }

        // GET: api/Svg
        [HttpGet]
        public OfficeItemModel GetMainSvg()
        {
            return Models.Single(x => x.Parent == null);
        }

        // GET: api/Svg/5
        [HttpGet("{id}", Name = "Get")]
        public List<OfficeItemModel> Get(int id)
        {
            return Models.Where(x => x.Parent == id).ToList();
        }

        // POST: api/Svg
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
