using Database;
using Services.Interfaces;
using System.Diagnostics;
using System.ComponentModel;
using System;
using Models;
using System.Globalization;
using static System.Collections.Specialized.BitVector32;

namespace Services.Implamentations
{
    public class UIService : IUIService
    {
        private IUserService _userService;
        public DatabaseDefinition _databaseDefinition;

        public UIService()
        {
            _userService = new UserService();
            _databaseDefinition = new DatabaseDefinition();
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

                    var checkIfUserExist = _databaseDefinition.People.GetAll().Where(x => x.UserName == userName).FirstOrDefault();

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
            while (true)
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
                }
                else
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
            //int selection;
            switch (CurrentSession.CurrentUser.AccountType)
            {
                case Models.Enums.AccountTypeEnum.Standard:
                    ShowStandardUserMenu();
                    break;
                case Models.Enums.AccountTypeEnum.Premium:
                    ShowPremiumUserMenu();
                    break;
                case Models.Enums.AccountTypeEnum.Trainer:
                    ShowTrainerMenu();
                    break;
            }
        }

        public void ShowStandardUserMenu()
        {
            int selection;
            Console.WriteLine("1. Video training\n2. Upgrade to premium\n3. Account info\n4. Log Out");
            selection = CheckUserSelection(1, 4);
            switch (selection)
            {
                case 1:
                    {
                        TrainMenu(selection);
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("WARNING!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Are you sure that you want to change the account type to \"Premium User\"?\n1. Yes\n2. No");
                        selection = CheckUserSelection(1, 2);
                        switch (selection)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    _userService.UpdgradeToPremium();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Welcome to the world of Premium users!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    ShowMenu();
                                    break;
                                }
                            case 2:
                                {
                                    ShowMenu();
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        AccountInfo();
                        break;
                    }
                case 4:
                    {
                        _userService.LogOut();
                        break;
                    }
            }
        }

        public void ShowPremiumUserMenu()
        {
            int selection;
            Console.WriteLine("1. Video training\n2. Live training\n3. Account info\n4. Log Out");
            selection = CheckUserSelection(1, 4);
            switch (selection)
            {
                case 1:
                    {
                        TrainMenu(selection);
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        List<LiveTraining> liveTrainings = _databaseDefinition.LiveTrainings.GetAll();
                        LiveTraining availableLiveTraining = liveTrainings.FirstOrDefault(x => x.TrainingParticipants.Any(x => x.ID == CurrentSession.CurrentUser.ID));
                        TimeSpan timeUntilTraining = availableLiveTraining.Schedule - DateTime.Now;
                        int totalDays = timeUntilTraining.Days;
                        int totalHours = timeUntilTraining.Hours;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"The live training {availableLiveTraining.Title} is scheduled to start at {availableLiveTraining.Schedule}.\nThere are {totalDays} days and {totalHours} hours until the training starts.");
                        Console.ForegroundColor = ConsoleColor.White;
                        ShowMenu();
                        break;
                    }
                case 3:
                    {
                        AccountInfo();
                        break;
                    }
                case 4:
                    {
                        _userService.LogOut();
                        break;
                    }
            }
        }

        public void ShowTrainerMenu()
        {
            int selection;
            Console.WriteLine("1. Train\n2. Reschedule training\n3. Account info\n4. Log Out");
            selection = CheckUserSelection(1, 4);
            switch (selection)
            {
                case 1:
                    {
                        TrainMenu(selection);
                        break;
                    }
                case 2:
                    {
                        int counter = 1;
                        var allLiveTrainings = _databaseDefinition.LiveTrainings.GetAll();
                        Console.Clear();
                        Console.WriteLine($"Select a training to change it's schedule (1 - {allLiveTrainings.Count()}):");
                        foreach (var liveTraining in allLiveTrainings)
                        {
                            Console.WriteLine($"{counter}. {liveTraining.Title}, {liveTraining.Schedule}");
                            counter++;
                        }
                        selection = CheckUserSelection(1, allLiveTrainings.Count());
                        var trainingScheduleToChange = allLiveTrainings[selection - 1];
                        trainingScheduleToChange.Schedule = GetNewDate();
                        _databaseDefinition.LiveTrainings.Update(trainingScheduleToChange);
                        Console.WriteLine($"The training time is resheduled for {trainingScheduleToChange.Schedule}");
                        ShowMenu();
                        break;
                    }
                case 3:
                    {
                        AccountInfo();
                        break;
                    }
                case 4:
                    {
                        _userService.LogOut();
                        break;
                    }
            }
        }

        public void TrainMenu(int selection)
        {
            Console.Clear();
            Console.WriteLine("What would you like to train?");
            int counter = 1;
            foreach (var videoTraining in _databaseDefinition.VideoTrainings.GetAll())
            {
                Console.WriteLine($"{counter}. {videoTraining.Title}, Rating Score: {videoTraining.Rating}");
                counter++;
            }
            selection = CheckUserSelection(1, _databaseDefinition.VideoTrainings.GetAll().Count());
            VideoTraining selectedVideoTrening = _databaseDefinition.VideoTrainings.GetAll()[selection - 1];
            string selectedVideoLink = selectedVideoTrening.Link;
            Process.Start("C:\\Program Files\\Internet Explorer\\IExplore.exe", selectedVideoLink);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please rate the video:\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1.Not good\n2.Below expectations\n3.Average\n4.Good\n5.Awesome");
            selection = CheckUserSelection(1, 5);
            selectedVideoTrening.CalculateRating(selection);
            _databaseDefinition.VideoTrainings.Update(selectedVideoTrening);
            Console.Clear();
            Console.WriteLine($"Thanks for the rating. The updated video rating score is {selectedVideoTrening.Rating}\n");
            ShowMenu();
        }

        public void AccountInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(_userService.AccountInfo());
            Console.ForegroundColor = ConsoleColor.White;
            ShowMenu();
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
                }
                else
                {
                    return userSelection;
                }
            }
        }

        private DateTime GetNewDate()
        {
            DateTime newDate = new DateTime();
            while (true)
            {
                try
                {
                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern.ToString();
                    Console.WriteLine($"Please enter date in format: {sysFormat}");
                    string date = Console.ReadLine();

                    if (!DateTime.TryParse(date, out newDate))
                    {
                        throw new Exception("\nPlease follow the suggested time format.\n");
                    }

                    if (newDate < DateTime.Now)
                    {
                        throw new Exception("\nThe date must be in future.\n");
                    }

                    return newDate;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
