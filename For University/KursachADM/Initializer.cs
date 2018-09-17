using Pulse;
using Pulse.Scene;
using Pulse.System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace KursachADM
{
    class Initializer : AbstractInitializer
    {
        public static Vector2u WindowSize = new Vector2u(800, 600);
        public static uint FPSLimit = 60;

        public override void Initialization()
        {
            InitializeWindow();
            InitializeInput();
            InitializeResourceLoader();
            InitializeSceneHandler();
            InitializeGameLoop();
        }

        private static void InitializeWindow()
        {
            Window = new RenderWindow(new VideoMode(WindowSize.X, WindowSize.Y), "Wandering passerby, by Anoshin Roman");
            Window.SetFramerateLimit(FPSLimit);
            GameView = new View(new FloatRect(0, 0, WindowSize.X, WindowSize.Y));
            Window.Closed += WindowClosed;
        }

        private static void InitializeInput()
        {
            WindowInput = new WindowInput(Window);
        }

        private static void InitializeResourceLoader()
        {
            ResourceLoader = new ResourceLoader();
            ResourceLoader.StartLoad();
        }
        private static void InitializeSceneHandler()
        {
            SceneHandler = new SceneHandler(new Scene());
        }

        private static void InitializeGameLoop()
        {
            GameLoop = new GameLoop(Window, SceneHandler);
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
