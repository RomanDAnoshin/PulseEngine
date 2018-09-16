using Pulse.World;
using SFML.Graphics;
using SFML.System;

namespace WanderingPasserby
{
    class Home : AbstractWorldObject
    {
        public override Vector2f Position
        {
            get
            {
                return Sprite.Position;
            }
            set
            {
                Sprite.Position = value;
            }
        }
        public Sprite Sprite = null;

        public Home(Vector2f position)
        {
            Sprite = new Sprite(ResourceLoader.HomeSprite);
            Position = position;
        }

        public override void DeleteNestedObjects()
        {
            Sprite = null;
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(Sprite);
        }

        public override void Update(float dt)
        {
            
        }
    }
}
