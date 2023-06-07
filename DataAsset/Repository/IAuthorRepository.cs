using BusinessObject.Models;

namespace DataAsset.Repository
{
    public interface IAuthorRepository
    {
        public List<Author> getAll();
        public Author getAuthorid(int id);  
    }
}
