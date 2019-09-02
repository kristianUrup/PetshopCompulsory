using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.ConsoleApp
{
    interface IPrinter
    {
        void Choices();
        void PrintPets();
        void HandleChoice(int selection);
        void SearchType();
        void SortedByPrice();
        void FiveCheapestPets();
        void EditPet();
        void UpdatePet(Pet pet);
        void Exit();
        void DeletePet();
        void WriteLine(string input);
        void CreatePet();
        void SavePet(Pet pet);
        string WriteAndRead(string input);

    }
}
