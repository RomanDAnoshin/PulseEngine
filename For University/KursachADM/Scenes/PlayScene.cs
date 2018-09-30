using KursachADM.Interfaces;
using Pulse.Scene;
using SFML.Graphics;

namespace KursachADM.Scenes
{
    class PlayScene : AbstractScene
    {
        public PlayScene()
        {
            Background = new Background();
            GUI = new PlayInterface();
            World = new World(GUI as PlayInterface);
        }

        public override void DeleteNestedObjects()
        {
            Background = null;
            World.DeleteNestedObjects();
            World = null;
        }

        public override void Update(float dt)
        {
            World.Update(dt);
            GUI.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            Background.Draw(window);
            World.Draw(window);
            GUI.Draw(window);
        }
    }
}
