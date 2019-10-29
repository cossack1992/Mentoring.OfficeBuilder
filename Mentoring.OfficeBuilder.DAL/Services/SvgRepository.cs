using Mentoring.OfficeBuilder.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
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
        public void Create(DbSvg item)
        {
            item.IsActive = true;

            this.context.DbSvgs.Add(item);
        }

        public void Delete(Guid id)
        {
            var dbItem = this.context.DbSvgs.Find(id);

            if(dbItem != null)
            {
                dbItem.IsActive = false;
            }
        }

        public async Task<DbSvg> Get(Guid id)
        {
            var dbItem = await this.context.DbSvgs
                .Include(x => x.Transitions)
                .SingleOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (dbItem == null)
            {
                throw new Exception("DbSvg was not found");
            }

            return dbItem;
        }

        public IQueryable<DbSvg> GetAll()
        {
            return this.context.DbSvgs
                .Include(x => x.Transitions)
                .Where(x => x.IsActive);
        }

        public void Update(DbSvg item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }
    }
}
