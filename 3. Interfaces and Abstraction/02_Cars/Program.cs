using Cars.Models;

namespace Cars
{
    public class StartUp
    {
        public static void Main()
        {
            Seat seat = new Seat("Leon", "Black");
            Tesla tesla = new Tesla("Model 3", "Red", 5);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(tesla.ToString());
        }
    }
}