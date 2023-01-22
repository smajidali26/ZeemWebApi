using Microsoft.EntityFrameworkCore;
using Zeem.Core.Data;
using Zeem.Core.Domain;
using Zeem.Service.Infrastructure;

namespace Zeem.Service.Implementation
{
    public class ZeemUserRoleService : IZeemUserRoleService
    {
        #region Memebers

        private readonly IRepository<ZeemUserRole> _repository;

        #endregion

        #region Ctor

        public ZeemUserRoleService(IRepository<ZeemUserRole> repository)
        {
            _repository= repository;   
        }

        #endregion


        #region Methods

        public async Task<ICollection<ZeemUserRole>> GetUserRoleByRoleId(int roleId)
        {
            return await _repository.Table.Where(x => x.RoleId == roleId).ToListAsync();
        }

        public async Task<ICollection<ZeemUserRole>> GetUserRoleByUserId(int userId)
        {
            return await _repository.Table.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task InsertUserRole(ZeemUserRole zeemUserRole)
        {
            zeemUserRole.CreatedDate = DateTime.Now;
            await _repository.Insert(zeemUserRole);
        }

        #endregion
    }
}
