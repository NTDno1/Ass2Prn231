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
            List<Author> author = _db.Authors.ToList();
            return author;
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
        public void AddAuthor(AuthorCreateDTO authorCreate)
        {
            try
            {
                Author author = new Author()
                {
                    LastName = authorCreate.LastName,
                    FirstName = authorCreate.FirstName,
                    Phone = authorCreate.Phone,
                    Address = authorCreate.Address,
                    City = authorCreate.City,
                    State = authorCreate.State,
                    Zip = authorCreate.Zip,
                    EmailAdress = authorCreate.EmailAdress,
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

        public List<Author> SearchValue(string? lastname, string? firstname, string? city)
        {
            //List<Author> list = new List<Author>();
            List<Author> author = _db.Authors.Where(u => u.LastName.Contains(lastname??"") || u.FirstName.Contains(firstname??"")|| u.City.Contains(city ?? "")).ToList();

            return author;
        }
        public List<Author> SearchAuthorById(int id)
        {
            List<Author> authors = _db.Authors.Where(u => u.AuthorId == id).ToList();
            return authors;
        }
    }
}
      