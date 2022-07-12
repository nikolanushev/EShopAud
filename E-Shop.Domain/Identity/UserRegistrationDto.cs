using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Domain.Identity
{
    public class UserRegistrationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
