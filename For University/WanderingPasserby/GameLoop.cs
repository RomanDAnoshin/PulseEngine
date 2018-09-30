using Pulse.Scene;
using SFML.Graphics;

namespace WanderingPasserby
{
    class GameLoop : Pulse.GameLoop
    {
        public GameLoop(RenderWindow window, SceneHandler sceneHandler) : base(window, sceneHandler)
        {

        }

        public override void Update()
        {
            while (window.IsOpen) {
                if (window.HasFocus()) {
                    window.DispatchEvents();
                    UpdateDt();
                    sceneHandler.Update(Dt);
                    window.SetView(Initializer.GameView);
                    sceneHandler.Draw(window);
                    window.Display();
                } else {
                    window.WaitAndDispatchEvents();
                }
            }
        }
    }
}
