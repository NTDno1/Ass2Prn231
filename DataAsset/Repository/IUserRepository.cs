namespace DataAsset.Repository
{
    public interface IUserRepository
    {
        public bool GetUser(string email, string pass);
    }
}
