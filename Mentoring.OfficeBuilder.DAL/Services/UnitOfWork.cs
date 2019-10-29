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

        public UnitOfWork(OfficeDbContext context)
        {
            this.context = context;
        }
        public IRepository<DbSvg> SvgRepository => throw new NotImplementedException();

        public IRepository<DbTransition> TransitionRepository => throw new NotImplementedException();

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
