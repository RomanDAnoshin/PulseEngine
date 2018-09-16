namespace WanderingPasserby
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new Initializer();
            initializer.Initialization();

            Initializer.GameLoop.Update();
        }
    }
}
