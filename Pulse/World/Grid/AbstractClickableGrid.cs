using Pulse.World.Grid.Cell;
using SFML.Graphics;

namespace Pulse.World.Grid
{
    public abstract class AbstractClickableGrid : AbstractGameObject
    {
        public AbstractClickableCell[,] Cells = null;

        public override void DeleteNestedObjects()
        {
            if (Cells != null) {
                Cells = null;
            }
        }

        public override void Update(float dt)
        {
            if (Cells != null) {
                for (int y = 0; y < Cells.GetLength(0); y++) {
                    for (int x = 0; x < Cells.GetLength(1); x++) {
                        Cells[y, x].Update(dt);
                    }
                }
            }
        }

        public override void Draw(RenderWindow window)
        {
            if (Cells != null) {
                for (int y = 0; y < Cells.GetLength(0); y++) {
                    for (int x = 0; x < Cells.GetLength(1); x++) {
                        Cells[y, x].Draw(window);
                    }
                }
            }
        }
    }
}
