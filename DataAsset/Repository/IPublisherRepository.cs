using BusinessObject.Models;

namespace DataAsset.Repository
{
    public interface IPublisherRepository
    {
        List<Publisher> GetList();
        public Publisher getPublisherId(int id);
        public void DeletePublisher(int id);
        public void UpdatePublisher(int id, string name, string city, string state, string country);
        public void AddPublisher(string name, string city, string state, string country);
        public List<Publisher> getPubByValue(string name, string city);
    }
}
