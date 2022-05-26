﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class User : Entity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Enabled { get; set; }

        public string RegistrationToken {get; set;}

        public string ResetPasswordToken { get; set; }

        public UserType UserType { get; set; }

        public bool IsPublic { get; set; }

        public bool IsExperienced { get; set; }

        public string Education { get; set; }

        public string Interest { get; set; }

        public string Description { get; set; }

    }
}
