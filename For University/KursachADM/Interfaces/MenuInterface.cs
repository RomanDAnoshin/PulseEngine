using Pulse.GUI;
using SFML.Graphics;
using Pulse.GUI.GUIObject.Button;
using SFML.System;
using KursachADM.Scenes;

namespace KursachADM.Interfaces
{
    class MenuInterface : AbstractGUI
    {
        public RectangularSpriteButton PlayButton = null;
        public RectangularSpriteButton ExitButton = null;

        public MenuInterface()
        {
            var size = new Vector2f(120, 60);
            var position = new Vector2f(size.X, Initializer.WindowSize.Y / 4);
            PlayButton = new RectangularSpriteButton(position, size, ResourceLoader.PlayButtonSprites);
            PlayButton.Clicked += PlayButton_Clicked;

            position.Y += size.Y * 1.5f;
            ExitButton = new RectangularSpriteButton(position, size, ResourceLoader.ExitButtonSprites);
            ExitButton.Clicked += ExitButton_Clicked;
        }

        private void ExitButton_Clicked()
        {
            Initializer.Window.Close();
        }

        private void PlayButton_Clicked()
        {
            Initializer.SceneHandler.TransitionToScene(new PlayScene());
        }

        public override void DeleteNestedObjects()
        {
            PlayButton.DeleteNestedObjects();
            PlayButton = null;
            ExitButton.DeleteNestedObjects();
            ExitButton = null;
        }

        public override void Draw(RenderWindow window)
        {
            PlayButton.Draw(window);
            ExitButton.Draw(window);
        }

        public override void Update(float dt)
        {
            PlayButton?.Update(dt);
            ExitButton?.Update(dt);
        }
    }
}