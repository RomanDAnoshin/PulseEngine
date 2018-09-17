using SFML.System;

namespace Pulse.World.Grid
{
    public abstract class AbstractRectangularGrid : AbstractGrid
    {
        public float Spacing = 0;
        public float Offset = 0;
        public Vector2i CellCount = Vector2i.Zero;
        public Vector2f CellSize = Vector2f.Zero;

        public AbstractRectangularGrid(Vector2i cellCount, Vector2f cellSize, float spacing = 0, float offset = 0)
        {
            CellCount = cellCount;
            CellSize = cellSize;
            Spacing = spacing;
            Offset = offset;
        }
    }
}
