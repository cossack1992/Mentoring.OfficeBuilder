using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentoring.OfficeBuilder.DAL;
using Mentoring.OfficeBuilder.DAL.Services;
using Mentoring.OfficeBuilder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mentoring.OfficeBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransitionController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public TransitionController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<List<Transition>> Get()
        {
            var repository = this.unitOfWork.TransitionRepository;
            var transitions = repository.GetAll();

            return transitions.Select(x => new Transition { Id = x.Id, ElementId = x.ElementId, SvgId = x.Svg.Id }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<SvgModel> Get(Guid id)
        {
            var repository = this.unitOfWork.TransitionRepository;
            var dbTransition = await repository.Get(id);

            if (dbTransition == null)
            {
                throw new Exception("Transition was not found.");
            }

            var model = new SvgModel
            {
                Id = dbTransition.Svg.Id,
                Name = dbTransition.Svg.Name,
                Html = dbTransition.Svg.Html
            };

            return model;
        }

        [HttpPost()]
        public async Task Post(Transition transition)
        {
            var repository = this.unitOfWork.TransitionRepository;

            repository.Create(
                new DAL.DbModels.DbTransition
                {
                    ElementId = transition.ElementId,
                    Svg = new DAL.DbModels.DbSvg
                    {
                        Id = transition.SvgId
                    }
                });

            await this.unitOfWork.SaveAsync();
        }
    }
}
