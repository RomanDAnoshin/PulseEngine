using SFML.System;

namespace Pulse.World
{
    public abstract class AbstractWorldObject : AbstractGameObject
    {
        public abstract Vector2f Position { get; set; }
    }
}
