using SFML.Graphics;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public class RoundSpriteCell : AbstractRoundCell
    {
        public Sprite Sprite = null;
        public override Vector2f Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                Sprite.Position = value;
            }
        }

        public RoundSpriteCell(Vector2f position, float radius, Sprite sprite)
            : base(position, radius)
        {
            Sprite = sprite;
        }

        public override void DeleteNestedObjects()
        {
            Sprite = null;
            ClearAndNullCollection();
        }

        public override void Update(float dt)
        {
            UpdateCollection(dt);
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(Sprite);
            DrawCollection(window);
        }
    }
}
