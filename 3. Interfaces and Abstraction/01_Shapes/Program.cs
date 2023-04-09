using Shapes.Models;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double radius = double.Parse(Console.ReadLine());

            Circle circle = new Circle(radius);
            Rectangle rectangle = new Rectangle(width, height);
            circle.Draw();
            rectangle.Draw();
        }
    }
}
