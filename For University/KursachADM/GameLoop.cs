using Pulse.Scene;
using SFML.Graphics;

namespace KursachADM
{
    class GameLoop : Pulse.GameLoop
    {
        const float timeSpeed = 1f;

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

        protected override void UpdateDt()
        {
            Dt = clock.ElapsedTime.AsSeconds();
            clock.Restart();
            Dt *= timeSpeed;
        }
    }
}
