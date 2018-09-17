using Pulse.World;
using SFML.System;

namespace KursachADM
{
    enum WorldLogicState
    {
        FindingPath,
        MovingOnPath
    }

    class WorldLogic : AbstractWorldLogic
    {
        private World world = null;
        private WorldGrid grid = null;
        private readonly Cell[,] cells = null;
        private WorldLogicState logicState;
        private Cell[] path;

        public WorldLogic(World world, WorldGrid grid, Vector2i startPositionInIndices, Vector2i finishPositionInIndices)
        {
            this.world = world;
            this.grid = grid;
            cells = grid.Cells as Cell[,];

            SpawnStart(cells[startPositionInIndices.Y, startPositionInIndices.X]);
            SpawnMan(cells[startPositionInIndices.Y, startPositionInIndices.X]);
            SpawnFinish(cells[finishPositionInIndices.Y, finishPositionInIndices.X]);

            logicState = WorldLogicState.FindingPath;
        }

        public override void DeleteNestedObjects()
        {

        }

        public override void Update(float dt)
        {
            switch (logicState) {

            }
        }

        private void SpawnMan(Cell cell)
        {
            world.Man = new Man(cell.Position);
        }

        private void SpawnStart(Cell cell)
        {
            world.Start = new StartFinishObject(cell.Position, true);
        }

        private void SpawnFinish(Cell cell)
        {
            world.Finish = new StartFinishObject(cell.Position, false);
        }
    }
}
