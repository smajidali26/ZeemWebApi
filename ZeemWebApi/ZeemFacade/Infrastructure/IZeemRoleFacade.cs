using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeem.Core.Domain;

namespace ZeemFacade.Infrastructure
{
    public interface IZeemRoleFacade
    {
        Task<ZeemRole> GetRoleById(int id);
    }
}
