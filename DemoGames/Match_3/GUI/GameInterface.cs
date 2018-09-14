using SFML.System;
using System;
using SFML.Graphics;
using Pulse.GUI;
using Pulse;
using Match_3.Scene;
using Match_3.World;

namespace Match_3.GUI
{
    class GameInterface : AbstractGUI
    {
        public const uint HeightTimerAndScore = World.GameWorld.AmountOfDonuts * 10;
        private const int sizeText = World.GameWorld.AmountOfDonuts * 4;
        private float timerTime = 60;
        private Text scoreText = null;
        private Text timerText = null;

        public GameInterface()
        {
            scoreText = new Text("Score: ", ResourceLoader.Font, sizeText)
            {
                Position = new Vector2f(Initializer.WindowWidth / 2 + 45, Initializer.WindowHeight - sizeText * 2),
                Color = ResourceLoader.Colors[(int)BackgroundType.DarkPurple]
            };

            timerText = new Text("Timer: ", ResourceLoader.Font, sizeText)
            {
                Position = new Vector2f(15, Initializer.WindowHeight - sizeText * 2),
                Color = ResourceLoader.Colors[(int)BackgroundType.DarkPurple]
            };
        }

        public override void DeleteNestedObjects()
        {
            scoreText = null;
            timerText = null;
        }

        public override void Update(float dt)
        {
            scoreText.DisplayedString = "Score: " + WorldLogic.Score.ToString();
            timerTime -= GameLoop.Dt;
            timerText.DisplayedString = "Timer: " + Convert.ToInt32(timerTime).ToString() + "sec.";
            if (timerTime <= 0)
            {
                TransitionToScene();
            }
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(timerText);
            window.Draw(scoreText);
        }

        private void TransitionToScene()
        {
            Initializer.SceneHandler.TransitionToScene(new SceneGameOver());
        }
    }
}
