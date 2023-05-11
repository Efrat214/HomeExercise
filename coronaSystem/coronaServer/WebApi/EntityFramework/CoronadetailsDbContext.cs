using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public partial class CoronadetailsDbContext : DbContext
{
    public CoronadetailsDbContext()
    {
    }

    public CoronadetailsDbContext(DbContextOptions<CoronadetailsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coronavaccine> Coronavaccines { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Vaccinesforpatient> Vaccinesforpatients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=coronadetailsDB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coronavaccine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coronava__3213E83F29F3CBF5");

            entity.ToTable("Coronavaccine");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(30)
                .HasColumnName("manufacturer");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__patients__3213E83FDE4EDEA7");

            entity.ToTable("patients");

            entity.HasIndex(e => e.PatientId, "UQ__patients__A17005ED47C08184").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("city");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("date")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(200)
                .HasColumnName("imagepath");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Mobilephone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mobilephone");
            entity.Property(e => e.NumHouse).HasColumnName("numHouse");
            entity.Property(e => e.PatientId)
                .HasMaxLength(9)
                .HasColumnName("patientId");
            entity.Property(e => e.PositiveResultDate).HasColumnType("date");
            entity.Property(e => e.RecoveryDate).HasColumnType("date");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
            entity.Property(e => e.Telephone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Vaccinesforpatient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vaccines__3213E83F419ED704");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dateofvaccination).HasColumnType("date");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.VaccineId).HasColumnName("vaccineId");

            entity.HasOne(d => d.Patient).WithMany(p => p.Vaccinesforpatients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vaccinesf__patie__30F848ED");

            entity.HasOne(d => d.Vaccine).WithMany(p => p.Vaccinesforpatients)
                .HasForeignKey(d => d.VaccineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vaccinesf__vacci__31EC6D26");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
