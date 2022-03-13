using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<School>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Name).HasMaxLength(50).IsRequired();
                x.Property(p=>p.PhoneNumber).HasMaxLength(15);
                x.Property(p => p.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                x.HasMany(p => p.ClassRooms).WithOne(p => p.School);
                x.HasIndex(p=>p.Name);
                x.HasIndex(p=>p.PhoneNumber);
            });

            modelBuilder.Entity<ClassRoom>(x => {
                x.HasKey(p => p.Id);
                x.Property(p=>p.Name).HasMaxLength(50).IsRequired();
                x.Property(p => p.AgeRange).HasDefaultValue(1).IsRequired();
                x.Property(p => p.SchoolId).IsRequired();
                x.HasOne(p=>p.School).WithMany(p=>p.ClassRooms)
                .HasForeignKey(k=>k.SchoolId);
                x.HasIndex(p => p.Name);
                x.HasIndex(p => p.SchoolId);
            });
        }
        public DbSet<School> Schools { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
    }
}
