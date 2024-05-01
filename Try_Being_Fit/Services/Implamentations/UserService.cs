using Database;
using Models;
using Services.Interfaces;

namespace Services.Implamentations
{
    public class UserService : IUserService
    {
        public DatabaseDefinition _databaseDefinitions;

        public UserService()
        {
            _databaseDefinitions = new DatabaseDefinition();
        }
        public void LogIn(string userName, string password)
        {
            var logUser = _databaseDefinitions.People.GetAll().FirstOrDefault(x => x.UserName == userName);
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
            _databaseDefinitions.People.Add(newStandardUser);
        }

        public string AccountInfo()
        {
            return $"Name: {CurrentSession.CurrentUser.FirstName} {CurrentSession.CurrentUser.LastName}\nAccount username: {CurrentSession.CurrentUser.UserName}\nAccount Type: {CurrentSession.CurrentUser.AccountType}\n";
        }    

        public void UpdgradeToPremium()
        {
            CurrentSession.CurrentUser.AccountType = Models.Enums.AccountTypeEnum.Premium;
            var loggedUser = _databaseDefinitions.People.GetById(CurrentSession.CurrentUser.ID);
            loggedUser.AccountType = Models.Enums.AccountTypeEnum.Premium;
            _databaseDefinitions.People.Update(loggedUser);

            var allLiveTrainings = _databaseDefinitions.LiveTrainings.GetAll();

            int numberOfLiveTrainings = _databaseDefinitions.LiveTrainings.GetAll().Count;
            Random randomTrainingIndex = new Random();
            int index = randomTrainingIndex.Next(0, numberOfLiveTrainings - 1);

            var liveVideoToAssign = allLiveTrainings[index];
            liveVideoToAssign.TrainingParticipants.Add(loggedUser);
            _databaseDefinitions.LiveTrainings.Update(liveVideoToAssign);
        }
    }
}
