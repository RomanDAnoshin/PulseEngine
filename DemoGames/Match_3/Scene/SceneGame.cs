using Pulse.Scene;
using Match_3.World;
using Match_3.GUI;
using SFML.Graphics;

namespace Match_3.Scene
{
    class SceneGame : AbstractScene
    {
        public SceneGame()
        {
            Background = new Background(BackgroundType.Turquoise);
            World = new GameWorld();
            GUI = new GameInterface();
        }

        public override void DeleteNestedObjects()
        {
            Background = null;

            World.DeleteNestedObjects();
            World = null;

            GUI.DeleteNestedObjects();
            GUI = null;
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
