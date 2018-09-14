using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public abstract class AbstractRectangularCell : AbstractCell
    {
        public Rectangle Rectangle = null;
        public override Vector2f Position
        {
            get
            {
                return Rectangle.Position;
            }
            set
            {
                Rectangle.Position = value;
            }
        }

        public AbstractRectangularCell(Vector2f position, Vector2f size)
        {
            Rectangle = new Rectangle(position, size);
        }
    }
}
