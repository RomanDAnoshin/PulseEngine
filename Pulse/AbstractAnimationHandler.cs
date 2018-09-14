using SFML.Graphics;
using System.Collections.Generic;

namespace Pulse
{
    public class AbstractAnimationHandler : AbstractGameObjectContainer
    {
        public int CurrentAnimationIndex = 0;

        public override void DeleteNestedObjects()
        {
            ClearAndNullCollection();
        }

        public override void Update(float dt)
        {
            Collection[CurrentAnimationIndex].Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            Collection[CurrentAnimationIndex].Draw(window);
        }
    }
}
