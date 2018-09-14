using SFML.Graphics;

namespace Pulse
{
    public class Animation : AbstractGameObject
    {
        public Sprite[] Sprites = null;
        public float Speed = 0.005f;
        public float hz = 0f;
        public int CurrentFrameIndex = 0;

        public Animation(Sprite[] sprites)
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

        public override void Update(float dt)
        {
            hz += dt * Speed;
            if (hz > Sprites.Length - 1) {
                hz -= Sprites.Length - 1;
            }
            CurrentFrameIndex = (int)hz;
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(Sprites[CurrentFrameIndex]);
        }
    }
}
