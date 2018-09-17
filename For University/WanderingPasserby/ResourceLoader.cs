using Pulse;
using SFML.Graphics;
using SFML.System;

namespace WanderingPasserby
{
    class ResourceLoader : AbstructResourceLoader
    {
        public const string ResourcesDir = "Resources\\";
        public const string TexturesDir = ResourcesDir + "Textures\\";
        private const int spacing = 1;
        
        public static Texture HomeTexture { get; private set; } = null;
        public static Texture CellTexture { get; private set; } = null;
        public static Texture PasserbyTexture { get; private set; } = null;

        private static Sprite cellSprite = null;
        public static Sprite CellSprite
        {
            get
            {
                return new Sprite(cellSprite);
            }
        }
        private static Sprite homeSprite = null;
        public static Sprite HomeSprite
        {
            get
            {
                return new Sprite(homeSprite);
            }
        }
        private static Sprite[,] passerbyMoveAnimationsSprites = null;
        public static Sprite[,] PasserbyMoveAnimationsSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesArrayCopy(passerbyMoveAnimationsSprites);
            }
        }

        public override void StartLoad()
        {
            HomeTexture = new Texture(TexturesDir + "Home.png");
            CellTexture = new Texture(TexturesDir + "Cell.png");
            PasserbyTexture = new Texture(TexturesDir + "Passerby.png");

            homeSprite = new Sprite(HomeTexture);
            cellSprite = new Sprite(CellTexture);
            passerbyMoveAnimationsSprites = AbstractInitializer.GetSpritesInTextureRect(PasserbyTexture, new Vector2i(4, 4));
        }
    }
}
