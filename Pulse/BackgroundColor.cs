using SFML.Graphics;

namespace Pulse
{
    public class BackgroundColor : AbstractGameObject
    {
        public Color Color = Color.Black;

        public BackgroundColor(Color color)
        {
            Color = color;
        }
        
        public override void Draw(RenderWindow window)
        {
            window.Clear(Color);
        }

        public override void DeleteNestedObjects()
        {

        }

        public override void Update(float dt)
        {

        }
    }
}
