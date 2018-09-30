using Pulse.World.Grid.Cell;
using SFML.Graphics;
using SFML.System;

namespace Pulse.World.Grid
{
    public class RectangularSpriteGrid : AbstractRectangularGrid
    {
        public RectangularSpriteGrid(Vector2i cellCount, Vector2f cellSize, Sprite sprite, float spacing = 0, float offset = 0) : base(cellCount, cellSize, spacing, offset)
        {
            Cells = new RectangularSpriteCell[cellCount.Y, cellCount.X];
            for (var i = 0; i < cellCount.Y; i++) {
                for (var j = 0; j < cellCount.X; j++) {
                    var position = new Vector2f(
                        j * (cellSize.X + spacing) + offset,
                        i * (cellSize.Y + spacing) + offset
                        );
                    Cells[i, j] = new RectangularSpriteCell(position, cellSize, sprite);
                }
            }
        }
    }
}
