using Core.Entity;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.ApplicationService.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.ConsoleApp
{
    public class Printer: IPrinter
    {

        IPetService petService;

        public Printer(IPetService petSer)
        {
            petService = petSer;
            Choices();
        }

        public void Choices()
        {
            string[] menuItems =
            {
                "List all Pets",
                "Add new Pet",
                "Delete Pet",
                "Edit Pet",
                "Find the 5 cheapest pets",
                "Sorted list in ascending order by the price",
                "Search pets by type",
                "Exit"
            };

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i]);
            }
            int selection = int.Parse(WriteAndRead("Choose what you want to do?: "));

            while ((selection > 7) || (selection < 0))
            {
                WriteLine("You need to make a choice betweenn 1-6");
                Choices();
            }
            HandleChoice(selection);


        }

        public void PrintPets()
        {
            foreach (Pet pet in petService.GetPets())
            {
                Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", pet.Id, pet.Name, pet.Price);
            }
        }

        public void HandleChoice(int selection)
        {
            switch (selection)
            {
                case 1:
                    PrintPets();
                    break;
                case 2:
                    CreatePet();
                    break;
                case 3:
                    DeletePet();
                    break;
                case 4:
                    EditPet();
                    break;
                case 5:
                    FiveCheapestPets();
                    break;
                case 6:
                    SortedByPrice();
                    break;
                case 7:
                    SearchType();
                    break;
                case 8:
                    Exit();
                    break;
            }

        }

        public void SearchType()
        {
            Console.Clear();
            string type = WriteAndRead("Insert which type of pet you want to find: ");
            List<Pet> searchedPets = petService.SearchForType(type);
            foreach (var pet in searchedPets)
            {
                Console.WriteLine("Name: {0}, Type: {1}, Price: {2}", pet.Name, pet.Type, pet.Price);
            }
            Choices();
        }

        public void SortedByPrice()
        {
            Console.Clear();
            WriteLine("This is ascending by the price of the pet: ");
            foreach (var pet in petService.OrderByPrice())
            {
                Console.WriteLine("Name: {0}, Price: {1}, Type: {2}", pet.Name, pet.Price, pet.Type);
            }
            WriteLine("");
            Choices();
        }

        public void FiveCheapestPets()
        {
            Console.Clear();
            WriteLine("This is the 5 cheapest pets:");
            foreach (var pet in petService.FiveCheapestPets())
            {
                Console.WriteLine("Name: {0}, Price: {1}, Type: {2} ", pet.Name, pet.Price, pet.Type);
            }
            WriteLine("What to do next? ");
            Choices();
        }
        public void EditPet()
        {
            Console.Clear();
            PrintPets();
            int id = int.Parse(WriteAndRead("Which pet do you want to edit?\nType the id: "));
            Pet pet = petService.GetPet(id);
            Console.WriteLine("You want to change {0} the {1} ", pet.Name, pet.Type);
            int answer = int.Parse(WriteAndRead("\n1:Yes\n2:No\n"));

            if (answer == 1)
            {
                UpdatePet(pet);
            }
        }

        public void UpdatePet(Pet pet)
        {

            int id = int.Parse(WriteAndRead("Type the id of the pet, which you wanna edit"));
            Pet updatePet = petService.GetPet(id);
            if (updatePet != null)
            {
                WriteLine("Type the new informations");
                string name = WriteAndRead("\nName: ");
                double price = double.Parse(WriteAndRead("\nPrice: "));
                string previousOwner = WriteAndRead("\nPrevious owner: ");
                Pet updatedPet = new Pet
                {
                    Name = name,
                    Price = price,
                    PreviousOwner = previousOwner

                };
                petService.Update(id, updatedPet);
            }
        }
        public void Exit()
        {
            System.Environment.Exit(1);
        }

        public void DeletePet()
        {
            Console.Clear();
            WriteLine("This is all the pets \n");
            PrintPets();
            int id = int.Parse(WriteAndRead("\n Type the id of the pet you want to delete: "));
            foreach (Pet pet in petService.GetPets())
                {
                if (pet.Id == id)
                {
                    Console.Clear();
                    Console.WriteLine("You have deleted {0}, which is a {1}", pet.Name, pet.Type);
                    petService.Delete(id);
                    Choices();
                }
                else
                {
                    WriteLine("There was no pets with that id");
                }
            }
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void CreatePet()
        {
            Console.Clear();
            WriteLine("Now insert the values for the new pet underneath");
            string name = WriteAndRead("*Name: ");
            string type = WriteAndRead("*Type: ");
            DateTime birthdate = DateTime.Parse(WriteAndRead("*Birthdate: "));
            DateTime soldDate = DateTime.Parse(WriteAndRead("SoldDate: "));
            string color = WriteAndRead("*Color: ");
            string previousOwner = WriteAndRead("*Previous owner: ");
            double price = double.Parse(WriteAndRead("Price: "));

            Console.Clear();
            string birthdateString = birthdate.ToString("yyyyMMdd");
            string soldDateString = soldDate.ToString("yyyyMMdd");

            Console.WriteLine("\nName: {0},\nType: {1},\nBirthDate: {2},\nSoldDate: {3},\nColor: {4}," +
            " \nPrevious owner: {5},\nPrice: {6}\n has been created",
            name, type, birthdateString, soldDateString, color, previousOwner, price);
            int question = int.Parse(WriteAndRead("Do you want to save the pet?:\n1:Yes\n2:No"));

            if (question == 1)
            {
                Pet pet = petService.NewPet(name, type, birthdate, soldDate, color, previousOwner, price);
                Console.WriteLine("\nName: {0},\nType: {1},\nBirthDate: {2},\nSoldDate: {3},\nColor: {4}," +
                " \nPrevious owner: {5},\nPrice: {6}\n has been created",
                name, type, birthdateString, soldDateString, color, previousOwner, price);
            }
            else
            {
                Console.Clear();
                Choices();
            }
        }

        public void SavePet(Pet pet)
        {
            petService.Create(pet);
        }

        public string WriteAndRead(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }
    }
}
