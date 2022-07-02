using Strategy.Behaviors.Fly;

class Program
{
    public static void Main()
    {
        Duck mallardDuck = new MallardDuck();
        mallardDuck.PerformFly();
        mallardDuck.PerformQuack();
        mallardDuck.Swim();

        Duck modelDuck = new ModelDuck();        
        modelDuck.PerformFly();
        modelDuck.PerformQuack();
        modelDuck.Swim();

        modelDuck.SetFlyBehaviour(new FlyNoFlyBehavior());
        modelDuck.SetQuackBehaviour(new MuteBehavior());

        modelDuck.PerformFly();
        modelDuck.PerformQuack();
        modelDuck.Swim();
    }
}
