using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.DAL.Services
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
