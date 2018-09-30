using KursachADM.Interfaces;
using Pulse.Scene;
using SFML.Graphics;

namespace KursachADM.Scenes
{
    class MenuScene : AbstractScene
    {
        public MenuScene()
        {
            Background = new Background();
            GUI = new MenuInterface();
        }

        public override void DeleteNestedObjects()
        {
            Background = null;

            GUI.DeleteNestedObjects();
            GUI = null;
        }

        public override void Update(float dt)
        {
            GUI.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            Background.Draw(window);
            GUI.Draw(window);
        }
    }
}
