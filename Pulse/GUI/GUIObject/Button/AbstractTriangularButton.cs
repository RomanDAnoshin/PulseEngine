﻿using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.GUI.GUIObject.Button
{
    public abstract class AbstractTriangularButton : AbstractButton
    {
        public Polygon Polygon = null;
        public virtual Vector2f Position
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

        public AbstractTriangularButton(Vector2f position, Vector2f[] localVertices)
        {
            Polygon = new Polygon(position, localVertices);
        }

        public override bool IsMouseInside()
        {
            return AbstractShape.IsPointInsideTriangle(Polygon.GlobalVertices, AbstractInitializer.WindowInput.MousePosition);
        }
    }
}
