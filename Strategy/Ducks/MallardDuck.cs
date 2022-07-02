using Strategy.Behaviors.Fly;

public class MallardDuck : Duck
{
    public MallardDuck()
    {
        flyBehavior = new FlyWithWingsBehavior();
        quackBehavior = new QuackBehavior();
    }

    public void Display()
    {
        Console.WriteLine("I'm a real Mallard duck");
    }
}
