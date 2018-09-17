using Pulse;
using SFML.Graphics;
using SFML.System;
using System;

namespace KursachADM
{
    class ResourceLoader : AbstructResourceLoader
    {
        public const string ResourcesDir = "Resources\\";
        public const string TexturesDir = ResourcesDir + "Textures\\";
        private const int spacing = 1;

        public static Texture StartTexture { get; private set; } = null;
        public static Texture FinishTexture { get; private set; } = null;
        public static Texture CellTexture { get; private set; } = null;
        public static Texture ManTexture { get; private set; } = null;

        public static Vector2i StartPositionIndices = Vector2i.Zero;
        public static Vector2i FinishPositionIndices = Vector2i.Zero;
        public static Vector2i GridSize  = Vector2i.Zero;
        public static char[,] TextMap = null;

        private static Sprite[] cellSprites = null;
        public static Sprite[] CellSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesRowCopy(cellSprites);
            }
        }
        private static Sprite startSprite = null;
        public static Sprite StartSprite
        {
            get
            {
                return new Sprite(startSprite);
            }
        }
        private static Sprite finishSprite = null;
        public static Sprite FinishSprite
        {
            get
            {
                return new Sprite(finishSprite);
            }
        }
        private static Sprite[,] manMoveAnimationsSprites = null;
        public static Sprite[,] ManMoveAnimationsSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesArrayCopy(manMoveAnimationsSprites);
            }
        }

        public override void StartLoad()
        {
            var lines = System.IO.File.ReadAllLines(ResourcesDir + "Map.txt");
            GridSize.X = Convert.ToInt32(lines[0]);
            GridSize.Y = Convert.ToInt32(lines[1]);
            TextMap = new char[GridSize.Y, GridSize.X];
            for (var y = 0; y < GridSize.Y; y++) {
                for (var x = 0; x < GridSize.X; x++) {
                    TextMap[y, x] = lines[2 + y][x];
                }
            }
            StartPositionIndices.X = Convert.ToInt32(lines[2 + GridSize.Y]);
            StartPositionIndices.Y = Convert.ToInt32(lines[2 + GridSize.Y + 1]);
            FinishPositionIndices.X = Convert.ToInt32(lines[2 + GridSize.Y + 2]);
            FinishPositionIndices.Y = Convert.ToInt32(lines[2 + GridSize.Y + 3]);

            StartTexture = new Texture(TexturesDir + "Start.png");
            FinishTexture = new Texture(TexturesDir + "Finish.png");
            CellTexture = new Texture(TexturesDir + "Cells.png");
            ManTexture = new Texture(TexturesDir + "Man.png");

            startSprite = new Sprite(StartTexture);
            finishSprite = new Sprite(FinishTexture);
            cellSprites = AbstractInitializer.GetSpritesInTextureRow(CellTexture, 4);
            manMoveAnimationsSprites = AbstractInitializer.GetSpritesInTextureRect(ManTexture, new Vector2i(4, 4));
        }
    }
}
