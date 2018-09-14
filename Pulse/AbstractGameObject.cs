using SFML.Graphics;

namespace Pulse
{
    public abstract class AbstractGameObject
    {
        public abstract void DeleteNestedObjects();
        public abstract void Update(float dt);
        public abstract void Draw(RenderWindow window);
    }
}
