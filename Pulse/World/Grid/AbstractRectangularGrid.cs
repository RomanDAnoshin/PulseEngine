using SFML.Graphics;
using SFML.System;

namespace Pulse.World.Grid
{
    public abstract class AbstractRectangularGrid : AbstractGrid
    {
        public int Spacing = 0;
        public int Offset = 0;
        public Vector2i CellCount = Vector2i.Zero;
        public Vector2f CellSize = Vector2f.Zero;

        public AbstractRectangularGrid(Vector2i cellCount, Vector2f cellSize, int spacing = 0, int offset = 0)
        {
            CellCount = cellCount;
            CellSize = cellSize;
            Spacing = spacing;
            Offset = offset;
        }
    }
}
