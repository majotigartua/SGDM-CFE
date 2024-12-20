﻿using Microsoft.EntityFrameworkCore;
using SGDM_CFE.Model.Models;
using Type = SGDM_CFE.Model.Models.Type;

namespace SGDM_CFE.Model
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<BusinessProcess> BusinessProcesses { get; set; }
        public virtual DbSet<CostCenter> CostCenters { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<MobileDevice> MobileDevices { get; set; }
        public virtual DbSet<OpticalReader> OpticalReaders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SIMCard> SIMCards { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkCenter> WorkCenters { get; set; }
        public virtual DbSet<WorkCenterBusinessProcess> WorkCenterBusinessProcesses { get; set; }
        public virtual DbSet<WorkCenterCostCenter> WorkCenterCostCenters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SGDM-CFE;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Area");
                entity.Property(e => e.Id).HasColumnName("IdArea");
                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Assignment");
                entity.Property(e => e.Id).HasColumnName("IdAssignment");
                entity.Property(e => e.AssignmentDate).HasColumnType("datetime");
                entity.Property(e => e.ReturnDate).HasColumnType("datetime");
                entity.Property(e => e.EmployeeId).HasColumnName("IdEmployee");
                entity.Property(e => e.AssignmentStateId).HasColumnName("IdAssignmentState");
                entity.Property(e => e.ReturnStateId).HasColumnName("IdReturnState");   
                entity.HasOne(d => d.AssignmentState).WithMany(p => p.AssignmentStateAssignments).HasForeignKey(d => d.AssignmentStateId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Assignment_AssignmentState");
                entity.HasOne(d => d.Employee).WithMany(p => p.Assignments).HasForeignKey(d => d.EmployeeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Assignment_Employee");
                entity.HasOne(d => d.ReturnState).WithMany(p => p.ReturnStateAssignments).HasForeignKey(d => d.ReturnStateId).HasConstraintName("FK_Assignment_ReturnState");
            });

            modelBuilder.Entity<BusinessProcess>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("BusinessProcess");
                entity.Property(e => e.Id).HasColumnName("IdBusinessProcess");
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CostCenter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("CostCenter");
                entity.Property(e => e.Id).HasColumnName("IdCostCenter");
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Device");
                entity.Property(e => e.Id).HasColumnName("IdDevice");
                entity.Property(e => e.InventoryNumber).HasMaxLength(50);
                entity.Property(e => e.Notes).HasColumnType("text");
                entity.Property(e => e.SerialNumber).HasMaxLength(100);
                entity.Property(e => e.WorkCenterId).HasColumnName("IdWorkCenter");
                entity.HasOne(d => d.WorkCenter).WithMany(p => p.Devices).HasForeignKey(d => d.WorkCenterId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Device_WorkCenter");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Employee");
                entity.Property(e => e.Id).HasColumnName("IdEmployee");
                entity.Property(e => e.MaternalSurname).HasMaxLength(100);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.PaternalSurname).HasMaxLength(100);
                entity.Property(e => e.RPE).HasMaxLength(50);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.UserId).HasColumnName("IdUser");
                entity.HasOne(d => d.User).WithMany(p => p.Employees).HasForeignKey(d => d.UserId).HasConstraintName("FK_Employee_User");
            });

            modelBuilder.Entity<MobileDevice>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("MobileDevice");
                entity.Property(e => e.Id).HasColumnName("IdMobileDevice");
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.DeviceId).HasColumnName("IdDevice");
                entity.Property(e => e.SIMCardId).HasColumnName("IdSIMCard");
                entity.Property(e => e.TypeId).HasColumnName("IdType");
                entity.HasOne(d => d.Device).WithMany(p => p.MobileDevices).HasForeignKey(d => d.DeviceId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MobileDevice_Device");
                entity.HasOne(d => d.SIMCard).WithMany(p => p.MobileDevices).HasForeignKey(d => d.SIMCardId).HasConstraintName("FK_MobileDevice_SIMCard");
                entity.HasOne(d => d.Type).WithMany(p => p.MobileDevices).HasForeignKey(d => d.TypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MobileDevice_Type");
            });

            modelBuilder.Entity<OpticalReader>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("OpticalReader");
                entity.Property(e => e.Id).HasColumnName("IdOpticalReader");
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.DeviceId).HasColumnName("IdDevice");
                entity.HasOne(d => d.Device).WithMany(p => p.OpticalReaders).HasForeignKey(d => d.DeviceId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OpticalReader_Device");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Role");
                entity.Property(e => e.Id).HasColumnName("IdRole");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<SIMCard>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("SIMCard");
                entity.Property(e => e.Id).HasColumnName("IdSIMCard");
                entity.Property(e => e.SerialNumber).HasMaxLength(100);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("State");
                entity.Property(e => e.Id).HasColumnName("IdState");
                entity.Property(e => e.FailuresDescription).HasMaxLength(255);
                entity.Property(e => e.DeviceId).HasColumnName("IdDevice");
                entity.Property(e => e.WorkCenterBusinessProcessId).HasColumnName("IdWorkCenter_BusinessProcess");
                entity.Property(e => e.WorkCenterCostCenterId).HasColumnName("IdWorkCenter_CostCenter");
                entity.Property(e => e.ReviewNotes).HasColumnType("text");
                entity.HasOne(d => d.Device).WithMany(p => p.States).HasForeignKey(d => d.DeviceId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_State_Device");
                entity.HasOne(d => d.WorkCenterBusinessProcess).WithMany(p => p.States).HasForeignKey(d => d.WorkCenterBusinessProcessId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_State_WorkCenter_BusinessProcess");
                entity.HasOne(d => d.WorkCenterCostCenter).WithMany(p => p.States).HasForeignKey(d => d.WorkCenterCostCenterId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_State_WorkCenter_CostCenter");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Type");
                entity.Property(e => e.Id).HasColumnName("IdType");
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("User");
                entity.Property(e => e.Id).HasColumnName("IdUser");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.Property(e => e.RoleId).HasColumnName("IdRole");
                entity.HasOne(d => d.Role).WithMany(p => p.Users).HasForeignKey(d => d.RoleId) .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<WorkCenter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("WorkCenter");
                entity.Property(e => e.Id).HasColumnName("IdWorkCenter");
                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.AreaId).HasColumnName("IdArea");
                entity.HasOne(d => d.Area).WithMany(p => p.WorkCenters).HasForeignKey(d => d.AreaId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkCenter_Area");
            });

            modelBuilder.Entity<WorkCenterBusinessProcess>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("WorkCenter_BusinessProcess");
                entity.Property(e => e.Id).HasColumnName("IdWorkCenter_BusinessProcess");
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.BusinessProcessId).HasColumnName("IdBusinessProcess");
                entity.Property(e => e.WorkCenterId).HasColumnName("IdWorkCenter");
                entity.HasOne(d => d.BusinessProcess).WithMany(p => p.WorkCenterBusinessProcesses).HasForeignKey(d => d.BusinessProcessId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkCenter_BusinessProcess_BusinessProcess");
                entity.HasOne(d => d.WorkCenter).WithMany(p => p.WorkCenterBusinessProcesses).HasForeignKey(d => d.WorkCenterId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkCenter_BusinessProcess_WorkCenter");
            });

            modelBuilder.Entity<WorkCenterCostCenter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("WorkCenter_CostCenter");
                entity.Property(e => e.Id).HasColumnName("IdWorkCenter_CostCenter");
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CostCenterId).HasColumnName("IdCostCenter");
                entity.Property(e => e.WorkCenterId).HasColumnName("IdWorkCenter");
                entity.HasOne(d => d.CostCenter).WithMany(p => p.WorkCenterCostCenters).HasForeignKey(d => d.CostCenterId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkCenter_CostCenter_CostCenter");
                entity.HasOne(d => d.WorkCenter).WithMany(p => p.WorkCenterCostCenters).HasForeignKey(d => d.WorkCenterId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_WorkCenter_CostCenter_WorkCenter");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}