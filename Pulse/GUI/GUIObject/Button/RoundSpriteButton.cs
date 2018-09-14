using SFML.Graphics;
using SFML.System;

namespace Pulse.GUI.GUIObject.Button
{
    public class RoundSpriteButton : AbstractRoundButton
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

        public RoundSpriteButton(Vector2f position, float radius, Sprite[] sprites)
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
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(Sprites[(int)ButtonState]);
        }
    }
}
