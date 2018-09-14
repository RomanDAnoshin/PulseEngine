using SFML.System;

namespace Pulse.System.Shapes
{
    public class Rectangle : AbstractShape
    {
        protected Vector2f size = Vector2f.Zero;
        public Vector2f Size
        {
            get
            {
                return size;
            }
            set
            {
                if (size != value) {
                    size = value;
                    MakeVertices();
                }
            }
        }
        public float Width
        {
            get
            {
                return size.X;
            }
            set
            {
                if (size.X != value) {
                    size.X = value;
                    MakeVertices();
                }
            }
        }
        public float Height
        {
            get
            {
                return size.Y;
            }
            set
            {
                if (size.Y != value) {
                    size.Y = value;
                    MakeVertices();
                }
            }
        }
        public Vector2f LeftTop
        {
            get
            {
                return globalVertices[0];
            }
            set
            {
                if (globalVertices[0] != value) {
                    position = globalVertices[0] = value;
                    localVertices[0] = globalVertices[0] - position;
                    UpdateSize();
                }
            }
        }
        public Vector2f RightTop
        {
            get
            {
                return globalVertices[1];
            }
            set
            {
                if (globalVertices[1] != value) {
                    globalVertices[1] = value;
                    if (globalVertices[1].X != globalVertices[2].X) {
                        globalVertices[2].X = globalVertices[1].X;
                        localVertices[2].X = globalVertices[1].X - position.X;
                    }
                    if (globalVertices[1].Y != globalVertices[0].Y) {
                        position.Y = globalVertices[0].Y = globalVertices[2].Y;
                        localVertices[0].Y = globalVertices[2].Y - position.Y;
                    }
                    UpdateSize();
                }
            }
        }
        public Vector2f RightBottom
        {
            get
            {
                return globalVertices[2];
            }
            set
            {
                if (globalVertices[2] != value) {
                    globalVertices[2] = value;
                    localVertices[2] = globalVertices[2] - position;
                    UpdateSize();
                }
            }
        }
        public Vector2f LeftBottom
        {
            get
            {
                return globalVertices[3];
            }
            set
            {
                if (globalVertices[3] != value) {
                    globalVertices[3] = value;
                    if (globalVertices[3].X != globalVertices[0].X) {
                        position.X = globalVertices[0].X = globalVertices[3].X;
                        localVertices[0].X = globalVertices[3].X - position.X;
                    }
                    if (globalVertices[3].Y != globalVertices[2].Y) {
                        globalVertices[2].Y = globalVertices[3].Y;
                        localVertices[2].Y = globalVertices[3].Y - position.Y;
                    }
                    UpdateSize();
                }
            }
        }

        public Rectangle(Vector2f position, Vector2f size) : base(position)
        {
            this.size = size;
            MakeVertices();
        }

        protected override void MakeVertices()
        {
            localVertices = new Vector2f[4];
            localVertices[0] = Vector2f.Zero;
            localVertices[1] = new Vector2f(Width, 0f);
            localVertices[2] = size;
            localVertices[3] = new Vector2f(0f, Height);

            globalVertices = LocalToGlobalVertices(localVertices, position);
        }

        private void UpdateSize()
        {
            size = RightBottom - LeftTop;
        }
    }
}
