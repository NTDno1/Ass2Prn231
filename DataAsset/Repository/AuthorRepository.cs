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
        public void AddAuthor(string lastname, string firstname, string phone, string address, string city, string state, string zip, string email)
        {
            try
            {
                Author author = new Author()
                {
                    LastName = lastname,
                    FirstName = firstname,
                    Phone = phone,
                    Address = address,
                    City = city,
                    State = state,
                    Zip = zip,
                    EmailAdress = email,
                };
                _db.Add(author);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public void UpdateAuthor(int id, string lastname, string firstname, string phone, string address, string city, string state, string zip, string email)
        {
            try
            {
                Author author = new Author()
                {
                    AuthorId = id,
                    LastName = lastname,
                    FirstName = firstname,
                    Phone = phone,
                    Address = address,
                    City = city,
                    State = state,
                    Zip = zip,
                    EmailAdress = email,
                };
                _db.Authors.Update(author);
                _db.SaveChanges();
            }

            catch (Exception ex)
            {

            }
        }
    }
}
