using Pulse;
using SFML.Graphics;

namespace Match_3
{
    class ResourceLoader : AbstructResourceLoader
    {
        public const string ResourcesDir = "..\\..\\Resources\\";
        public const string TexturesDir = ResourcesDir + "Textures\\";
        public const string FontsDir = ResourcesDir + "Fonts\\";
        private const int spacing = 1;

        public static Font Font { get; private set; } = null;

        public static Texture DonutsTexture { get; private set; } = null;
        public static Texture CellTexture { get; private set; } = null;
        public static Texture ButtonPlayTexture { get; private set; } = null;
        public static Texture ButtonOkTexture { get; private set; } = null;
        
        public static Color[] Colors { get; private set; } = null;
        private static Sprite[] donutSprites = null;
        public static Sprite[] DonutSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesArrayCopy(donutSprites);
            }
        }
        private static Sprite[] cellSprites = null;
        public static Sprite[] CellSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesArrayCopy(cellSprites);
            }
        }
        private static Sprite[] buttonPlaySprites = null;
        public static Sprite[] ButtonPlaySprites
        {
            get
            {
                return AbstractInitializer.GetSpritesArrayCopy(buttonPlaySprites);
            }
        }
        private static Sprite[] buttonOkSprites = null;
        public static Sprite[] ButtonOkSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesArrayCopy(buttonOkSprites);
            }
        }

        public override void StartLoad()
        {
            Font = new Font(FontsDir + "Amsdamcyr-lat.ttf");
            DonutsTexture = new Texture(TexturesDir + "Donuts.png");
            CellTexture = new Texture(TexturesDir + "Cell.png");
            ButtonPlayTexture = new Texture(TexturesDir + "ButtonPlay.png");
            ButtonOkTexture = new Texture(TexturesDir + "ButtonOk.png");

            donutSprites = AbstractInitializer.GetSpritesInTextureRow(DonutsTexture, 6);
            cellSprites = AbstractInitializer.GetSpritesInTextureRow(CellTexture, 4);
            buttonPlaySprites = AbstractInitializer.GetSpritesInTextureRow(ButtonPlayTexture, 5);
            buttonOkSprites = AbstractInitializer.GetSpritesInTextureRow(ButtonOkTexture, 5);

            Colors = new Color[3];
            Colors[0] = Color.Black;              // None
            Colors[1] = new Color(48, 10, 36);    // DarkPurple
            Colors[2] = new Color(207, 245, 219); // Turquoise
        }
    }
}