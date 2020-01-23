using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mentoring.OfficeBuilder.DAL.DbModels;

namespace Mentoring.OfficeBuilder.DAL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OfficeDbContext context;
        private SvgRepository svgRepository;
        private TransitionRepository transitionRepository;

        public UnitOfWork(OfficeDbContext context)
        {
            this.context = context;
        }
        public IRepository<DbSvg> SvgRepository
        {
            get
            {
                if (svgRepository == null)
                {
                    svgRepository = new SvgRepository(this.context);
                }

                return svgRepository;
            }
        }

        public IRepository<DbTransition> TransitionRepository
        {
            get
            {
                if (transitionRepository == null)
                {
                    transitionRepository = new TransitionRepository(this.context);
                }

                return transitionRepository;
            }
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
