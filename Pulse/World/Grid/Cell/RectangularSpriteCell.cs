using SFML.Graphics;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public class RectangularSpriteCell : AbstractRectangularCell
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

        public RectangularSpriteCell(Vector2f position, Vector2f size, Sprite sprite)
            : base(position, size)
        {
            Sprite = sprite;
            Position = position;
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
