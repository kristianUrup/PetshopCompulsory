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

            

            modelBuilder.Entity<PetOwner>()
                .HasOne<Pet>(petOwner => petOwner.Pet)
                .WithMany(pet => pet.Owners)
                .HasForeignKey(petOwner => petOwner.PetId);

            modelBuilder.Entity<PetOwner>()
                .HasOne<Owner>(petOwner => petOwner.Owner)
                .WithMany(owner => owner.Pets)
                .HasForeignKey(petOwner => petOwner.OwnerId);


            modelBuilder.Entity<PetColor>().HasKey(pc => new
            {
                pc.ColorId,
                pc.PetId
            });

            modelBuilder.Entity<PetColor>()
                .HasOne<Pet>(petColor => petColor.Pet)
                .WithMany(pet => pet.Colors)
                .HasForeignKey(petColor => petColor.PetId);

            modelBuilder.Entity<PetColor>()
                .HasOne<Color>(petColor => petColor.Color)
                .WithMany(color => color.Pets)
                .HasForeignKey(petColor => petColor.ColorId);

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
