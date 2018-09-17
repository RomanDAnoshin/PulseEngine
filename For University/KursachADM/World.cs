using Pulse.World;
using SFML.Graphics;
using SFML.System;

namespace KursachADM
{
    class World : AbstractWorld
    {
        public WorldGrid Grid = null;
        public AbstractWorldLogic WorldLogic = null;
        public static Vector2f CellSize = new Vector2f(60f);
        public Man Man = null;
        public StartFinishObject Start = null;
        public StartFinishObject Finish = null;

        public World()
        {
            Grid = new WorldGrid(ResourceLoader.GridSize, CellSize);

            WorldLogic = new WorldLogic(this, Grid, ResourceLoader.StartPositionIndices, ResourceLoader.FinishPositionIndices );
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
            Man.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            Initializer.GameView.Center = Man.Position;
            Grid.Draw(window);
            Man.Draw(window);
        }
    }
}