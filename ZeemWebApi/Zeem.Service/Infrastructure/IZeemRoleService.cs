using Zeem.Core.Domain;

namespace Zeem.Service.Infrastructure
{
    public interface IZeemRoleService
    {
        Task<ZeemRole> GetRoleById(int id);

        Task<ZeemRole> GetRoleByName(string roleName);

        ZeemRole GetSelfRegistrationRole();

        Task<ICollection<ZeemRole>> GetRolesByIds(int[] ids);
    }
}
