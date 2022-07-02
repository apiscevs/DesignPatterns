

public class MuteBehavior : IQuackBehavior
{
    public MuteBehavior()
    {
    }

    public void Quack()
    {
        Console.WriteLine("<<Silence>>!");
    }
}
