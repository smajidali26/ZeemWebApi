using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeem.Core.Domain;
using Zeem.Service.Infrastructure;
using ZeemFacade.Infrastructure;

namespace ZeemFacade.Implementation
{
    public class ZeemRoleFacade : IZeemRoleFacade
    {
        #region Members

        private readonly IZeemRoleService _zeemRoleService;

        #endregion

        #region Ctor

        public ZeemRoleFacade(IZeemRoleService zeemRoleService)
        {
            _zeemRoleService= zeemRoleService;
        }

        #endregion

        public async Task<ZeemRole> GetRoleById(int id)
        {
            return await _zeemRoleService.GetRoleById(id);
        }
    }
}
