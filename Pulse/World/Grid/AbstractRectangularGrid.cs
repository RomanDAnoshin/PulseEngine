using SFML.Graphics;
using SFML.System;

namespace Pulse.World.Grid
{
    public abstract class AbstractRectangularGrid : AbstractGrid
    {
        public int Spacing = 0;
        public int Offset = 0;
        public Vector2i Size = Vector2i.Zero;
        public Vector2f CellSize = Vector2f.Zero;

        public AbstractRectangularGrid(Vector2i gridSize, Vector2f cellSize)
        {
            Size = gridSize;
            CellSize = cellSize;
            // TODO: RectangularSpriteCell
            //Cells = new RectangularSpriteCell[Size.Y, Size.X];
            //MakeCells();
        }
    }
}
