using SFML.Graphics;
using SFML.System;

namespace Pulse
{
    public class AbstractAnimationHandler : AbstractGameObjectContainer
    {
        public int CurrentAnimationIndex = 0;
        public Vector2f Position
        {
            get
            {
                return ((Animation)Collection[CurrentAnimationIndex]).Position;
            }
            set
            {
                for(var i = 0; i < Collection.Count; i++) {
                    ((Animation)Collection[i]).Position = value;
                }
            }
        }

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
