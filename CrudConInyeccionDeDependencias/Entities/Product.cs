using System;
using System.Collections.Generic;

namespace CrudApp.DAL.Entities;

public partial class Product
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;

    public int Supplierid { get; set; }

    public int Categoryid { get; set; }

    public decimal Unitprice { get; set; }

    public bool Discontinued { get; set; }

    public DateTime CreationDate { get; set; }

    public int CreationUser { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyUser { get; set; }

    public int? DeleteUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool Deleted { get; set; }
}
