namespace UniversityCompetition
{
    using UniversityCompetition.Core;
    using UniversityCompetition.Core.Contracts;

    public class StartUp
    {
        static void Main()
        {
            // 135/150 

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
