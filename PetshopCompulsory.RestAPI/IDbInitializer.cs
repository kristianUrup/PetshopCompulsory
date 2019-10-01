using Petshop.Infrastructure.SQL;

namespace PetshopCompulsory.RestAPI
{
    public interface IDbInitializer
    {
        void SeedDb(PetShopContext ctx);
    }
}
