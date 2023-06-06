using BusinessObject.Models;

namespace DataAsset.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Assignment2Context _db;
        public UserRepository(Assignment2Context db)
        {
            _db = db;
        }
        public bool GetUser(string email, string pass)
        {
            User user = _db.Users.FirstOrDefault(u => u.EmailAddress == email && u.Password == pass);
            if(user == null) {
            return false;
            }
            return true; 
        }
    }
}
