using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public abstract class AbstractPolygonalCell : AbstractCell
    {
        public Polygon Shape = null;
        public override Vector2f Position
        {
            get
            {
                return Shape.Position;
            }
            set
            {
                Shape.Position = value;
            }
        }

        public AbstractPolygonalCell(Vector2f position, Vector2f[] localVertices)
        {
            Shape = new Polygon(position, localVertices);
        }
    }
}
