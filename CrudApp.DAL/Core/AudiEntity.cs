
namespace CrudApp.DAL.Core
{
    public abstract class AudiEntity
    {
        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? Deleted { get; set; }
    }
}
