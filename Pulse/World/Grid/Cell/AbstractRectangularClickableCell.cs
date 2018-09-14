using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public abstract class AbstractRectangularClickableCell : AbstractClickableCell
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

        public AbstractRectangularClickableCell(Vector2f position, Vector2f size)
        {
            Rectangle = new Rectangle(position, size);
        }

        public override bool IsMouseInside()
        {
            return AbstractShape.IsPointInsideRectangle(Rectangle.GlobalVertices, AbstractInitializer.WindowInput.MousePosition);
        }
    }
}
