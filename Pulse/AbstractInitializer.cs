using SFML.Graphics;
using Pulse.Scene;
using Pulse.System;
using SFML.System;

namespace Pulse
{
    public abstract class AbstractInitializer
    {
        public static RenderWindow Window = null;
        public static SceneHandler SceneHandler = null;
        public static GameLoop GameLoop = null;
        public static AbstructResourceLoader ResourceLoader = null;
        public static WindowInput WindowInput = null;

        public abstract void Initialization();

        public static Vector2i GetSpriteSizeInTextureRow(Texture texture, int spritesCount, int spacing = 1)
        {
            return new Vector2i(
                ((int)texture.Size.X - (spritesCount - 1) * spacing) / spritesCount,
                (int)texture.Size.Y
                );
        }

        public static Sprite[] GetSpritesInTextureRow(Texture texture, int spritesCount, int spacing = 1)
        {
            Sprite[] result = new Sprite[spritesCount];
            var spriteSize = GetSpriteSizeInTextureRow(texture, spritesCount);
            for (var i = 0; i < spritesCount; i++) {
                result[i] = new Sprite(texture, new IntRect(i * spriteSize.X + i * spacing, 0, spriteSize.X, spriteSize.Y));
                var a = result[i];
            }
            return result;
        }

        public static Sprite[] GetSpritesArrayCopy(Sprite[] sprites)
        {
            var result = new Sprite[sprites.Length];
            for (var i = 0; i < sprites.Length; i++) {
                result[i] = new Sprite(sprites[i]);
            }
            return result;
        }
    }
}
