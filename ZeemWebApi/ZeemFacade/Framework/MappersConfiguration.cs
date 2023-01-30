using AutoMapper;
using Zeem.Core.Domain;
using Zeem.DomainContracts.ViewModel.Request.User;
using Zeem.DomainContracts.ViewModel.Response;

namespace ZeemFacade.Framework
{
    public class MappersConfiguration : Profile , IOrderedMapperProfile
    {
        public MappersConfiguration()
        {
            UserMapper();
        }

        public int Order => 0;

        #region Methods

        public void UserMapper()
        {
            CreateMap<UserRegistration, ZeemUser>();
            CreateMap<ZeemUser, UserResponse>();
        }

        #endregion
    }
}
