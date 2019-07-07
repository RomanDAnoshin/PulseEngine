using Pulse;
using Pulse.Scene;
using SFML.Graphics;

namespace WanderingPasserby
{
    class Scene : AbstractScene
    {
        public Scene()
        {
            Background = new BackgroundColor(Color.DarkGray);
            World = new World();
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
        }

        public override void Draw(RenderWindow window)
        {
            Background.Draw(window);
            World.Draw(window);
        }
    }
}
