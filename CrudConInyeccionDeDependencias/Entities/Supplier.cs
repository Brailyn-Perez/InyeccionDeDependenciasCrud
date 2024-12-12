using System;
using System.Collections.Generic;

namespace CrudApp.DAL.Entities;

public partial class Supplier
{
    public int Supplierid { get; set; }

    public string Companyname { get; set; } = null!;

    public string Contactname { get; set; } = null!;

    public string Contacttitle { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Fax { get; set; }

    public DateTime CreationDate { get; set; }

    public int CreationUser { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyUser { get; set; }

    public int? DeleteUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool Deleted { get; set; }
}
