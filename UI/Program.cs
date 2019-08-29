using Core.Entity;
using Petshop.Infrastructure.Data;
using PetshopCompulsory.Core.DomainService;
using System;
using System.Collections.Generic;

namespace UI
{
    class Program
    {
        static IPetRepository petRepository;
        static int id = 1;
        static void Main(string[] args)
        {
            string[] menuItems =
            {
                "List All Pets",
                "Add New Pet",
                "Delete Pet",
                "Edit Pet",
                "Exit"
            };

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i]);
            }
            Console.WriteLine("Choose what you want to do?: ");
            int selection = Convert.ToInt32(Console.ReadLine());


            petRepository = new PetRepository();

            List<Pet> pets = InitPets();

            switch (selection)
            {
                case 1:
                    PrintPets(pets);
                    break;
                case 2:
                    //Add new pet
                    break;
                case 3:
                    //Delete pet
                    break;
                case 4:
                    //Edit Pet
                    break;
                case 5:
                    //exit
                    break;
            }

            
        }

        private static void  PrintPets(List<Pet> pets)
        {
            foreach (Pet pet in pets)
            {
                Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", pet.Id, pet.Name, pet.Price);
            }
        }

        

        
    }
}
