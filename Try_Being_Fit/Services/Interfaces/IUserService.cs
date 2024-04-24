namespace Services.Interfaces
{
    public interface IUserService
    {
        void LogIn(string userName, string password);
        void LogOut();
        void RegisterNewUser(string firstName, string lastName, string userName, string password);
        void UpdgradeToPremium();
        string AccountInfo();
    }
}
