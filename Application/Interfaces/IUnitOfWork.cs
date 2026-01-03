
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
       

        Task<bool> Commit();
        Task<bool> HasChanges();
        Task Rollback();
    }
}
