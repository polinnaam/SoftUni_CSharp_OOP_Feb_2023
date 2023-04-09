
using _02_MultipleInheritance;

namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Weep();


            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();


        }
    }
}