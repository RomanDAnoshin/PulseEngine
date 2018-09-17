using Pulse.System;
using Pulse.World;
using Pulse.World.Grid;
using Pulse.World.Grid.Cell;
using SFML.System;

namespace WanderingPasserby
{
    enum WorldLogicState
    {
        Moving,
        SelectingDirection,
        Check
    }

    class WorldLogic : AbstractWorldLogic
    {
        private World world = null;
        private RectangularSpriteGrid grid = null;
        private readonly RectangularSpriteCell[,] cells = null;
        private WorldLogicState logicState;
        private int stepsCount = 0;

        public WorldLogic(World world, RectangularSpriteGrid grid, Vector2i passerbyPositionInIndices, int stepsCount)
        {
            this.world = world;
            this.grid = grid;
            cells = grid.Cells as RectangularSpriteCell[,];

            this.stepsCount = stepsCount;
            SpawnPasserby(cells[passerbyPositionInIndices.Y, passerbyPositionInIndices.X]);
            SpawnHome(cells[grid.CellCount.Y / 2, grid.CellCount.X / 2]);

            logicState = WorldLogicState.Check;
        }

        public override void DeleteNestedObjects()
        {

        }

        public override void Update(float dt)
        {
            switch (logicState) {
                case WorldLogicState.Check:
                    if (world.Passerby.Position == world.Home.Position) {
                        // save yes
                        return;
                    } else {
                        if(stepsCount == 0) {
                            // save no
                            return;
                        } else {
                            logicState = WorldLogicState.SelectingDirection;
                            stepsCount--;
                            return;
                        }
                    }
                case WorldLogicState.SelectingDirection:
                    var randomValue = MathF.RandomInt(0, 3);
                    MoveDirection direction = (MoveDirection)randomValue;
                    Vector2i directionVector = Vector2i.Down;
                    switch (randomValue) {
                        case 0: directionVector = Vector2i.Down; break;
                        case 1: directionVector = Vector2i.Up; break;
                        case 2: directionVector = Vector2i.Left; break;
                        case 3: directionVector = Vector2i.Right; break;
                    }
                    for (var y = 0; y < grid.CellCount.Y; y++) {
                        for (var x = 0; x < grid.CellCount.X; x++) {
                            if(cells[y,x].Position == world.Passerby.Position) {
                                PasserbyMoveToCell(cells[y + directionVector.Y, x + directionVector.X], direction);
                                logicState = WorldLogicState.Moving;
                                return;
                            }
                        }
                    }
                    return;
                case WorldLogicState.Moving:
                    if (!IsPasserbyMoving()) {
                        logicState = WorldLogicState.Check;
                        return;
                    }
                    return;
            }
        }

        public bool IsPasserbyMoving()
        {
            return world.Passerby.IsMoving;
        }

        public void PasserbyMoveToCell(RectangularSpriteCell cell, MoveDirection moveDirection)
        {
            world.Passerby.MoveDirection = moveDirection;
            world.Passerby.NewPosition = cell.Position;
        }

        public void SpawnPasserby(RectangularSpriteCell cell)
        {
            world.Passerby = new Passerby(cell.Position);
        }

        public void SpawnHome(RectangularSpriteCell cell)
        {
            world.Home = new Home(cell.Position);
        }
    }
}
