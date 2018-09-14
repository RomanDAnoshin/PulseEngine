using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public abstract class AbstractRoundCell : AbstractCell
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

        public AbstractRoundCell(Vector2f position, float radius)
        {
            Circle.Radius = radius;
            Circle.Position = Position = position;
        }
    }
}
