namespace Strategy.Behaviors.Fly
{
    public class FlyWithWingsBehavior : IFlyBehavior
    {
        public FlyWithWingsBehavior()
        {
        }

        public void Fly()
        {
            Console.WriteLine("Fly with wings");
        }
    }
}
