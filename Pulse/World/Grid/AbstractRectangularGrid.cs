using Pulse.World.Grid.Cell;
using SFML.System;
using System.Collections.Generic;

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
        
        public virtual List<AbstractCell> GetNeighbors(Vector2i cellIndices)
        {
            var neighbors = new List<AbstractCell>();
            // Left neighbor
            if (
                cellIndices.X != 0
            ) {
                neighbors.Add(Cells[cellIndices.Y, cellIndices.X - 1]);
            }
            // Up neighbor
            if (
                cellIndices.Y != 0
            ) {
                neighbors.Add(Cells[cellIndices.Y - 1, cellIndices.X]);
            }
            // Right neighbor
            if (
                cellIndices.X != CellCount.X - 1
            ) {
                neighbors.Add(Cells[cellIndices.Y, cellIndices.X + 1]);
            }
            // Down neighbor
            if (
                cellIndices.Y != CellCount.Y - 1
            ) {
                neighbors.Add(Cells[cellIndices.Y + 1, cellIndices.X]);
            }
            return neighbors;
        }
    }
}
