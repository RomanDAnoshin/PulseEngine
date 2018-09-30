using KursachADM.Interfaces;
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

        public World(PlayInterface playInterface)
        {
            Grid = new WorldGrid(ResourceLoader.GridSize, CellSize);
            WorldLogic = new WorldLogic(this, Grid, ResourceLoader.StartPositionIndices, ResourceLoader.FinishPositionIndices, playInterface);
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
            Grid.Draw(window);
            Start.Draw(window);
            Finish.Draw(window);
            Man.Draw(window);
        }
    }
}