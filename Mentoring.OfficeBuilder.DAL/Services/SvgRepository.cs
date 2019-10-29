using Mentoring.OfficeBuilder.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.DAL.Services
{
    public class SvgRepository : IRepository<DbSvg>
    {
        private readonly OfficeDbContext context;

        public SvgRepository(OfficeDbContext context)
        {
            this.context = context;
        }
        public Task Create(DbSvg item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DbSvg item)
        {
            throw new NotImplementedException();
        }

        public Task<DbSvg> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<DbSvg>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(DbSvg item)
        {
            throw new NotImplementedException();
        }
    }
}
