using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public abstract class AbstractRoundClickableCell : AbstractClickableCell
    {
        public Circle Circle = null;
        public override Vector2f Position
        {
            get
            {
                return Circle.Position;
            }
            set
            {
                Circle.Position = value;
            }
        }
        public AbstractRoundClickableCell(Vector2f position, float radius)
        {
            Circle.Radius = radius;
            Circle.Position = Position = position;
        }

        public override bool IsMouseInside()
        {
            return AbstractShape.IsPointInsideCircle(Circle.Center, Circle.Radius, AbstractInitializer.WindowInput.MousePosition);
        }
    }
}
