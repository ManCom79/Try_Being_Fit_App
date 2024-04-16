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
            FirstName = firstName; //Validate for length > 2
            LastName = lastName; //Validate for length > 2
            UserName = userName; //Validate for length > 6
            SetPassword(password);
            AccountType = accountType;
            ID = GetUniqueId();
        }

        public void SetPassword(string password)
        {
            if(string.IsNullOrEmpty(password) || password.Length < 6) {
                throw new ArgumentNullException("Password should not be shorter than 6 characters and should contain at least 1 number");
            }
            //Add further validation
            Password = password;
        }
    }
}
