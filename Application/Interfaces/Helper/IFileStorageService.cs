using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Helper
{
    public interface IFileStorageService
    {
        Task<string> SaveProfileImageAsync(byte[] fileBytes, string fileName);
    }
}
