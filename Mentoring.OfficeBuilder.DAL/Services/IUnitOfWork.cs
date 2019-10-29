using Mentoring.OfficeBuilder.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.DAL.Services
{
    public interface IUnitOfWork
    {
        IRepository<DbSvg> SvgRepository { get; }

        IRepository<DbTransition> TransitionRepository { get; }

        Task SaveAsync();
    }
}
