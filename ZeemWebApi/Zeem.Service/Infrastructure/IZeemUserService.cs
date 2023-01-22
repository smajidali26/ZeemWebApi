using System.Linq.Expressions;
using Zeem.Core.Domain;

namespace Zeem.Service.Infrastructure
{
    public interface IZeemUserService
    {
        Task<ZeemUser> GetUserById(int userId);

        Task<ICollection<ZeemUser>> GetUsersByIds(int[] userIds);

        Task<ZeemUser> GetUser(Expression<Func<ZeemUser, bool>> predicate);

        Task<ICollection<ZeemUser>> GetUsers(Expression<Func<ZeemUser, bool>> predicate);

        Task CreateUser(ZeemUser zeemUser);

        Task UpdateUser(ZeemUser zeemUser);

        Task DeleteUser(ZeemUser zeemUser);
    }
}
