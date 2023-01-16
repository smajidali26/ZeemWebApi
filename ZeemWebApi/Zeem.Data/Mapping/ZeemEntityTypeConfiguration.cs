using System.Data.Entity.ModelConfiguration;

namespace Zeem.Data.Mapping
{
    public class ZeemEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected ZeemEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    }
}
