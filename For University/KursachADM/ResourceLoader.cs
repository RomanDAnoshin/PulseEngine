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
        public static float VisualisationPauseTime = 1;

        public static Texture StartTexture { get; private set; } = null;
        public static Texture FinishTexture { get; private set; } = null;
        public static Texture CellTexture { get; private set; } = null;
        public static Texture ManTexture { get; private set; } = null;
        public static Texture PlayButtonTexture { get; private set; } = null;
        public static Texture ExitButtonTexture { get; private set; } = null;
        public static Texture DoneButtonTexture { get; private set; } = null;

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
        private static Sprite[] playButtonSprites = null;
        public static Sprite[] PlayButtonSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesRowCopy(playButtonSprites);
            }
        }
        private static Sprite[] exitButtonSprites = null;
        public static Sprite[] ExitButtonSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesRowCopy(exitButtonSprites);
            }
        }
        private static Sprite[] doneButtonSprites = null;
        public static Sprite[] DoneButtonSprites
        {
            get
            {
                return AbstractInitializer.GetSpritesRowCopy(doneButtonSprites);
            }
        }

        public override void StartLoad()
        {
            var lines = System.IO.File.ReadAllLines(ResourcesDir + "InputData.txt");
            GridSize.X = Convert.ToInt32(lines[0]);
            GridSize.Y = Convert.ToInt32(lines[1]);
            TextMap = new char[GridSize.Y, GridSize.X];
            for (var y = 0; y < GridSize.Y; y++) {
                for (var x = 0; x < GridSize.X; x++) {
                    TextMap[y, x] = lines[2 + y][x];
                }
            }
            StartPositionIndices.X = Convert.ToInt32(lines[GridSize.Y + 2]) - 1;
            StartPositionIndices.Y = Convert.ToInt32(lines[GridSize.Y + 3]) - 1;
            FinishPositionIndices.X = Convert.ToInt32(lines[GridSize.Y + 4]) - 1;
            FinishPositionIndices.Y = Convert.ToInt32(lines[GridSize.Y + 5]) - 1;
            VisualisationPauseTime = Convert.ToSingle(lines[GridSize.Y + 6]);

            StartTexture = new Texture(TexturesDir + "Start.png");
            FinishTexture = new Texture(TexturesDir + "Finish.png");
            CellTexture = new Texture(TexturesDir + "Cells.png");
            ManTexture = new Texture(TexturesDir + "Man.png");
            PlayButtonTexture = new Texture(TexturesDir + "ButtonPlay.png");
            ExitButtonTexture = new Texture(TexturesDir + "ButtonExit.png");
            DoneButtonTexture = new Texture(TexturesDir + "ButtonDone.png");

            startSprite = new Sprite(StartTexture);
            finishSprite = new Sprite(FinishTexture);
            cellSprites = AbstractInitializer.GetSpritesInTextureRow(CellTexture, 4);
            playButtonSprites = AbstractInitializer.GetSpritesInTextureRow(PlayButtonTexture, 5);
            exitButtonSprites = AbstractInitializer.GetSpritesInTextureRow(ExitButtonTexture, 5);
            doneButtonSprites = AbstractInitializer.GetSpritesInTextureRow(DoneButtonTexture, 5);
            manMoveAnimationsSprites = AbstractInitializer.GetSpritesInTextureRect(ManTexture, new Vector2i(4, 4));
        }
    }
}
