using Pulse.World.Grid;
using SFML.System;
using System;

namespace KursachADM
{
    class WorldGrid : AbstractRectangularGrid
    {
        public WorldGrid(Vector2i cellCount, Vector2f cellSize) : base(cellCount, Cell.Size)
        {
            Cells = new Cell[CellCount.Y, CellCount.X];
            for (var i = 0; i < CellCount.Y; i++) {
                for (var j = 0; j < CellCount.X; j++) {
                    var position = new Vector2f(
                        j * (Cell.Size.X + Spacing) + Offset,
                        i * (Cell.Size.Y + Spacing) + Offset
                        );
                    Cells[i, j] = new Cell(position, (CellType)(Convert.ToInt32(ResourceLoader.TextMap[i, j]) - 48));
                }
            }
        }
    }
}
