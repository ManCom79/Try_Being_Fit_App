using Database;
using Services.Interfaces;

namespace Services.Implamentations
{
    public class UIService : IUIService
    {
        private IUserService _userService;

        public UIService()
        {
            _userService = new UserService();
        }

        public void ShowWelcomeMenu()
        {
            Console.WriteLine("***************************** FitApp ****************************");
            Console.WriteLine("********** Welcome to FitApp! Please LogIn or Register **********");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
            
            int menuSelection = CheckUserSelection(1, 2);
            
            switch (menuSelection)
            {
                case 1:
                    {
                        LogExistingUserIn();
                        break;
                    }
                case 2:
                    {
                        RegisterNewUser();
                        break;
                    }
            }
        }

        public void RegisterNewUser()
        {
            string firstName;
            string lastName;
            string userName;
            string password;

            while (true)
            {
                Console.WriteLine("Please enter first name:");
                firstName = Console.ReadLine();

                try
                {
                    if (string.IsNullOrEmpty(firstName) || firstName.Length < 2)
                    {
                        throw new ArgumentException("Name should have at least 2 characters");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Please enter last name:");
                lastName = Console.ReadLine();

                try
                {
                    if (string.IsNullOrEmpty(lastName) || lastName.Length < 2)
                    {
                        throw new ArgumentException("Last name should have at least 2 characters");
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            while (true)
            {
                Console.WriteLine("Please enter username:");
                userName = Console.ReadLine();

                try
                {
                    if (string.IsNullOrEmpty(userName) || userName.Length < 6)
                    {
                        throw new ArgumentException("Username should have at least 6 characters");
                    }

                    var checkIfUserExist = DatabaseDefinition.People.Items.Where(x => x.UserName == userName).FirstOrDefault();

                    if (checkIfUserExist != null)
                    {
                        throw new ArgumentException("Username already exist. Please enter some other value.");
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            while (true)
            {
                Console.WriteLine("Please enter password:");
                password = Console.ReadLine();

                try
                {
                    if (string.IsNullOrEmpty(password) || password.Length < 6)
                    {
                        throw new ArgumentException("Password should not be shorter than 6 characters");
                    }

                    if (!password.Any(char.IsDigit))
                    {
                        throw new ArgumentException("Password should contain at least 1 number");
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Console.WriteLine(firstName);

            _userService.RegisterNewUser(firstName, lastName, userName, password);
            Console.Clear();
        }
        public void LogExistingUserIn()
        {
            while(true) 
            {
                Console.WriteLine("Please enter your username:");
                string enteredUserName = Console.ReadLine();

                Console.WriteLine("Please enter your password:");
                string enteredPassword = Console.ReadLine();

                _userService.LogIn(enteredUserName, enteredPassword);

                if (CurrentSession.CurrentUser == null)
                {
                    ShowWelcomeMenu();
                    break;
                } else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Welcome {CurrentSession.CurrentUser.FirstName}. What will you do today?");
                    Console.ForegroundColor = ConsoleColor.White;

                    ShowMenu();
                    break;
                }
            }
        }

        public void ShowMenu()
        {
            int selection;
            switch (CurrentSession.CurrentUser.AccountType)
            {
                case Models.Enums.AccountTypeEnum.Standard: 
                    Console.WriteLine("1. Video training\n2. Upgrade to premium\n3. Account info\n4. Log Out");
                    selection = CheckUserSelection(1, 4);
                    switch (selection)
                    {
                        case 2:
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("WARNING!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Are you sure that you want to change the account type to \"Premium User\"?\n1. Yes\n2. No");
                                selection = CheckUserSelection(1, 2);
                                switch (selection)
                                {
                                    case 1:
                                        {
                                            _userService.UpdgradeToPremium();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Welcome to the world of Premium users!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            ShowMenu();
                                            break;
                                        }
                                    case 2:
                                        {
                                            break;
                                        }
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(_userService.AccountInfo());
                                Console.ForegroundColor = ConsoleColor.White;
                                ShowMenu();
                                break;
                            }
                        case 4:
                            {
                                _userService.LogOut();
                                break;
                            }
                    }
                    break;
                case Models.Enums.AccountTypeEnum.Premium:
                    Console.WriteLine("1. Video training\n2. Live training\n3. Account info\n4. Log Out");
                    selection = CheckUserSelection(1, 4);
                    break;
                case Models.Enums.AccountTypeEnum.Trainer:
                    Console.WriteLine("1. Train\n2. Reschedule training\n3. Account info\n4. Log Out");
                    selection = CheckUserSelection(1, 4);
                    break;
            }
        }

        public void ShowStandardUserMenu(int selection)
        {

        }

        public void ShowPremiumUserMenu()
        {

        }

        public void ShowTrainerMenu()
        {

        }

        private int CheckUserSelection(int minValue, int maxValue)
        {
            while (true)
            {
                string userSelectionValue = Console.ReadLine();

                if (!int.TryParse(userSelectionValue, out int userSelection))
                {
                    Console.WriteLine($"Please select value between {minValue} and {maxValue}");
                    continue;
                }

                if (userSelection < minValue || userSelection > maxValue)
                {
                    Console.WriteLine($"Please select value between {minValue} and {maxValue}");
                    continue;
                } else
                {
                    return userSelection;
                }
            }
        }
    }
}
