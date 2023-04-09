namespace PlayersAndMonsters
{

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = "poli";
            int level = 15;
            Elf elf = new Elf(name, level);
            Console.WriteLine(elf.ToString());
        }

    }
}