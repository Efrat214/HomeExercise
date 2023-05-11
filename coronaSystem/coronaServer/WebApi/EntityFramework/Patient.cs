using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Patient
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int NumHouse { get; set; }

    public DateTime Dateofbirth { get; set; }

    public string? Telephone { get; set; }

    public string Mobilephone { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public DateTime? PositiveResultDate { get; set; }

    public DateTime? RecoveryDate { get; set; }

    public string? Imagepath { get; set; }

    public virtual ICollection<Vaccinesforpatient> Vaccinesforpatients { get; set; } = new List<Vaccinesforpatient>();
}
