using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class AdminLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
