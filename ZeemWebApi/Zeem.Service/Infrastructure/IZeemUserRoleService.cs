using Zeem.Core.Domain;

namespace Zeem.Service.Infrastructure
{
    public interface IZeemUserRoleService
    {
        Task InsertUserRole(ZeemUserRole zeemUserRole);

        Task<ICollection<ZeemUserRole>> GetUserRoleByUserId(int userId);

        Task<ICollection<ZeemUserRole>> GetUserRoleByRoleId(int roleId);
    }
}
