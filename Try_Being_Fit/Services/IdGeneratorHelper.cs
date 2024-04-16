using Database;

namespace Services
{
    public class IdGeneratorHelper
    {
        public static int AssignUniqueId()
        {
            while (true)
            {
                Random number = new Random();
                int uniqueId = number.Next(1, 2);

                if (!DatabaseDefinition.People.Items.Any(x => x.ID == uniqueId))
                {
                    return uniqueId;
                }
                else
                {
                    Console.WriteLine("Trying again!");
                }
            }
        }
    }
}
