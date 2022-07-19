using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Models
{
    public class AccountSignup  
    {
        [Required]
        [MinLength(2, ErrorMessage = "Username must be at least 2 characters")]
        [MaxLength(30, ErrorMessage = "Username must be at most 30 characters")]
        [RegularExpression(@"^([a-zA-Z0-9 ]){2,30}$", ErrorMessage = "Username must be letters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$",ErrorMessage = "Password minimum six characters, at least one letter, one number and one special character")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password is required")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage ="Password not match")]
        public string CfPassword { get; set; }
        public int? RoleId { get; set; }
    }
}
