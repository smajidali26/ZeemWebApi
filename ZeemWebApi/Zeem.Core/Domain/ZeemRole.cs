namespace Zeem.Core.Domain
{
    public class ZeemRole : BaseEntity
    {
        public string RoleName { get; set; }

        public virtual ZeemUserRole UserRole { get; set; }
    }
}
