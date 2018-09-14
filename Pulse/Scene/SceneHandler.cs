using Pulse.System;
using SFML.Graphics;

namespace Pulse.Scene
{
    public class SceneHandler : AbstractGameObject
    {
        public AbstractScene CurrentScene = null;

        public SceneHandler(AbstractScene scene)
        {
            CurrentScene = scene;
        }

        public override void DeleteNestedObjects()
        {
            CurrentScene.DeleteNestedObjects();
            CurrentScene = null;
        }

        public override void Update(float dt)
        {
            if (CurrentScene != null) {
                CurrentScene.Update(dt);
            }
            WindowInput.Update();
        }

        public override void Draw(RenderWindow window)
        {
            if (CurrentScene != null) {
                CurrentScene.Draw(window);
            }
        }

        public virtual void TransitionToScene(AbstractScene newScene)
        {
            CurrentScene.DeleteNestedObjects();
            CurrentScene = newScene;
        }
    }
}
