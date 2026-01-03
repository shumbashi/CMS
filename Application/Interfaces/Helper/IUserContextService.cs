using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Helper
{
    public interface IUserContextService
    {
        Guid GetCurrentUserId();
        string? GetCurrentUserRole();
    }

}
