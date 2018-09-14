using Pulse.World;
using Match_3.World.Grid;
using SFML.Graphics;
using Pulse.World.Grid;
using SFML.System;
using Match_3.World.WorldObject;

namespace Match_3.World
{
    class GameWorld : AbstractWorld
    {
        public AbstractClickableGrid Grid = null;
        public AbstractWorldLogic WorldLogic = null;
        public const int AmountOfDonuts = 8;

        public GameWorld()
        {
            var gridSize = new Vector2i(AmountOfDonuts);
            Grid = new WorldGrid(gridSize, Donut.Size);
            WorldLogic = new WorldLogic(this, (WorldGrid)Grid);
        }

        public override void DeleteNestedObjects()
        {
            WorldLogic.DeleteNestedObjects();
            WorldLogic = null;
            Grid.DeleteNestedObjects();
            Grid = null;
        }

        public override void Update(float dt)
        {
            WorldLogic.Update(dt);
            Grid.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            Grid.Draw(window);
        }
    }
}
