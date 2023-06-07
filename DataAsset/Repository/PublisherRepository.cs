using BusinessObject.Models;

namespace DataAsset.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly Assignment2Context _db;
        public PublisherRepository(Assignment2Context db)
        {
            _db = db;
        }
        public List<Publisher> GetList()
        {
            List<Publisher> publishers = _db.Publishers.ToList();
            return publishers;
        }
        public Publisher getPublisherId(int id)
        {
            Publisher publisher = _db.Publishers.FirstOrDefault(u => u.PubId == id); 
            return publisher;
        }
        public void DeletePublisher(int id)
        {
            try
            {
                using (Assignment2Context context = new Assignment2Context())
                {
                    context.Publishers.Remove(context.Publishers.Find(id));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
