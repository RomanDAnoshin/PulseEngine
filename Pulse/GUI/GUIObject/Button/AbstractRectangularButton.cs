using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.GUI.GUIObject.Button
{
    public abstract class AbstractRectangularButton : AbstractButton
    {
        public Rectangle Rectangle = null;
        public virtual Vector2f Position
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

        public AbstractRectangularButton(Vector2f position, Vector2f size)
        {
            Rectangle = new Rectangle(position, size);
        }

        public override bool IsMouseInside()
        {
            return AbstractShape.IsPointInsideRectangle(Rectangle.GlobalVertices, AbstractInitializer.WindowInput.MousePosition);
        }
    }
}
