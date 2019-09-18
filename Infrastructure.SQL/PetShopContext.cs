using Core.Entity;
using Microsoft.EntityFrameworkCore;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Infrastructure.SQL
{
    public class PetShopContext: DbContext
    {
        public PetShopContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetOwner>().HasKey(po => new
            {
                po.OId,
                po.PId
            });

            modelBuilder.Entity<PetOwner>()
                .HasOne<Pet>(petOwner => petOwner.Pet)
                .WithMany(pet => pet.Owners)
                .HasForeignKey(petOwner => petOwner.PId);

            modelBuilder.Entity<PetOwner>()
                .HasOne<Owner>(petOwner => petOwner.Owner)
                .WithMany(owner => owner.Pets)
                .HasForeignKey(petOwner => petOwner.OId);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
    }
}
