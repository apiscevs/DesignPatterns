namespace Strategy.Behaviors.Fly
{
    public class FlyBehavior : IFlyBehavior
    {
        public FlyBehavior()
        {
        }

        public void Fly()
        {
            Console.WriteLine("Just fly, simple...");
        }
    }
}
