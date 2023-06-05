using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? RoleId { get; set; }
        public int? PubId { get; set; }
        public DateTime HireDate { get; set; }

        public virtual Publisher? Pub { get; set; }
        public virtual Role? Role { get; set; }
    }
}
