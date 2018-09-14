using SFML.System;
using SFML.Window;

namespace Pulse.System
{
    public class WindowInput
    {
        private Window Window = null;
        private Vector2f mousePosition = Vector2f.Zero;
        public Vector2f MousePosition
        {
            get
            {
                return mousePosition;
            }
            set
            {
                Mouse.SetPosition(new Vector2i((int)value.X, (int)value.Y), Window);
                UpdateMousePosition();
            }
        }

        public static bool IsMouseLeftButtonPressed = false;
        public static bool IsMouseRightButtonPressed = false;
        public static bool IsMouseMiddleButtonPressed = false;
        public static bool WasMouseLeftButtonReleased = false;
        public static bool WasMouseRightButtonReleased = false;
        public static bool WasMouseMiddleButtonReleased = false;

        public WindowInput(Window window)
        {
            Window = window;
            Window.MouseMoved += UpdateMousePosition;
            Window.MouseButtonPressed += UpdateIsMouseLeftButtonPressed;
            Window.MouseButtonPressed += UpdateIsMouseRightButtonPressed;
            Window.MouseButtonPressed += UpdateIsMouseMiddleButtonPressed;
            Window.MouseButtonReleased += UpdateWasMouseLeftButtonReleased;
            Window.MouseButtonReleased += UpdateWasMouseRightButtonReleased;
            Window.MouseButtonReleased += UpdateWasMouseMiddleButtonReleased;
        }

        public static void Update()
        {
            WasMouseLeftButtonReleased = false;
            WasMouseRightButtonReleased = false;
            WasMouseMiddleButtonReleased = false;
        }

        private void UpdateMousePosition()
        {
            mousePosition = new Vector2f(
                    Mouse.GetPosition(AbstractInitializer.Window).X,
                    Mouse.GetPosition(AbstractInitializer.Window).Y
                    );
        }

        private void UpdateMousePosition(object sender, MouseMoveEventArgs e)
        {
            mousePosition = new Vector2f(e.X, e.Y);
        }

        private void UpdateIsMouseLeftButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left) {
                IsMouseLeftButtonPressed = true;
            }
        }

        private void UpdateIsMouseRightButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Right) {
                IsMouseRightButtonPressed = true;
            }
        }

        private void UpdateIsMouseMiddleButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Middle) {
                IsMouseMiddleButtonPressed = true;
            }
        }

        private void UpdateWasMouseLeftButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left) {
                WasMouseLeftButtonReleased = true;
                IsMouseLeftButtonPressed = false;
            }
        }

        private void UpdateWasMouseRightButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Right) {
                WasMouseRightButtonReleased = true;
                IsMouseRightButtonPressed = false;
            }
        }

        private void UpdateWasMouseMiddleButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Middle) {
                WasMouseMiddleButtonReleased = true;
                IsMouseMiddleButtonPressed = false;
            }
        }
    }
}
