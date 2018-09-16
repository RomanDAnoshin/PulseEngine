using Pulse.World.Grid;
using Pulse.World.Grid.Cell;
using SFML.System;

namespace WanderingPasserby
{
    class WorldGrid : AbstractRectangularGrid
    {
        public WorldGrid(Vector2i cellCount, Vector2f cellSize) : base(cellCount, cellSize, spacing: 0, offset: 0)
        {
            Cells = new RectangularSpriteCell[CellCount.Y, CellCount.X];
            for (var i = 0; i < CellCount.Y; i++) {
                for (var j = 0; j < CellCount.X; j++) {
                    var position = new Vector2f(
                        j * (CellSize.X + Spacing) + Offset,
                        i * (CellSize.Y + Spacing) + Offset
                        );
                    Cells[i, j] = new RectangularSpriteCell(position, CellSize, ResourceLoader.CellSprite);
                }
            }
        }
    }
}
