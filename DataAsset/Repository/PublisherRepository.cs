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
                _db.Publishers.Remove(_db.Publishers.Find(id));
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
        public void AddPublisher(string name, string city, string state, string country)
        {
            try
            {
                Publisher publisher = new Publisher()
                {
                    PublisherName = name,
                    City = city,
                    State = state,
                    Country = country
                };
                _db.Publishers.Add(publisher);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
        public void UpdatePublisher(int id, string name, string city, string state, string country)
        {
            try
            {
                Publisher publisher = new Publisher()
                {
                    PubId= id,
                    PublisherName = name,
                    City = city,
                    State = state,
                    Country = country
                };
                _db.Publishers.Update(publisher);
                _db.SaveChanges();
            }

            catch (Exception ex)
            {

            }
        }
    }
}
