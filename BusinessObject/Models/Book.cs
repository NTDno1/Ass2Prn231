using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? PubId { get; set; }
        public int? Price { get; set; }
        public string Advance { get; set; } = null!;
        public string Royalty { get; set; } = null!;
        public string YtdSales { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public DateTime PublishedDate { get; set; }

        public virtual Publisher? Pub { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public override string? ToString()
        {
            return "Bookid" + BookId + "Title" + Title;
        }
    }
}
