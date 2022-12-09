using System;
using Jgraver1;
using JGraver1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ProjectGraverJustin
{
    public partial class JGraver1Context : DbContext
    {
        public IConfiguration myconfig { get; }

        public JGraver1Context(DbContextOptions<JGraver1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAdmission> TblAdmission { get; set; }
        public virtual DbSet<TblAdoption> TblAdoption { get; set; }
        public virtual DbSet<TblDriver> TblDriver { get; set; }
        public virtual DbSet<TblGuest> TblGuest { get; set; }
        public virtual DbSet<TblIncident> TblIncident { get; set; }
        public virtual DbSet<TblOwner> TblOwner { get; set; }
        public virtual DbSet<TblPatient> TblPatient { get; set; }
        public virtual DbSet<TblPet> TblPet { get; set; }
        public virtual DbSet<TblPolice> TblPolice { get; set; }
        public virtual DbSet<TblStaff> TblStaff { get; set; }
        public virtual DbSet<TblViolation> TblViolation { get; set; }
        public virtual DbSet<avgStaffSalary1> avgStaffSalary1 { get; set; }
        public virtual DbSet<Viewpatientsex> Viewpatientsex { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(myconfig.GetConnectionString("sqlconnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAdmission>(entity =>
            {
                entity.HasKey(e => e.AdmissionId);

                entity.ToTable("tblAdmission");

                entity.Property(e => e.AdmissionId)
                    .HasColumnName("AdmissionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GuestId).HasColumnName("GuestID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.TimeAdmitted).HasColumnType("datetime");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.TblAdmission)
                    .HasForeignKey(d => d.GuestId)
                    .HasConstraintName("FK_tblAdmission_tblGuest");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblAdmission)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAdmission_tblPatient");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblAdmission)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAdmission_tblStaff");
            });

            modelBuilder.Entity<TblAdoption>(entity =>
            {
                entity.HasKey(e => e.AdoptionId);

                entity.ToTable("tblAdoption");

                entity.Property(e => e.AdoptionId)
                    .HasColumnName("adoptionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.PetId).HasColumnName("PetID");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TblAdoption)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAdoption_tblAdoption");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.TblAdoption)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAdoption_tblAdoption1");
            });

            modelBuilder.Entity<TblDriver>(entity =>
            {
                entity.HasKey(e => e.DriverId);

                entity.ToTable("tblDriver");

                entity.Property(e => e.DriverId)
                    .HasColumnName("driverID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(20);

                entity.Property(e => e.DState)
                    .IsRequired()
                    .HasColumnName("dState")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Dname)
                    .IsRequired()
                    .HasColumnName("dname")
                    .HasMaxLength(10);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(5)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblGuest>(entity =>
            {
                entity.HasKey(e => e.GuestId);

                entity.ToTable("tblGuest");

                entity.Property(e => e.GuestId)
                    .HasColumnName("GuestID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GuestDoB).HasColumnType("date");

                entity.Property(e => e.GuestFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GuestLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GuestSignIn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblIncident>(entity =>
            {
                entity.HasKey(e => e.IncidentId)
                    .HasName("PK__tblIncid__06A5D761E6D60CE0");

                entity.ToTable("tblIncident");

                entity.Property(e => e.IncidentId)
                    .HasColumnName("incidentID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DriverId).HasColumnName("driverID");

                entity.Property(e => e.IncidentDate)
                    .HasColumnName("incidentDate")
                    .HasColumnType("date");

                entity.Property(e => e.PoliceId).HasColumnName("policeID");

                entity.Property(e => e.ViolationId).HasColumnName("violationID");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TblIncident)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIncident_tblDriver");

                entity.HasOne(d => d.Police)
                    .WithMany(p => p.TblIncident)
                    .HasForeignKey(d => d.PoliceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIncident_tblPolice");

                entity.HasOne(d => d.Violation)
                    .WithMany(p => p.TblIncident)
                    .HasForeignKey(d => d.ViolationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIncident_tblViolation");
            });

            modelBuilder.Entity<TblOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerId);

                entity.ToTable("tblOwner");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("OwnerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OwnerFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OwnerLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("tblPatient");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PatientFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.PatientLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblPet>(entity =>
            {
                entity.HasKey(e => e.PetId)
                    .HasName("PK_tblPets");

                entity.ToTable("tblPet");

                entity.Property(e => e.PetId)
                    .HasColumnName("PetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Breed)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.PetName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PetNotes)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PetType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblPolice>(entity =>
            {
                entity.HasKey(e => e.PoliceId);

                entity.ToTable("tblPolice");

                entity.Property(e => e.PoliceId)
                    .HasColumnName("policeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasColumnName("pname")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblStaff>(entity =>
            {
                entity.HasKey(e => e.StaffId);

                entity.ToTable("tblStaff");

                entity.Property(e => e.StaffId)
                    .HasColumnName("StaffID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StaffNameLast)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StaffNameFirst)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<TblViolation>(entity =>
            {
                entity.HasKey(e => e.ViolationId);

                entity.ToTable("tblViolation");

                entity.Property(e => e.ViolationId)
                    .HasColumnName("violationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fine)
                    .IsRequired()
                    .HasColumnName("fine")
                    .HasMaxLength(4);

                entity.Property(e => e.Violation)
                    .IsRequired()
                    .HasColumnName("violation")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<avgStaffSalary1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgStaffSalary1");

                entity.Property(e => e.AverageSalary)
                    .HasColumnName("AverageSalary")
                    .ValueGeneratedNever();

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<Viewpatientsex>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewpatientsex");

                entity.Property(e => e.Sex)
                     .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.firstname)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
