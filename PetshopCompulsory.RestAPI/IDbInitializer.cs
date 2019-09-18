using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petshop.Infrastructure.SQL;

namespace PetshopCompulsory.RestAPI
{
    public interface IDbInitializer
    {
        void SeedDb(PetShopContext ctx);
    }
}
