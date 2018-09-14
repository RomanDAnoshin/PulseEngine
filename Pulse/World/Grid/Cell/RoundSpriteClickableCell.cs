using SFML.Graphics;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public class RoundSpriteClickableCell : AbstractRoundClickableCell
    {
        public Sprite[] Sprites = null;
        public override Vector2f Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                for (var i = 0; i < Sprites.Length; i++) {
                    Sprites[i].Position = value;
                }
            }
        }

        public RoundSpriteClickableCell(Vector2f position, float radius, Sprite[] sprites)
            : base(position, radius)
        {
            Sprites = sprites;
        }

        public override void DeleteNestedObjects()
        {
            for (var i = 0; i < Sprites.Length; i++) {
                Sprites[i] = null;
            }
            Sprites = null;
            ClearAndNullCollection();
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            UpdateCollection(dt);
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(Sprites[(int)CellState]);
            DrawCollection(window);
        }
    }
}
