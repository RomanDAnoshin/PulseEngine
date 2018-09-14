using Match_3.GUI;
using Pulse.Scene;
using SFML.Graphics;

namespace Match_3.Scene
{
    class SceneGameMenu : AbstractScene
    {
        public SceneGameMenu()
        {
            Background = new Background(BackgroundType.DarkPurple);
            GUI = new GameMenuInterface();
        }

        public override void DeleteNestedObjects()
        {
            Background = null;

            GUI.DeleteNestedObjects();
            GUI = null;
        }

        public override void Update(float dt)
        {
            GUI.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            Background.Draw(window);
            GUI.Draw(window);
        }
    }
}
