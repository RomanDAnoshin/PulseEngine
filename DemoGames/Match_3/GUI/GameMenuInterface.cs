using SFML.System;
using Pulse.GUI.GUIObject.Button;
using Pulse.GUI;
using Match_3.Scene;
using SFML.Graphics;

namespace Match_3.GUI
{
    class GameMenuInterface : AbstractGUI
    {
        private AbstractRectangularButton menuButton = null;

        public GameMenuInterface()
        {
            var position = new Vector2f(Initializer.WindowWidth / 2 - 120 / 2, Initializer.WindowHeight / 2 - 60 / 2);
            var size = new Vector2f(120, 60);
            menuButton = new RectangularSpriteButton(position, size, ResourceLoader.ButtonPlaySprites);
            menuButton.Clicked += TransitionToScene;
        }

        public override void DeleteNestedObjects()
        {
            menuButton.Clicked -= TransitionToScene;
            menuButton.DeleteNestedObjects();
            menuButton = null;
        }

        public override void Update(float dt)
        {
            menuButton.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            menuButton.Draw(window);
        }

        private void TransitionToScene()
        {
            Initializer.SceneHandler.TransitionToScene(new SceneGame());
        }
    }
}
