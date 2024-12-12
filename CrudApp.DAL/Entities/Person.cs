﻿using CrudApp.DAL.Core;
using System;
using System.Collections.Generic;

namespace CrudApp.DAL.Entities;

public partial class Person : AudiEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
