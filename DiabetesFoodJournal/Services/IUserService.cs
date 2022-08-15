namespace Services
{
    public interface IUserService
    {
        public Task<bool> ValidateCredentials(string userName, string password);
    }
}