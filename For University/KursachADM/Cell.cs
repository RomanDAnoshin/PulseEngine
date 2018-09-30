using Pulse.World.Grid.Cell;
using SFML.System;

namespace KursachADM
{
    enum CellType
    {
        Ground,
        Water,
        Asphalt,
        Rock
    }

    class Cell : RectangularSpriteCell
    {
        public int Weight = 0;
        public CellType Type = CellType.Ground;
        public static Vector2f Size = new Vector2f(60);

        public Cell(Vector2f position, CellType type) : base(position, Size, ResourceLoader.CellSprites[(int)type])
        {
            Type = type;
            switch (type) {
                case CellType.Ground: Weight = 5; return;
                case CellType.Water: Weight = 10; return;
                case CellType.Asphalt: Weight = 1; return;
                case CellType.Rock: Weight = int.MaxValue; return;
            }
        }
    }
}
