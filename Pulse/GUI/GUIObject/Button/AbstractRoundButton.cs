using Pulse.System.Shapes;
using SFML.System;

namespace Pulse.GUI.GUIObject.Button
{
    public abstract class AbstractRoundButton : AbstractButton
    {
        public Circle Circle = null;
        public virtual Vector2f Position
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
        public AbstractRoundButton(Vector2f position, float radius)
            : base()
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
