using Core.Entity;
using Infrastructure.Data;
using Petshop.Infrastructure.Data;
using PetshopCompulsory.ConsoleApp;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.ApplicationService.Impl;
using PetshopCompulsory.Core.DomainService;
using System;
using System.Collections.Generic;

namespace UI
{
    class Program
    {
        static IPetService petService;
        static void Main(string[] args)
        {
            FakeDB.InitData();
            var printer = new Printer(new PetService(new PetRepository()));
        }

        

        

        
    }
}
