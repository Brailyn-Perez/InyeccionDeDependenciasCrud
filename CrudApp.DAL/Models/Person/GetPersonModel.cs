﻿
namespace CrudApp.DAL.Models.Person
{
    public class GetPersonModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? Deleted { get; set; }
    }
}
