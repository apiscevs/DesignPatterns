using Strategy.Behaviors.Fly;

public class ModelDuck : Duck
{
    public ModelDuck()
    {
        flyBehavior = new FlyBehavior();
        quackBehavior = new MuteBehavior();
    }

    public void Display()
    {
        Console.WriteLine("I'm Model duck");
    }
}