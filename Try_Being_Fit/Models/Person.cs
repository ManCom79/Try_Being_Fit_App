using Models.Enums;

namespace Models
{
    public class Person : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        private string Password {  get; set; }
        public AccountTypeEnum AccountType { get; set; }

        public Person(string firstName, string lastName, string userName, string password, AccountTypeEnum accountType) : base() {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetUserName(userName);
            SetPassword(password);
            AccountType = accountType;
            ID = GetUniqueId();
        }

        public void SetFirstName(string firstName)
        {
            while (true)
            {
                try
                {
                    if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
                    {
                        throw new ArgumentException("Name should have at least 2 characters");
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            while (true)
            {
                try
                {
                    if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
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
            LastName = lastName;
        }
        public void SetUserName(string userName)
        {
            while (true)
            {
                try
                {
                    if (string.IsNullOrEmpty(userName) || userName.Length < 3)
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
            UserName = userName;
        }

        public void SetPassword(string password)
        {
            while (true)
            {
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
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            Password = password;
        }
    }
}
