using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class AuthorCreateDTO
    {
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Zip { get; set; } = null!;
        public string EmailAdress { get; set; } = null!;
    }
}
