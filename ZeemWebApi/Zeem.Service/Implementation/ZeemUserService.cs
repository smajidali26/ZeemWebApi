using System.Linq.Expressions;
using Zeem.Core.Data;
using Zeem.Core.Domain;
using Zeem.Service.Infrastructure;

namespace Zeem.Service.Implementation
{
    public class ZeemUserService : IZeemUserService
    {
        #region Members

        private readonly IRepository<ZeemUser> _repository;

        #endregion

        #region Ctor

        public ZeemUserService(IRepository<ZeemUser> repository)
        {
            _repository = repository;
        }

        #endregion


        #region Methods

        public async Task CreateUser(ZeemUser zeemUser)
        {
            zeemUser.CreatedDate = DateTime.Now;
            await _repository.Insert(zeemUser);

            if (zeemUser.CreatedBy <= 0) {
                zeemUser.CreatedBy = zeemUser.Id; // Self Creation.
                await UpdateUser(zeemUser);
            }
        }

        public async Task DeleteUser(ZeemUser zeemUser)
        {
            zeemUser.DeletedDate = DateTime.Now;
            zeemUser.IsDeleted = true;
            await _repository.SoftDelete(zeemUser);
        }

        public async Task<ZeemUser> GetUserById(int userId)
        {
            return await _repository.GetById(userId);
        }

        public async Task<ZeemUser> GetUser(Expression<Func<ZeemUser, bool>> predicate)
        {
            return await _repository.Get(predicate);
        }

        public async Task<ICollection<ZeemUser>> GetUsers(Expression<Func<ZeemUser, bool>> predicate)
        {
            return await _repository.GetList(predicate);
        }

        public async Task<ICollection<ZeemUser>> GetUsersByIds(int[] userIds)
        {
            return await _repository.GetList(x=> userIds.Contains(x.Id));
        }

        public async Task UpdateUser(ZeemUser zeemUser)
        {
            zeemUser.ModifiedDate= DateTime.Now;
            await _repository.Update(zeemUser);
        }

        #endregion
    }
}
