using SFML.Graphics;
using Pulse.Scene;
using Pulse.System;
using SFML.System;

namespace Pulse
{
    public abstract class AbstractInitializer
    {
        public static RenderWindow Window = null;
        public static View GameView = null;
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

        public static Vector2i GetSpriteSizeInTextureRect(Texture texture, Vector2i spritesCount, int spacing = 1)
        {
            return new Vector2i(
                ((int)texture.Size.X - (spritesCount.X - 1) * spacing) / spritesCount.X,
                ((int)texture.Size.Y - (spritesCount.Y - 1) * spacing) / spritesCount.Y
                );
        }

        public static Sprite[] GetSpritesInTextureRow(Texture texture, int spritesCount, int spacing = 1)
        {
            Sprite[] result = new Sprite[spritesCount];
            var spriteSize = GetSpriteSizeInTextureRow(texture, spritesCount);
            for (var i = 0; i < spritesCount; i++) {
                result[i] = new Sprite(texture, new IntRect(i * spriteSize.X + i * spacing, 0, spriteSize.X, spriteSize.Y));
            }
            return result;
        }

        public static Sprite[,] GetSpritesInTextureRect(Texture texture, Vector2i spritesCount, int spacing = 1)
        {
            Sprite[,] result = new Sprite[spritesCount.Y, spritesCount.Y];
            var spriteSize = GetSpriteSizeInTextureRect(texture, spritesCount);
            for(var y = 0; y< spritesCount.Y; y++) {
                for(var x = 0; x < spritesCount.X; x++) {
                    result[y, x] = new Sprite(texture, new IntRect(x * spriteSize.X + x * spacing, y * spriteSize.Y + y * spacing, spriteSize.X, spriteSize.Y));
                }
            }
            return result;
        }

        public static Sprite[] GetSpritesRowCopy(Sprite[] sprites)
        {
            var result = new Sprite[sprites.Length];
            for (var i = 0; i < sprites.Length; i++) {
                result[i] = new Sprite(sprites[i]);
            }
            return result;
        }

        public static Sprite[,] GetSpritesArrayCopy(Sprite[,] sprites)
        {
            var result = new Sprite[sprites.GetLength(0), sprites.GetLength(1)];
            for (var j = 0; j < sprites.GetLength(1); j++) {
                for (var i = 0; i < sprites.GetLength(0); i++) {
                    result[j, i] = new Sprite(sprites[j, i]);
                }
            }
            return result;
        }
    }
}
