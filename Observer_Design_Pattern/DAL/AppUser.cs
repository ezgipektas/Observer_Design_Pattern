﻿using Microsoft.AspNetCore.Identity;

namespace Observer_Design_Pattern.DAL
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
