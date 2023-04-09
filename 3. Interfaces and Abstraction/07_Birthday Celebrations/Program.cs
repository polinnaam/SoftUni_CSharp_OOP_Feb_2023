namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> dates = new List<string>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = inputInfo[0];
                string name = inputInfo[1];

                if (type == "Citizen")
                {
                    //Citizen Peter 22 9010101122 10 / 10 / 1990
                    int age = int.Parse(inputInfo[2]);
                    string id = inputInfo[3];
                    string birthDate = inputInfo[4];
                    Citizens citizens = new Citizens(name, age, id, birthDate);

                    dates.Add(citizens.BirthDate);
                }
                else if (type == "Pet")
                {
                    //Pet Sharo 13/11/2005
                    string birthDate = inputInfo[2];
                    Pet pet = new Pet(name, birthDate);

                    dates.Add(pet.BirthDate);
                }
                else if (type == "Robot")
                {
                    //Robot MK-13 558833251
                    string id = inputInfo[2];
                    Robots robots = new Robots(name, id);
                }

                input = Console.ReadLine();
            }
            int year = int.Parse(Console.ReadLine());

            foreach (var date in dates)
            {
                int[] currDate = date
                    .Split("/")
                    .Select(int.Parse)
                    .ToArray();

                if (currDate[2] == year)
                {
                    Console.WriteLine(date);
                }
            }
        }
    }
}