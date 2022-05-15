using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ProjectRaymondMichael
{
    public partial class MRaymond2Context : DbContext
    {

        public MRaymond2Context(DbContextOptions<MRaymond2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<TblCar> TblCars { get; set; } = null!;
        public virtual DbSet<TblDriver> TblDrivers { get; set; } = null!;
        public virtual DbSet<TblFaculty> TblFaculties { get; set; } = null!;
        public virtual DbSet<TblIncident> TblIncidents { get; set; } = null!;
        public virtual DbSet<TblIncident1> TblIncidents1 { get; set; } = null!;
        public virtual DbSet<TblPolice> TblPolices { get; set; } = null!;
        public virtual DbSet<TblPublicSafety> TblPublicSafeties { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;
        public virtual DbSet<TblViolation> TblViolations { get; set; } = null!;
        public virtual DbSet<VwPurchase> VwPurchases { get; set; } = null!;
        public virtual DbSet<VwStudentCar> VwStudentCars { get; set; } = null!;

        public IConfiguration myconfig { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(myconfig.GetConnectionString("GalaxyDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__employee__AFB3EC6DABF6FD28");

                entity.ToTable("employees");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hireDate");

                entity.Property(e => e.HomePlanet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("homePlanet");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.Credits).HasColumnName("credits");

                entity.Property(e => e.ImageSrc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("imageSrc");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.Property(e => e.SaleId).HasColumnName("saleID");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("purchaseDate");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__empID__00200768");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__itemID__01142BA1");
            });

            modelBuilder.Entity<TblCar>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__tblCar__1436F174E5D9AF9E");

                entity.ToTable("tblCar");

                entity.Property(e => e.CarId).HasColumnName("carId");

                entity.Property(e => e.CarYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("carYear")
                    .IsFixedLength();

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .HasColumnName("color");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("licensePlate");

                entity.Property(e => e.Make)
                    .HasMaxLength(20)
                    .HasColumnName("make");

                entity.Property(e => e.Model)
                    .HasMaxLength(20)
                    .HasColumnName("model");
            });

            modelBuilder.Entity<TblDriver>(entity =>
            {
                entity.HasKey(e => e.DriverId)
                    .HasName("PK__tblDrive__F1532C12CAF99B57");

                entity.ToTable("tblDriver");

                entity.Property(e => e.DriverId)
                    .ValueGeneratedNever()
                    .HasColumnName("driverID");

                entity.Property(e => e.Addr)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("addr");

                entity.Property(e => e.City)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Dname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("dname");

                entity.Property(e => e.Dstate)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("dstate")
                    .IsFixedLength();

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblFaculty>(entity =>
            {
                entity.HasKey(e => e.FacultyId)
                    .HasName("PK__tblFacul__DBBF6FD14587224A");

                entity.ToTable("tblFaculty");

                entity.Property(e => e.FacultyId).HasColumnName("facultyID");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.FacGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("facGender")
                    .IsFixedLength();

                entity.Property(e => e.FacName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("facName");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hireDate");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.TblFaculties)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__tblFacult__carID__656C112C");
            });

            modelBuilder.Entity<TblIncident>(entity =>
            {
                entity.HasKey(e => e.IncidentId)
                    .HasName("PK__tblIncid__06A5D761FA47533C");

                entity.ToTable("tblIncident");

                entity.Property(e => e.IncidentId).HasColumnName("incidentID");

                entity.Property(e => e.Carid).HasColumnName("carid");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("comments");

                entity.Property(e => e.Facultyid).HasColumnName("facultyid");

                entity.Property(e => e.IncidentDate)
                    .HasColumnType("date")
                    .HasColumnName("incidentDate");

                entity.Property(e => e.PsafetyId).HasColumnName("psafetyId");

                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.TblIncidents)
                    .HasForeignKey(d => d.Carid)
                    .HasConstraintName("FK__tblIncide__carid__6FE99F9F");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.TblIncidents)
                    .HasForeignKey(d => d.Facultyid)
                    .HasConstraintName("FK__tblIncide__facul__6E01572D");

                entity.HasOne(d => d.Psafety)
                    .WithMany(p => p.TblIncidents)
                    .HasForeignKey(d => d.PsafetyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblIncide__psafe__6EF57B66");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TblIncidents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__tblIncide__stude__6D0D32F4");
            });

            modelBuilder.Entity<TblIncident1>(entity =>
            {
                entity.HasKey(e => e.IncidentId)
                    .HasName("PK__tblIncid__06A5D761E030BEDC");

                entity.ToTable("tblIncidents");

                entity.Property(e => e.IncidentId).HasColumnName("incidentID");

                entity.Property(e => e.DriverId).HasColumnName("driverID");

                entity.Property(e => e.IncidentDate)
                    .HasColumnType("date")
                    .HasColumnName("incidentDate");

                entity.Property(e => e.PoliceId).HasColumnName("policeID");

                entity.Property(e => e.ViolationId).HasColumnName("violationID");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TblIncident1s)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__tblIncide__drive__60A75C0F");

                entity.HasOne(d => d.Police)
                    .WithMany(p => p.TblIncident1s)
                    .HasForeignKey(d => d.PoliceId)
                    .HasConstraintName("FK__tblIncide__polic__5FB337D6");

                entity.HasOne(d => d.Violation)
                    .WithMany(p => p.TblIncident1s)
                    .HasForeignKey(d => d.ViolationId)
                    .HasConstraintName("FK__tblIncide__viola__5EBF139D");
            });

            modelBuilder.Entity<TblPolice>(entity =>
            {
                entity.HasKey(e => e.PoliceId)
                    .HasName("PK__tblPolic__F20639820FF1D3A6");

                entity.ToTable("tblPolice");

                entity.Property(e => e.PoliceId)
                    .ValueGeneratedNever()
                    .HasColumnName("policeID");

                entity.Property(e => e.Pname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("pname");
            });

            modelBuilder.Entity<TblPublicSafety>(entity =>
            {
                entity.HasKey(e => e.PsafetyId)
                    .HasName("PK__tblPubli__9192AD2527A656BF");

                entity.ToTable("tblPublicSafety");

                entity.Property(e => e.PsafetyId).HasColumnName("psafetyID");

                entity.Property(e => e.Badge)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("badge");

                entity.Property(e => e.PGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pGender")
                    .IsFixedLength();

                entity.Property(e => e.PName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("pName");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__tblStude__4D11D65C7B281389");

                entity.ToTable("tblStudent");

                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("fName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.LName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lName");

                entity.Property(e => e.Major)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("major");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.TblStudents)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__tblStuden__carID__6A30C649");
            });

            modelBuilder.Entity<TblViolation>(entity =>
            {
                entity.HasKey(e => e.ViolationId)
                    .HasName("PK__tblViola__68930B700BD2F4AB");

                entity.ToTable("tblViolation");

                entity.Property(e => e.ViolationId)
                    .ValueGeneratedNever()
                    .HasColumnName("violationID");

                entity.Property(e => e.Fine).HasColumnName("fine");

                entity.Property(e => e.Violation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("violation");
            });

            modelBuilder.Entity<VwPurchase>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPurchases");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("date")
                    .HasColumnName("Date of Purchase");

                entity.Property(e => e.EmpiricalName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Empirical Name");

                entity.Property(e => e.Item)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwStudentCar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwStudentCar");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .HasColumnName("color");

                entity.Property(e => e.Fname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Make)
                    .HasMaxLength(20)
                    .HasColumnName("make");

                entity.Property(e => e.Model)
                    .HasMaxLength(20)
                    .HasColumnName("model");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
