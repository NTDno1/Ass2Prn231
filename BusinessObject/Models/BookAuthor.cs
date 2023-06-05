using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string AuthorOrder { get; set; } = null!;
        public int? RoyalityPercentage { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;

    }
}
