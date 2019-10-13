using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentoring.OfficeBuilder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mentoring.OfficeBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SvgController : ControllerBase
    {
        private List<OfficeAreaModel> AreaModels;

        public SvgController()
        {
            AreaModels = new List<OfficeAreaModel>
            {
                new OfficeAreaModel
                {
                    Id = 1,
                    Items = new List<OfficeItemModel>
                    {
                        new OfficeItemModel
                        {
                            Id = 2,
                            Svg = $@"<rect width='10' height='10' x='20' y='50' {style}/>",
                            AreaToMove = 2
                        },
                        new OfficeItemModel
                        {
                            Id = 3,
                            Svg = $@"<rect width='10' height='10' x='50' y='20' {style}/>",
                            AreaToMove = 3
                        }
                    },
                    Position = new Position{ X = 0, Y = 0 },
                    Size = new Size{Height = 100, Width = 100 }
                },
                new OfficeAreaModel
                {
                    Id = 2,
                    Items = new List<OfficeItemModel>
                    {
                        new OfficeItemModel
                        {
                            Id = 4,
                            Svg = $@"<rect width='10' height='10' x='50' y='40' {style}/>",
                            AreaToMove = 1
                        },
                        new OfficeItemModel
                        {
                            Id = 5,
                            Svg = $@"<rect width='10' height='10' x='50' y='80' {style}/>",
                            AreaToMove = 3
                        },
                    },
                    Position = new Position{ X = 0, Y = 0 },
                    Size = new Size{Height = 100, Width = 100 }
                },
                new OfficeAreaModel
                {
                    Id = 3,
                    Items = new List<OfficeItemModel>
                    {
                        new OfficeItemModel
                        {
                            Id = 6,
                            Svg = $@"<rect width='10' height='10' x='70' y='20' {style}/>",
                            AreaToMove = 1
                        }
                    },
                    Position = new Position{ X = 0, Y = 0 },
                    Size = new Size{Height = 100, Width = 100 }
                }
            };
        }

        // GET: api/Svg
        [HttpGet]
        public async Task<OfficeAreaModel> Get()
        {
            return AreaModels.Single(x => x.Id == 1);
        }

        [HttpGet("{id}")]
        public async Task<OfficeAreaModel> Get(int id)
        {
            return AreaModels.Single(x => x.Id == id);
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
