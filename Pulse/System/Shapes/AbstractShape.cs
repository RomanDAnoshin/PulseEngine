using SFML.System;

namespace Pulse.System.Shapes
{
    public abstract class AbstractShape
    {

        protected Vector2f[] globalVertices = null;
        public virtual Vector2f[] GlobalVertices
        {
            get
            {
                return globalVertices;
            }
            set
            {
                globalVertices = value;
                localVertices = GlobalToLocalVertices(globalVertices, position);
            }
        }
        protected Vector2f[] localVertices = null;
        public virtual Vector2f[] LocalVertices
        {
            get
            {
                return localVertices;
            }
            set
            {
                localVertices = value;
                globalVertices = LocalToGlobalVertices(localVertices, position);
            }
        }
        protected Vector2f position = Vector2f.Zero;
        public virtual Vector2f Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if (localVertices != null) {
                    globalVertices = LocalToGlobalVertices(localVertices, position);
                }
            }
        }

        public AbstractShape(Vector2f position)
        {
            this.position = position;
        }

        protected abstract void MakeVertices();

        public static Vector2f[] LocalToGlobalVertices(Vector2f[] localVertices, Vector2f offset)
        {
            Vector2f[] globalVertices = new Vector2f[localVertices.Length];
            for (var i = 0; i < localVertices.Length; i++) {
                globalVertices[i] = localVertices[i] + offset;
            }
            return globalVertices;
        }

        public static Vector2f[] GlobalToLocalVertices(Vector2f[] globalVertices, Vector2f offset)
        {
            Vector2f[] localVertices = new Vector2f[globalVertices.Length];
            for (var i = 0; i < globalVertices.Length; i++) {
                localVertices[i] = globalVertices[i] - offset;
            }
            return localVertices;
        }

        public static bool IsPointInsidePolygon(Vector2f[] vertices, Vector2f point)
        {
            bool result = false;
            int j = vertices.Length - 1;
            for (int i = 0; i < vertices.Length; i++) {
                if (
                    (
                    vertices[i].Y < point.Y && vertices[j].Y >= point.Y ||
                    vertices[j].Y < point.Y && vertices[i].Y >= point.Y
                    ) &&
                    (
                    vertices[i].X + (point.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) * (vertices[j].X - vertices[i].X) < point.X
                    )
                ) {
                    result = !result;
                }
                j = i;
            }
            return result;
        }

        public static bool IsPointInsideRectangle(Vector2f[] vertices, Vector2f point)
        {
            return
                vertices[0].X <= point.X &&
                vertices[0].Y <= point.Y &&
                vertices[2].X >= point.X &&
                vertices[2].Y >= point.Y;
        }

        public static bool IsPointInsideCircle(Vector2f circleCenter, float radius, Vector2f point)
        {
            return
                MathF.Abs(point.X - circleCenter.X) <= radius &&
                MathF.Abs(point.Y - circleCenter.Y) <= radius;
        }

        public static bool IsPointInsideTriangle(Vector2f[] vertices, Vector2f point)
        {
            return
                ((vertices[0].X - point.X) * (vertices[1].Y - vertices[0].Y) - (vertices[1].X - vertices[0].X) * (vertices[0].Y - point.Y)) >= 0 &&
                ((vertices[1].X - point.X) * (vertices[2].Y - vertices[1].Y) - (vertices[2].X - vertices[1].X) * (vertices[1].Y - point.Y)) >= 0 &&
                ((vertices[2].X - point.X) * (vertices[0].Y - vertices[2].Y) - (vertices[0].X - vertices[2].X) * (vertices[2].Y - point.Y)) >= 0;
        }
    }
}
