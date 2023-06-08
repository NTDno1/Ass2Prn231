using BusinessObject.Models;

namespace DataAsset.Repository
{
    public interface IAuthorRepository
    {
        public List<Author> getAll();
        public Author getAuthorid(int id);
        public void DeleteAuthor(int id);
        public void AddAuthor(string lastname, string firstname, string phone, string address, string city, string state, string zip, string email);
        public void UpdateAuthor(int id, string lastname, string firstname, string phone, string address, string city, string state, string zip, string email);
    }
}
