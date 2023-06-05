using BusinessObject.Models;

namespace DataAsset.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly Assignment2Context _db;
        public BookRepository(Assignment2Context db)
        {
            _db = db;
        }
        public List<Book> getList()
        {
            List<Book> books = _db.Books.ToList();
            return books;
        }
    }
}
