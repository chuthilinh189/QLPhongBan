namespace QLPhongBan.Models.Context
{
     using System;
     using System.Data.Entity;
     using System.ComponentModel.DataAnnotations.Schema;
     using System.Linq;

     public partial class DBContext : DbContext
     {
          public DBContext()
              : base("name=DBContext")
          {
          }

          public virtual DbSet<department> departments { get; set; }
          public virtual DbSet<departmentpositionhi> departmentpositionhis { get; set; }
          public virtual DbSet<managegroup> managegroups { get; set; }
          public virtual DbSet<position> positions { get; set; }
          public virtual DbSet<staff> staffs { get; set; }
          public virtual DbSet<staffmanagergroup> staffmanagergroups { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               modelBuilder.Entity<department>()
                   .Property(e => e.code)
                   .IsUnicode(false);

               modelBuilder.Entity<department>()
                   .Property(e => e.parentcode)
                   .IsUnicode(false);

               modelBuilder.Entity<department>()
                   .Property(e => e.phone)
                   .IsUnicode(false);

               modelBuilder.Entity<department>()
                   .Property(e => e.email)
                   .IsUnicode(false);

               modelBuilder.Entity<department>()
                   .Property(e => e.edituser)
                   .IsUnicode(false);

               modelBuilder.Entity<department>()
                   .HasMany(e => e.departmentpositionhis)
                   .WithRequired(e => e.department)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<department>()
                   .HasMany(e => e.department1)
                   .WithOptional(e => e.department2)
                   .HasForeignKey(e => e.parentcode);

               modelBuilder.Entity<managegroup>()
                   .HasMany(e => e.staffmanagergroups)
                   .WithRequired(e => e.managegroup)
                   .HasForeignKey(e => e.managegroupcode)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<departmentpositionhi>()
                   .Property(e => e.code)
                   .IsUnicode(false);

               modelBuilder.Entity<departmentpositionhi>()
                   .Property(e => e.staffcode)
                   .IsUnicode(false);

               modelBuilder.Entity<departmentpositionhi>()
                   .Property(e => e.departmentcode)
                   .IsUnicode(false);

               modelBuilder.Entity<departmentpositionhi>()
                   .Property(e => e.positioncode)
                   .IsUnicode(false);

               modelBuilder.Entity<departmentpositionhi>()
                   .Property(e => e.approvedby)
                   .IsUnicode(false);

               modelBuilder.Entity<managegroup>()
                   .Property(e => e.code)
                   .IsUnicode(false);

               modelBuilder.Entity<position>()
                   .Property(e => e.code)
                   .IsUnicode(false);

               modelBuilder.Entity<position>()
                   .HasMany(e => e.departmentpositionhis)
                   .WithRequired(e => e.position)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<staff>()
                   .Property(e => e.code)
                   .IsUnicode(false);

               modelBuilder.Entity<staff>()
                   .Property(e => e.mobiphone)
                   .IsUnicode(false);

               modelBuilder.Entity<staff>()
                   .Property(e => e.email)
                   .IsUnicode(false);

               modelBuilder.Entity<staff>()
                   .Property(e => e.departmentcode)
                   .IsUnicode(false);

               modelBuilder.Entity<staff>()
                   .Property(e => e.positioncode)
                   .IsUnicode(false);

               modelBuilder.Entity<staff>()
                   .HasMany(e => e.departmentpositionhis)
                   .WithRequired(e => e.staff)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<staff>()
                   .HasMany(e => e.staffmanagergroups)
                   .WithRequired(e => e.staff)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<staffmanagergroup>()
                   .Property(e => e.code)
                   .IsUnicode(false);

               modelBuilder.Entity<staffmanagergroup>()
                   .Property(e => e.staffcode)
                   .IsUnicode(false);

               modelBuilder.Entity<staffmanagergroup>()
                   .Property(e => e.managegroupcode)
                   .IsUnicode(false);
          }
     }
}
