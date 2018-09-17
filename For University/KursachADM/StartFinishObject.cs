using Pulse.World;
using SFML.Graphics;
using SFML.System;

namespace KursachADM
{
    class StartFinishObject : AbstractWorldObject
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

        public StartFinishObject(Vector2f position, bool startOrFinish)
        {
            Sprite = new Sprite(
                startOrFinish? 
                ResourceLoader.StartSprite : 
                ResourceLoader.FinishSprite
                );
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
