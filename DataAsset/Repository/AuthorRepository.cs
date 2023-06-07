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
        public Author getAuthorid(int id)
        {
            Author author = _db.Authors.FirstOrDefault(u => u.AuthorId == id);
            return author;
        }
        public void DeleteAuthor(int id)
        {
            try
            {
                using (Assignment2Context context = new Assignment2Context())
                {

                    //check xem code có ?n t?i không
                    context.Authors.Remove(context.Authors.Find(id));
                    context.SaveChanges();
                    //update thông tin cho student


                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
