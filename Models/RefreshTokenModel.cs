using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Reformation.Models
{
    public class RefreshTokenModel
    {
        public int Id { get; set; }
        public required UserModel User { get; set; }        
        public required string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
        public required bool IsRevoked { get; set; }
    }
}