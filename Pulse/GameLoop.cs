using Pulse.Scene;
using SFML.Graphics;
using SFML.System;
using System;

namespace Pulse
{
    public class GameLoop
    {
        protected RenderWindow window = null;
        protected SceneHandler sceneHandler = null;
        protected Clock clock = null;
        public static float Dt = 0;
        // Control the speed of the game
        //const float timeSpeed = 1f; 

        public GameLoop(RenderWindow window, SceneHandler sceneHandler)
        {
            clock = new Clock();
            this.window = window;
            this.sceneHandler = sceneHandler;
            window.GainedFocus += Window_GainedFocus;
        }

        protected void Window_GainedFocus(object sender, EventArgs e)
        {
            clock.Restart();
        }

        public virtual void Update()
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

        protected virtual void UpdateDt()
        {
            Dt = clock.ElapsedTime.AsSeconds();
            clock.Restart();
            //Dt *= timeSpeed;
        }
    }
}
