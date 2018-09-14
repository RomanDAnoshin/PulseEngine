using SFML.System;

namespace Pulse.System.Shapes
{
    public class Circle : AbstractShape
    {
        public virtual Vector2f Center
        {
            get
            {
                return Position;
            }
            set
            {
                Position = value;
            }
        }
        protected float radius = 0f;
        public virtual float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
                MakeVertices();
            }
        }

        public Circle(Vector2f position, float radius) : base(position)
        {
            this.radius = radius;
        }

        public Circle(Vector2f position, float radius, uint verticesCount) : this(position, radius)
        {
            localVertices = new Vector2f[verticesCount];
            globalVertices = new Vector2f[verticesCount];
            MakeVertices();
        }

        protected override void MakeVertices()
        {
            if (localVertices != null) {
                for (int i = 0; i < localVertices.Length; i++) {
                    localVertices[i] = new Vector2f(
                        MathF.Cos(i * MathF.TwoPi / (localVertices.Length - 1)) * radius,
                        MathF.Sin(i * MathF.TwoPi / (localVertices.Length - 1)) * radius
                        );
                }
                globalVertices = LocalToGlobalVertices(localVertices, position);
            }
        }
    }
}
