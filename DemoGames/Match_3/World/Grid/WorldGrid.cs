using Pulse.World.Grid;
using SFML.System;

namespace Match_3.World.Grid
{
    class WorldGrid : AbstractRectangularClickableGrid
    {
        public WorldGrid(Vector2i cellCount, Vector2f cellSize) : base(cellCount, cellSize, spacing: 5, offset: 5)
        {
            Cells = new Cell[CellCount.Y, CellCount.X];
            for (var i = 0; i < CellCount.Y; i++) {
                for (var j = 0; j < CellCount.X; j++) {
                    var position = new Vector2f(
                        j * (CellSize.X + Spacing) + Offset,
                        i * (CellSize.Y + Spacing) + Offset
                        );
                    Cells[i, j] = new Cell(position, CellSize, ResourceLoader.CellSprites);
                }
            }
        }
    }
}
