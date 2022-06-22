using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class AccountToken
    {
        public int AtId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? CreateToken { get; set; }
        public bool? Status { get; set; }
    }
}
