using Pulse.GUI;
using Pulse.World;
using SFML.Graphics;

namespace Pulse.Scene
{
    public abstract class AbstractScene : AbstractGameObject
    {
        public BackgroundColor Background = null;
        public AbstractGUI GUI = null;
        public AbstractWorld World = null;

        public override void DeleteNestedObjects()
        {
            Background.DeleteNestedObjects();
            Background = null;

            GUI.DeleteNestedObjects();
            GUI = null;

            World.DeleteNestedObjects();
            World = null;
        }

        public override void Update(float dt)
        {
            Background.Update(dt);
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
