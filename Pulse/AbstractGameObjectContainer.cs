using SFML.Graphics;
using System.Collections.Generic;

namespace Pulse
{
    public abstract class AbstractGameObjectContainer : AbstractGameObject
    {
        public List<AbstractGameObject> Collection = null;

        public void ClearAndNullCollection()
        {
            if (Collection != null) {
                Collection.Clear();
                Collection = null;
            }
        }

        public void UpdateCollection(float dt)
        {
            if (Collection != null) {
                foreach (var @object in Collection) {
                    @object.Update(dt);
                }
            }
        }

        public void DrawCollection(RenderWindow window)
        {
            if (Collection != null) {
                foreach (var @object in Collection) {
                    @object.Draw(window);
                }
            }
        }
    }
}
