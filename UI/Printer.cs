﻿using Core.Entity;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.ApplicationService.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.ConsoleApp
{
    public class Printer
    {
        
        IPetService petService;
        
        public Printer(IPetService petSer)
        {
            petService = petSer;
            Choices();
        }

        private void Choices()
        {
            string[] menuItems =
            {
                "List all Pets",
                "Add new Pet",
                "Delete Pet",
                "Edit Pet",
                "Exit"
            };

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i]);
            }
            Console.WriteLine("Choose what you want to do?: ");

            HandleChoice(Convert.ToInt32(Console.ReadLine()));
        }

        private void PrintPets()
        {
            foreach (Pet pet in petService.GetPets())
            {
                Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", pet.Id, pet.Name, pet.Price);
            }
        }

        private void HandleChoice(int selection)
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
                    //Edit Pet
                    break;
                case 5:
                    Exit();
                    break;
            }

        }

        private void Exit()
        {
            
        }

        private void EditPet()
        {
            PrintPets();
            int id = int.Parse(WriteAndRead("Which pet do you want to edit?\nType the id: "));
            Pet pet = petService.GetPet(id);
            Console.WriteLine("You want to change {0} the {1} ", pet.Name, pet.Type);
            int answer = int.Parse(WriteAndRead("\n1:Yes\n2:No"));

        }


        private void DeletePet()
        {
            Console.Clear();
            WriteLine("This is all the pets \n");
            PrintPets();
            int id = int.Parse(WriteAndRead("\n Type the id of the pet you want to delete: "));
            foreach (Pet pet in petService.GetPets())
            {
                if(pet.Id == id)
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

        private void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        private void CreatePet()
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

            if(question == 1)
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

        private void SavePet(Pet pet)
        {
            petService.Create(pet);
        }

        private string WriteAndRead(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }
    }
}
