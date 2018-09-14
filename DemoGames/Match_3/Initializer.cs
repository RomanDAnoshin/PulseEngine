using Match_3.Scene;
using Match_3.World.WorldObject;
using Pulse;
using Pulse.Scene;
using Pulse.System;
using SFML.Graphics;
using SFML.Window;
using System;

namespace Match_3
{
    class Initializer : AbstractInitializer
    {
        public static uint WindowWidth = ((uint)Donut.Size.X + 5) * World.GameWorld.AmountOfDonuts + 5;
        public static uint WindowHeight = WindowWidth + GUI.GameInterface.HeightTimerAndScore;
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
            Window = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), "Match 3, by Anoshin Roman");
            Window.SetFramerateLimit(FPSLimit);
            
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
            SceneHandler = new SceneHandler(new SceneGameMenu());
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
