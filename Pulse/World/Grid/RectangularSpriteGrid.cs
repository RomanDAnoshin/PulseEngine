using Pulse.World.Grid.Cell;
using SFML.Graphics;
using SFML.System;

namespace Pulse.World.Grid
{
    public class RectangularSpriteGrid : AbstractRectangularGrid
    {
        public RectangularSpriteGrid(Vector2i cellCount, Vector2f cellSize, Sprite sprite, float spacing = 0, float offset = 0) : base(cellCount, cellSize, spacing, offset)
        {
            Cells = new RectangularSpriteCell[CellCount.Y, CellCount.X];
            for (var i = 0; i < CellCount.Y; i++) {
                for (var j = 0; j < CellCount.X; j++) {
                    var position = new Vector2f(
                        j * (CellSize.X + Spacing) + Offset,
                        i * (CellSize.Y + Spacing) + Offset
                        );
                    Cells[i, j] = new RectangularSpriteCell(position, CellSize, sprite);
                }
            }
        }
    }
}
