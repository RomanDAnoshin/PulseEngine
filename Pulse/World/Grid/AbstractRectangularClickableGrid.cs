using SFML.System;

namespace Pulse.World.Grid
{
    public abstract class AbstractRectangularClickableGrid : AbstractClickableGrid
    {
        public int Spacing = 0;
        public int Offset = 0;
        public Vector2i CellCount = Vector2i.Zero;
        public Vector2f CellSize = Vector2f.Zero;

        public AbstractRectangularClickableGrid(Vector2i gridSize, Vector2f cellCount, int spacing = 0, int offset = 0)
        {
            CellCount = gridSize;
            CellSize = cellCount;
            Spacing = spacing;
            Offset = offset;
        }
    }
}
