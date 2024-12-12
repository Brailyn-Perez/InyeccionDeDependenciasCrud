using System;
using System.Collections.Generic;

namespace CrudApp.DAL.Entities;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public int CreationUser { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyUser { get; set; }

    public int? DeleteUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool Deleted { get; set; }
}
