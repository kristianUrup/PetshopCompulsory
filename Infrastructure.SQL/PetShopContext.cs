using PetshopCompulsory.Core.Entity;
using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<PetOwner>()
                .HasKey(po => new{po.Id});

            modelBuilder.Entity<PetOwner>()
                .HasOne(petOwner => petOwner.Pet)
                .WithMany(pet => pet.Owners)
                .HasForeignKey(petOwner => petOwner.PetId);

            modelBuilder.Entity<PetOwner>()
                .HasOne(petOwner => petOwner.Owner)
                .WithMany(owner => owner.Pets)
                .HasForeignKey(petOwner => petOwner.OwnerId);


            modelBuilder.Entity<PetColor>().HasKey(pc => new
            {
                pc.Id
            });

            modelBuilder.Entity<PetColor>()
                .HasOne(petColor => petColor.Pet)
                .WithMany(pet => pet.Colors)
                .HasForeignKey(petColor => petColor.PetId);

            modelBuilder.Entity<PetColor>()
                .HasOne(petColor => petColor.Color)
                .WithMany(color => color.Pets)
                .HasForeignKey(petColor => petColor.ColorId);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
