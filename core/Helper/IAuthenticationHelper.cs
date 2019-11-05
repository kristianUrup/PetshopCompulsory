using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetshopCompulsory.Core.Entity;

namespace PetshopCompulsory.Core.Helper
{
    public interface IAuthenticationHelper
    {
        void GenerateToken(User user);
    }
}
