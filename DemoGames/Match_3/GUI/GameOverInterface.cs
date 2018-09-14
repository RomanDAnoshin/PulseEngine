using SFML.Graphics;
using SFML.System;
using Pulse.GUI.GUIObject.Button;
using Pulse.GUI;
using Match_3.Scene;
using Match_3.World;

namespace Match_3.GUI
{
    class GameOverInterface : AbstractGUI
    {
        private const int sizeText = GameWorld.AmountOfDonuts * 6;
        private AbstractRectangularButton buttonOk = null;
        private Text scoreText = null;
        private Text overText = null;

        public GameOverInterface()
        {
            overText = new Text("Game Over", ResourceLoader.Font, sizeText)
            {
                Position = new Vector2f(Initializer.WindowWidth / 2 - sizeText * 2.8f, Initializer.WindowHeight / 2 - sizeText * 2)
            };
            scoreText = new Text("Your score: " + WorldLogic.Score.ToString(), ResourceLoader.Font, sizeText)
            {
                Position = new Vector2f(overText.Position.X - sizeText * 1.5f, overText.Position.Y + sizeText * 1.5f),
                Color = new Color(254, 216, 1)
            };

            var position = new Vector2f(Initializer.WindowWidth / 2 - 60 / 2, scoreText.Position.Y + 60 / 2 + sizeText * 1.5f);
            var size = new Vector2f(60, 60);
            buttonOk = new RectangularSpriteButton(position, size, ResourceLoader.ButtonOkSprites);
            buttonOk.Clicked += TransitionToScene;
        }

        public override void DeleteNestedObjects()
        {
            buttonOk.Clicked -= TransitionToScene;
            buttonOk.DeleteNestedObjects();
            buttonOk = null;
        }

        public override void Update(float dt)
        {
            buttonOk.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(overText);
            window.Draw(scoreText);
            buttonOk.Draw(window);
        }

        private void TransitionToScene()
        {
            Initializer.SceneHandler.TransitionToScene(new SceneGameMenu());
        }
    }
}
