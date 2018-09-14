using SFML.System;

namespace Pulse.World.Grid.Cell
{
    public abstract class AbstractCell : AbstractGameObjectContainer
    {
        public abstract Vector2f Position { get; set; }
    }
}
