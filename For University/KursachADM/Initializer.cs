using KursachADM.Scenes;
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
        public static View GameView = null;
        private const float ViewSpeed = 10f;
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
            Window = new RenderWindow(new VideoMode(WindowSize.X, WindowSize.Y), "Dijkstra’s algorithm, by Anoshin Roman");
            Window.SetFramerateLimit(FPSLimit);
            Window.Closed += Window_Closed;
            Window.KeyPressed += Window_KeyPressed;
            
            GameView = new View(new FloatRect(0, 0, WindowSize.X, WindowSize.Y));
        }

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) {
                GameView.Move(Vector2f.Up * ViewSpeed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) {
                GameView.Move(Vector2f.Down * ViewSpeed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) {
                GameView.Move(Vector2f.Left * ViewSpeed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) {
                GameView.Move(Vector2f.Right * ViewSpeed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.PageUp)) {
                GameView.Zoom(1.25f);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.PageDown)) {
                GameView.Zoom(0.25f);
            }
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
            SceneHandler = new SceneHandler(new MenuScene());
        }

        private static void InitializeGameLoop()
        {
            GameLoop = new GameLoop(Window, SceneHandler);
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
