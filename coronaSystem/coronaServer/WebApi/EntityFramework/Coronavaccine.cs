using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Coronavaccine
{
    public int Id { get; set; }

    public string Manufacturer { get; set; } = null!;

    public virtual ICollection<Vaccinesforpatient> Vaccinesforpatients { get; set; } = new List<Vaccinesforpatient>();
}
