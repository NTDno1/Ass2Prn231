using BusinessObject.Models;

namespace DataAsset.Repository
{
    public interface IPublisherRepository
    {
        List<Publisher> GetList();
        public Publisher getPublisherId(int id);
        public void DeletePublisher(int id);
    }
}
