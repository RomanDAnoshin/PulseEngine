using Pulse.Scene;
using SFML.Graphics;
using SFML.System;
using System;

namespace Pulse
{
    public class GameLoop
    {
        private RenderWindow window = null;
        private SceneHandler sceneHandler = null;
        private Clock clock = null;
        public static float Dt = 0;
        // Control the speed of the game
        //const float denominator = 1; 

        public GameLoop(RenderWindow window, SceneHandler sceneHandler)
        {
            clock = new Clock();
            this.window = window;
            this.sceneHandler = sceneHandler;
            window.GainedFocus += Window_GainedFocus;
        }

        private void Window_GainedFocus(object sender, EventArgs e)
        {
            clock.Restart();
        }

        public void Update()
        {
            while (window.IsOpen)
            {
                if (window.HasFocus()) {
                    window.DispatchEvents();
                    UpdateDt();
                    sceneHandler.Update(Dt);
                    sceneHandler.Draw(window);
                    window.Display();
                } else {
                    window.WaitAndDispatchEvents();
                }
            }
        }

        private void UpdateDt()
        {
            Dt = clock.ElapsedTime.AsSeconds();
            clock.Restart();
            //Dt /= denominator;
        }
    }
}
