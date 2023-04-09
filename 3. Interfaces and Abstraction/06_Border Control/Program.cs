
using BorderControl;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<string> fakeIds = new List<string>();
        //List<Citizens> citizens = new List<Citizens>();
        //List<Robots> robots = new List<Robots>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = inputInfo[0];

            if (inputInfo.Length == 2)
            {
                string id = inputInfo[1];
                Robots robot = new Robots(name, id);
              //  robots.Add(robot);

                fakeIds.Add(robot.Id);

                //robot
            }
            else if (inputInfo.Length == 3)
            {
                int age = int.Parse(inputInfo[1]);
                string id = inputInfo[2];
                Citizens citizen = new Citizens(name, age, id);
               // citizens.Add(citizen);

                fakeIds.Add(citizen.Id);
                //citizen
            }
            input = Console.ReadLine();
        }
        string digitsOfFakeId = Console.ReadLine();
        foreach (var id in fakeIds)
        {
            bool isFake = true;

            for (int i = 0; i < digitsOfFakeId.Length; i ++)
            {
                if (id[id.Length - i - 1] != digitsOfFakeId[digitsOfFakeId.Length - i - 1])
                {
                    isFake = false;
                    break;
                }
            }
            if (isFake)
            {
                Console.WriteLine(id);
            }
        }
    }
}