using KursachADM.Scenes;
using Pulse.GUI;
using Pulse.GUI.GUIObject.Button;
using SFML.Graphics;
using SFML.System;

namespace KursachADM.Interfaces
{
    class PlayInterface : AbstractGUI
    {
        public RectangularSpriteButton DoneButton = null;

        public PlayInterface()
        {
            
        }

        public void CreateDoneButton()
        {
            var size = new Vector2f(60, 60);
            var position = new Vector2f(
                Initializer.Window.GetView().Center.X - size.X / 2,
                Initializer.Window.GetView().Center.Y - size.Y / 2
                );
            DoneButton = new RectangularSpriteButton(position, size, ResourceLoader.DoneButtonSprites);
            DoneButton.Clicked += DoneButton_Clicked;
        }

        private void DoneButton_Clicked()
        {
            Initializer.SceneHandler.TransitionToScene(new MenuScene());
        }

        public override void DeleteNestedObjects()
        {
            if (DoneButton != null) {
                DoneButton.DeleteNestedObjects();
                DoneButton = null;
            }
        }

        public override void Draw(RenderWindow window)
        {
            DoneButton?.Draw(window);
        }

        public override void Update(float dt)
        {
            DoneButton?.Update(dt);
        }
    }
}
