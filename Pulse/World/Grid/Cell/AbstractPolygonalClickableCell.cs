using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public abstract class AbstractPolygonalClickableCell : AbstractClickableCell
    {
        public Polygon Polygon = null;
        public override Vector2f Position
        {
            get
            {
                return Polygon.Position;
            }
            set
            {
                Polygon.Position = value;
            }
        }

        public AbstractPolygonalClickableCell(Vector2f position, Vector2f[] localVertices)
        {
            Polygon = new Polygon(position, localVertices);
        }

        public override bool IsMouseInside()
        {
            return AbstractShape.IsPointInsidePolygon(Polygon.GlobalVertices, AbstractInitializer.WindowInput.MousePosition);
        }
    }
}
