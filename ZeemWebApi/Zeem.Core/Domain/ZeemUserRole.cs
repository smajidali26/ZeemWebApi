namespace Zeem.Core.Domain
{
    public class ZeemUserRole : BaseEntity
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual ICollection<ZeemUser> Users { get; set; }

        public virtual ICollection<ZeemRole> Roles { get; set; }
    }
}
