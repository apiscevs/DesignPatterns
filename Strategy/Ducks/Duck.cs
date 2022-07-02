public abstract class Duck
{
    protected IFlyBehavior flyBehavior;
    protected IQuackBehavior quackBehavior;
      
    public void PerformFly()
    {
        flyBehavior.Fly();
    }

    public void PerformQuack()
    {
        quackBehavior.Quack();
    }

    public void SetFlyBehaviour(IFlyBehavior flyBehavior)
    {
        this.flyBehavior = flyBehavior;
    }

    public void SetQuackBehaviour(IQuackBehavior quackBehavior)
    {
        this.quackBehavior = quackBehavior;
    }

    public void Swim()
    {
        Console.WriteLine("All ducks can swim");
    }
}
