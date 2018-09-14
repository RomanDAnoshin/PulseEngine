using SFML.System;

namespace Pulse.System.Shapes
{
    public class Polygon : AbstractShape
    {
        public Polygon(Vector2f position, Vector2f[] localVertices) : base(position)
        {
            LocalVertices = localVertices;
        }

        protected override void MakeVertices()
        {
            globalVertices = LocalToGlobalVertices(localVertices, position);
        }
    }
}
