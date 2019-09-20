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
            modelBuilder.Entity<Pet>()
                .HasMany(pet => pet.Owners)
                .WithOne(po => po.Pet)
                .HasForeignKey(petOwner => petOwner.PetId);

            modelBuilder.Entity<Owner>()
                .HasMany(owner => owner.Pets)
                .WithOne(petOwner => petOwner.Owner)
                .HasForeignKey(petOwner => petOwner.OwnerId);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
