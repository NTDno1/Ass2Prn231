using BusinessObject.Models;

namespace DataAsset.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Assignment2Context _db;
        public AuthorRepository(Assignment2Context db)
        {
            _db = db;
        }

        public List<Author> getAll()
        {
            List<Author> books = _db.Authors.ToList();
            return books;
        }
    }
}
