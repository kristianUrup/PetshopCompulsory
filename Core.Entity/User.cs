using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.Entity
{
    public class User
    {
        
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Owner Owner { get; set; }
        public bool IsAdmin { get; set; }
    }
}
