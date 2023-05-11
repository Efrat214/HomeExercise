using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Vaccinesforpatient
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int VaccineId { get; set; }

    public DateTime Dateofvaccination { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Coronavaccine Vaccine { get; set; } = null!;
}
