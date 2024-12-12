
namespace CrudApp.DAL.Models.Person
{
    public class PersonRemoveModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? Deleted { get; set; }
    }
}
