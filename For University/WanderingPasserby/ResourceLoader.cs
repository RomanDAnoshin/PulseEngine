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
        public static Texture ButtonPlayTexture { get; private set; } = null;
        public static Texture ButtonOkTexture { get; private set; } = null;
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
        private static Sprite[] buttonPlaySprites = null;
        public static Sprite[] ButtonPlaySprites
        {
            get
            {
                return AbstractInitializer.GetSpritesRowCopy(buttonPlaySprites);
            }
        }
        private static Sprite[] buttonOkSprites = null;
        public static Sprite[] ButtonOkSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesRowCopy(buttonOkSprites);
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
            ButtonPlayTexture = new Texture(TexturesDir + "ButtonPlay.png");
            ButtonOkTexture = new Texture(TexturesDir + "ButtonOk.png");
            PasserbyTexture = new Texture(TexturesDir + "Passerby.png");

            homeSprite = new Sprite(HomeTexture);
            cellSprite = new Sprite(CellTexture);
            buttonPlaySprites = AbstractInitializer.GetSpritesInTextureRow(ButtonPlayTexture, 5);
            buttonOkSprites = AbstractInitializer.GetSpritesInTextureRow(ButtonOkTexture, 5);
            passerbyMoveAnimationsSprites = AbstractInitializer.GetSpritesInTextureRect(PasserbyTexture, new Vector2i(5, 5));
        }
    }
}
