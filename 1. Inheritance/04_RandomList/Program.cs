
namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList random = new RandomList();

            random.Add("asd");
            random.Add("eee");
            random.Add("s");
            random.Add("f");

            Console.WriteLine(random.RandomString());
            Console.WriteLine(random.RandomString());
            Console.WriteLine(random.RandomString());

        }
    }
}