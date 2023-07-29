using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_ASP.Net_And_Angular.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AdminLogin> AdminLogins { get; set; }

    public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }

    public virtual DbSet<EmpRegister> EmpRegisters { get; set; }

    public virtual DbSet<HospitalInfo> HospitalInfos { get; set; }

    public virtual DbSet<PoliciesonEmployee> PoliciesonEmployees { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PolicyApprovalDetail> PolicyApprovalDetails { get; set; }

    public virtual DbSet<PolicyRequestDetail> PolicyRequestDetails { get; set; }

    public virtual DbSet<PolicyTotalDescription> PolicyTotalDescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-PV86VKQR\\SQLEXPRESS;Database=HealthInsuranceSystem;user id=sa;password=112233;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83FC62C0B9F");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("securityCode");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AdminLogin>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__AdminLog__C9F284575AF8B36F");

            entity.ToTable("AdminLogin");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("securityCode");
        });

        modelBuilder.Entity<CompanyDetail>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__CompanyD__2D971CACBF123E70");

            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyUrl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CompanyURL");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmpRegister>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("PK__EmpRegis__AF4C318A8ADECF30");

            entity.ToTable("EmpRegister");

            entity.Property(e => e.Empno).HasColumnName("empno");
            entity.Property(e => e.AccountStatus).HasColumnName("accountStatus");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Contactno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contactno");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('customer')")
                .HasColumnName("designation");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Joindate)
                .HasColumnType("datetime")
                .HasColumnName("joindate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rolename)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('user')")
                .HasColumnName("rolename");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("securityCode");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<HospitalInfo>(entity =>
        {
            entity.HasKey(e => e.HospitalId).HasName("PK__Hospital__38C2E5AFCB814294");

            entity.ToTable("HospitalInfo");

            entity.Property(e => e.HospitalName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PoliciesonEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Policies__3213E83FC10E51E5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Companyname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("companyname");
            entity.Property(e => e.Emi)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("emi");
            entity.Property(e => e.Empno).HasColumnName("empno");
            entity.Property(e => e.Policyamount)
                .HasColumnType("money")
                .HasColumnName("policyamount");
            entity.Property(e => e.Policyduration)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("policyduration");
            entity.Property(e => e.Policyid).HasColumnName("policyid");
            entity.Property(e => e.Policyname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policyname");
            entity.Property(e => e.Policystatus).HasColumnName("policystatus");

            entity.HasOne(d => d.EmpnoNavigation).WithMany(p => p.PoliciesonEmployees)
                .HasForeignKey(d => d.Empno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policiesonemployees_EmpRegister");

            entity.HasOne(d => d.Policy).WithMany(p => p.PoliciesonEmployees)
                .HasForeignKey(d => d.Policyid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policiesonemployees_Policies");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.Policyid).HasName("PK__Policies__78E0AD0A44825DB9");

            entity.Property(e => e.Policyid).HasColumnName("policyid");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Emi).HasColumnType("money");
            entity.Property(e => e.Medicalid).HasColumnName("medicalid");
            entity.Property(e => e.Policydesc)
                .HasColumnType("text")
                .HasColumnName("policydesc");
            entity.Property(e => e.Policyname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policyname");

            entity.HasOne(d => d.Company).WithMany(p => p.Policies)
                .HasForeignKey(d => d.Companyid)
                .HasConstraintName("FK_CompanyDetails_Policies");

            entity.HasOne(d => d.Medical).WithMany(p => p.Policies)
                .HasForeignKey(d => d.Medicalid)
                .HasConstraintName("FK_Hospital_Policies");
        });

        modelBuilder.Entity<PolicyApprovalDetail>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__PolicyAp__2E1339A45738EBDC");

            entity.Property(e => e.PolicyId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Reason).HasColumnType("text");

            entity.HasOne(d => d.Policy).WithOne(p => p.PolicyApprovalDetail)
                .HasForeignKey<PolicyApprovalDetail>(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyApprovalDetails_Policies");

            entity.HasOne(d => d.Request).WithMany(p => p.PolicyApprovalDetails)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_PolicyRequestDetails_PolicyApprovalDetails");
        });

        modelBuilder.Entity<PolicyRequestDetail>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__PolicyRe__33A8517A1D1B6E4C");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Emi).HasColumnType("money");
            entity.Property(e => e.PolicyAmount).HasColumnType("money");
            entity.Property(e => e.Policyname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EmpnoNavigation).WithMany(p => p.PolicyRequestDetails)
                .HasForeignKey(d => d.Empno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpRegister_PolicyRequestDetails");
        });

        modelBuilder.Entity<PolicyTotalDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyTo__3213E83F9C4ABAEF");

            entity.ToTable("PolicyTotalDescription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Emi)
                .HasColumnType("money")
                .HasColumnName("EMI");
            entity.Property(e => e.Medicalname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("medicalname");
            entity.Property(e => e.Policyamount)
                .HasColumnType("money")
                .HasColumnName("policyamount");
            entity.Property(e => e.Policydesc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("policydesc");
            entity.Property(e => e.PolicydurationinMonths).HasColumnName("policydurationinMonths");
            entity.Property(e => e.Policyid).HasColumnName("policyid");
            entity.Property(e => e.Policyname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policyname");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyTotalDescriptions)
                .HasForeignKey(d => d.Policyid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyTotalDescription_Policies");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
