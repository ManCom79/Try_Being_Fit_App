using Database;
using Models;
using Services.Interfaces;

namespace Services.Implamentations
{
    public class UserService : IUserService
    {
        public void LogIn(string userName, string password)
        {
            var logUser = DatabaseDefinition.People.GetAll().FirstOrDefault(x => x.UserName == userName);
            try
            {
                if (logUser == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception($"User with the provided username {userName} does not exist.");
                }
                if (!logUser.CheckPassword(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception($"Wrong password. Please try again.");
                }

                CurrentSession.CurrentUser = logUser;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void LogOut()
        {
            CurrentSession.CurrentUser = null;
            Console.Clear();
        }
        public void RegisterNewUser(string firstName, string lastName, string userName, string password)
        {
            Person newStandardUser = new Person(firstName, lastName, userName, password, Models.Enums.AccountTypeEnum.Standard);
            DatabaseDefinition.People.Add(newStandardUser);
        }

        public string AccountInfo()
        {
            return $"Name: {CurrentSession.CurrentUser.FirstName} {CurrentSession.CurrentUser.LastName}\nAccount username: {CurrentSession.CurrentUser.UserName}\nAccount Type: {CurrentSession.CurrentUser.AccountType}\n";
        }    

        public void UpdgradeToPremium()
        {
            CurrentSession.CurrentUser.AccountType = Models.Enums.AccountTypeEnum.Premium;
        }
    }
}
