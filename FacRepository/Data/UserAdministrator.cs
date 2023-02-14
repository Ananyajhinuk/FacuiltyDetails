using System;
using System.Collections.Generic;

namespace FacRepository.Data
{
    public partial class UserAdministrator
    {
        public short UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
