
namespace CrudApp.DAL.Models.Person
{
    public class PersonCreateModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
