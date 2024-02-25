﻿using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFramework.Context
{
    public class RentACarContext : DbContext
    {

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Userr> Userrs { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet <UserRole> UserRoles { get; set; }

        public RentACarContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Premium).HasDefaultValue(true);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
