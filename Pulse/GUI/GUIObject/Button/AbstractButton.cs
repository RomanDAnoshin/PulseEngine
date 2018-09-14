using Pulse.System;

namespace Pulse.GUI.GUIObject.Button
{
    public enum ButtonState
    {
        Normal,
        Hovered,
        Pressed,
        Released,
        Disabled
    }

    public abstract class AbstractButton : AbstractGUIObject
    {
        public delegate void ClickDelegate();
        public event ClickDelegate Clicked = delegate { };

        public ButtonState ButtonState = ButtonState.Normal;

        public override void Update(float dt)
        {
            if (ButtonState != ButtonState.Disabled) {
                if (IsMouseInside()) {
                    if (WindowInput.IsMouseLeftButtonPressed) {
                        ButtonState = ButtonState.Pressed;
                    } else if (WindowInput.WasMouseLeftButtonReleased) {
                        ButtonState = ButtonState.Released;
                        Clicked();
                    } else {
                        ButtonState = ButtonState.Hovered;
                    }
                } else {
                    ButtonState = ButtonState.Normal;
                }
            }
        }

        public abstract bool IsMouseInside();
    }
}
