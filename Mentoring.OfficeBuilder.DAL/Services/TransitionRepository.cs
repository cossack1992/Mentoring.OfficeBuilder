using Mentoring.OfficeBuilder.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
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
        public void Create(DbTransition item)
        {
            item.IsActive = true;

            var dbSvg = this.context.DbSvgs
                .Include(x => x.Transitions)
                .Single(x => x.Id == item.Svg.Id && x.IsActive);

            if(dbSvg == null)
            {
                throw new Exception("Svg was not found");
            }

            item.Svg = dbSvg;
            dbSvg.Transitions.Add(item);

            this.context.DbTransitions.Add(item);
        }

        public void Delete(Guid id)
        {
            var dbItem = this.context.DbTransitions.Find(id);

            if (dbItem != null)
            {
                dbItem.IsActive = false;
            }
        }

        public async Task<DbTransition> Get(Guid id)
        {
            var dbItem = await this.context.DbTransitions
                .Include(x => x.Svg)
                .SingleOrDefaultAsync(x => x.ElementId == id && x.IsActive);

            if (dbItem == null)
            {
                throw new Exception("DbTransition was not found");
            }

            return dbItem;
        }

        public IQueryable<DbTransition> GetAll()
        {
            return this.context.DbTransitions
                .Include(x => x.Svg)
                .Where(x => x.IsActive);
        }

        public void Update(DbTransition item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }
    }
}
