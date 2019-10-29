using Mentoring.OfficeBuilder.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.DAL.Services
{
    public class TransitionRepository : IRepository<DbTransition>
    {
        private readonly OfficeDbContext context;

        public TransitionRepository(OfficeDbContext context)
        {
            this.context = context;
        }
        public Task Create(DbTransition item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DbTransition item)
        {
            throw new NotImplementedException();
        }

        public Task<DbTransition> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<DbTransition>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(DbTransition item)
        {
            throw new NotImplementedException();
        }
    }
}
