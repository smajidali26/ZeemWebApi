using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Zeem.Core.Data;
using Zeem.Core.Domain;
using Zeem.Service.Infrastructure;

namespace Zeem.Service.Implementation
{
    public class ZeemRoleService : IZeemRoleService
    {
        #region Members

        private readonly IRepository<ZeemRole> _repository;

        #endregion

        #region Ctor
        
        public ZeemRoleService(IRepository<ZeemRole> repository)
        {
            _repository= repository;
        }

        #endregion

        #region Methods

        
        public async Task<ZeemRole> GetRoleById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<ZeemRole> GetRoleByName(string roleName)
        {
            return await _repository.Table.FirstOrDefaultAsync(x=>x.RoleName.Equals(roleName));
        }

        public ZeemRole GetSelfRegistrationRole()
        {
            return _repository.Table.FirstOrDefault(x => x.SelfRegistrationRole);
        }

        public async Task<ICollection<ZeemRole>> GetRolesByIds(int[] ids)
        {
            return await _repository.Table.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        #endregion
    }
}
