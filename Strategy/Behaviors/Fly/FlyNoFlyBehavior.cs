namespace Strategy.Behaviors.Fly
{
    public class FlyNoFlyBehavior : IFlyBehavior
    {
        public FlyNoFlyBehavior()
        {
        }

        public void Fly()
        {
            Console.WriteLine("I can't fly");
        }
    }
}
