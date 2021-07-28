using ApplicaitonCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ClientInformationDbContext : DbContext
    {
        public ClientInformationDbContext(DbContextOptions<ClientInformationDbContext> options) : base(options)
        {

        }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Interactions> Interactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(ConfigureClients);
            modelBuilder.Entity<Employees>(ConfigureEmployees);
            modelBuilder.Entity<Interactions>(ConfigureInteractions);
        }

        private void ConfigureClients(EntityTypeBuilder<Clients> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(c => c.Email).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(c => c.Phones).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(c => c.Address).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(c => c.AddedOn).HasColumnType("datetime");
        }

        private void ConfigureEmployees(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(c => c.Password).HasColumnType("varchar").HasMaxLength(10);
            builder.Property(c => c.Designation).HasColumnType("varchar").HasMaxLength(50);

        }



        private void ConfigureInteractions(EntityTypeBuilder<Interactions> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(ec => ec.Id);
            builder.HasOne(ec => ec.Employees).WithMany(ec => ec.Interactions).HasForeignKey(ec => ec.EmpId);
            builder.HasOne(ec => ec.Clients).WithMany(ec => ec.Interactions).HasForeignKey(ec => ec.ClientId);
            builder.Property(ec => ec.IntType).HasColumnType("char(1)");
            builder.Property(ec => ec.IntDate).HasColumnType("datetime");
            builder.Property(ec => ec.Remarks).HasColumnType("varchar").HasMaxLength(500);

        }
    }
}
