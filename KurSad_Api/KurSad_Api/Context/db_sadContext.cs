using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class db_sadContext : DbContext
    {
        public db_sadContext()
        {
        }

        public db_sadContext(DbContextOptions<db_sadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLevel> AccessLevels { get; set; }
        public virtual DbSet<ActsOnMaterialSupport> ActsOnMaterialSupports { get; set; }
        public virtual DbSet<ApplicationsForTechnicalSupport> ApplicationsForTechnicalSupports { get; set; }
        public virtual DbSet<Archive> Archives { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ListCase> ListCases { get; set; }
        public virtual DbSet<ListOfOtherDocument> ListOfOtherDocuments { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<PaymentList> PaymentLists { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<RequestsForMaintenanceOfPremise> RequestsForMaintenanceOfPremises { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TypeOfCase> TypeOfCases { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-EMN5G8DL\\DB_SAD;Database=db_sad;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AccessLevel>(entity =>
            {
                entity.HasKey(e => e.IdAccessLevel);

                entity.ToTable("AccessLevel");

                entity.Property(e => e.IdAccessLevel).HasColumnName("ID_AccessLevel");

                entity.Property(e => e.TitleAccessLevel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActsOnMaterialSupport>(entity =>
            {
                entity.HasKey(e => e.IdActsOnMaterialSupport);

                entity.ToTable("ActsOnMaterialSupport");

                entity.Property(e => e.IdActsOnMaterialSupport).HasColumnName("ID_ActsOnMaterialSupport");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

            });

            modelBuilder.Entity<ApplicationsForTechnicalSupport>(entity =>
            {
                entity.HasKey(e => e.IdApplicationsForTechnicalSupport);

                entity.ToTable("ApplicationsForTechnicalSupport");

                entity.Property(e => e.IdApplicationsForTechnicalSupport).HasColumnName("ID_ApplicationsForTechnicalSupport");

                entity.Property(e => e.DateAppication).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

            });

            modelBuilder.Entity<Archive>(entity =>
            {
                entity.HasKey(e => e.IdRecord)
                    .HasName("PK_Record");

                entity.ToTable("Archive");

                entity.Property(e => e.IdRecord).HasColumnName("ID_Record");

                entity.Property(e => e.CasesId).HasColumnName("Cases_ID");

                entity.Property(e => e.DateOfDeposit).HasColumnType("date");

                entity.Property(e => e.DateOfRequest).HasColumnType("date");

                entity.Property(e => e.DocumentsId).HasColumnName("Documents_ID");

            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasKey(e => e.IdEducation);

                entity.ToTable("Education");

                entity.Property(e => e.IdEducation).HasColumnName("ID_Education");

                entity.Property(e => e.TitleEducation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("Employee");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.EducationId).HasColumnName("Education_ID");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeInn)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeINN");

                entity.Property(e => e.EmployeePhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberPasport)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationId).HasColumnName("Organization_ID");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("Position_ID");

                entity.Property(e => e.SeriaPasport)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_ID");
            });

            modelBuilder.Entity<ListCase>(entity =>
            {
                entity.HasKey(e => e.IdCases)
                    .HasName("PK_Cases");

                entity.Property(e => e.IdCases).HasColumnName("ID_Cases");

                entity.Property(e => e.DateOfRequestCases).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("Type_ID");
            });

            modelBuilder.Entity<ListOfOtherDocument>(entity =>
            {
                entity.HasKey(e => e.IdDocuments)
                    .HasName("PK_Documents");

                entity.Property(e => e.IdDocuments).HasColumnName("ID_Documents");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.IdOrganization);

                entity.ToTable("Organization");

                entity.Property(e => e.IdOrganization).HasColumnName("ID_Organization");

                entity.Property(e => e.TitleOrganizatione)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentList>(entity =>
            {
                entity.HasKey(e => e.IdPaymentList);

                entity.ToTable("PaymentList");

                entity.Property(e => e.IdPaymentList).HasColumnName("ID_PaymentList");

                entity.Property(e => e.DateOfIssue).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.IdPosition);

                entity.ToTable("Position");

                entity.Property(e => e.IdPosition).HasColumnName("ID_Position");

                entity.Property(e => e.TitlePosition)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequestsForMaintenanceOfPremise>(entity =>
            {
                entity.HasKey(e => e.IdRequestsForMaintenanceOfPremises);

                entity.Property(e => e.IdRequestsForMaintenanceOfPremises).HasColumnName("ID_RequestsForMaintenanceOfPremises");

                entity.Property(e => e.DateRequests).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeOfCase>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK_Type");

                entity.Property(e => e.IdType).HasColumnName("ID_Type");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
