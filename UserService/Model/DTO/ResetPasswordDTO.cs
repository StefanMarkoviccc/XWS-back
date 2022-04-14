using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model.DTO
{
    public class ResetPasswordDTO
    {
        public string Token { get; set; }

        public string Password { get; set; }
    }
}
