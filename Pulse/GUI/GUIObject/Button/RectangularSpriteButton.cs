using SFML.Graphics;
using SFML.System;

namespace Pulse.GUI.GUIObject.Button
{
    public class RectangularSpriteButton : AbstractRectangularButton
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

        public RectangularSpriteButton(Vector2f position, Vector2f size, Sprite[] sprites)
            : base(position, size)
        {
            Sprites = sprites;
            Position = position;
        }

        public override void DeleteNestedObjects()
        {
            for (var i = 0; i < Sprites.Length; i++) {
                Sprites[i] = null;
            }
            Sprites = null;
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(Sprites[(int)ButtonState]);
        }
    }
}
