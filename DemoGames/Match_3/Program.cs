namespace Match_3
{
    static class Program
    {
        static void Main()
        {
            var initializer = new Initializer();
            initializer.Initialization();

            Initializer.GameLoop.Update();
        }
    }
}
