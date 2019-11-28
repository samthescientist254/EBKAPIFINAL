using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class PasswordResetTokens
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; }
        public string ExpiryDate { get; set; }
        public Admin Admin { get; set; }

        public PasswordResetTokens() { }
    }
}
