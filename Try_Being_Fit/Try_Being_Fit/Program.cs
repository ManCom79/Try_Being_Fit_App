namespace Try_Being_Fit
{
    using Database;
    using Models;
    using Models.Enums;
    using Services.Implamentations;
    using Services.Interfaces;
    using System.Data;

    public class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                DatabaseDefinition databaseDefinition  = new DatabaseDefinition();
                IUIService uiService = new UIService();
                uiService.ShowWelcomeMenu();
            }
        }
    }
}
