using KursachADM.Interfaces;
using Pulse.World;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace KursachADM
{
    enum WorldLogicState
    {
        FindingPath,
        MovingOnPath,
        Visualization,
        Done
    }

    class WorldLogic : AbstractWorldLogic
    {
        private World world = null;
        private WorldGrid grid = null;
        private PlayInterface playInterface = null;
        private readonly Cell[,] cells = null;
        private WorldLogicState logicState;
        private readonly Vector2i startInIndices = Vector2i.Zero;
        private readonly Vector2i finishInIndices = Vector2i.Zero;
        private Graph graph = null;
        private List<Cell> path;
        private int currentCellOnMoving = 0;
        private int visualisationAlgorithmActionCell = 0;
        private float visualisationPauseTimer = ResourceLoader.VisualisationPauseTime;

        public WorldLogic(World world, WorldGrid grid, Vector2i startInIndices, Vector2i finishInIndices, PlayInterface playInterface)
        {
            this.world = world;
            this.grid = grid;
            this.playInterface = playInterface;
            cells = grid.Cells as Cell[,];
            this.startInIndices = startInIndices;
            this.finishInIndices = finishInIndices;
            graph = new Graph();
            for (var y = 0; y < grid.CellCount.Y; y++) {
                for (var x = 0; x < grid.CellCount.X; x++) {
                    var neighbors = GetNeighbors(new Vector2i(x, y));
                    if(neighbors != null) {
                        switch (neighbors.Count) {
                            case 1: graph.AddVertex(cells[y, x], new Dictionary<Cell, int>() { { neighbors[0], neighbors[0].Weight } }); break;
                            case 2: graph.AddVertex(cells[y, x], new Dictionary<Cell, int>() { { neighbors[0], neighbors[0].Weight }, { neighbors[1], neighbors[1].Weight } }); break;
                            case 3: graph.AddVertex(cells[y, x], new Dictionary<Cell, int>() { { neighbors[0], neighbors[0].Weight }, { neighbors[1], neighbors[1].Weight }, { neighbors[2], neighbors[2].Weight } }); break;
                            case 4: graph.AddVertex(cells[y, x], new Dictionary<Cell, int>() { { neighbors[0], neighbors[0].Weight }, { neighbors[1], neighbors[1].Weight }, { neighbors[2], neighbors[2].Weight }, { neighbors[3], neighbors[3].Weight } }); break;
                        }
                    }
                }
            }
            path = new List<Cell>();

            SpawnStart(cells[startInIndices.Y, startInIndices.X]);
            SpawnMan(cells[startInIndices.Y, startInIndices.X]);
            SpawnFinish(cells[finishInIndices.Y, finishInIndices.X]);

            logicState = WorldLogicState.FindingPath;
        }

        public override void DeleteNestedObjects()
        {

        }

        public override void Update(float dt)
        {
            switch (logicState) {
                case WorldLogicState.MovingOnPath:
                    if (!world.Man.IsMoving) {
                        currentCellOnMoving++;
                        if (currentCellOnMoving < path.Count) {
                            for(var y = 0; y < grid.CellCount.Y; y++) {
                                for(var x = 0; x < grid.CellCount.X; x++) {
                                    if(cells[y,x] == path[currentCellOnMoving - 1]) {
                                        MoveDirection direction = MoveDirection.Down;
                                        if (y != grid.CellCount.Y && cells[y + 1, x] == path[currentCellOnMoving]) {
                                            direction = MoveDirection.Down;
                                        }else if(y != 0 && cells[y - 1, x] == path[currentCellOnMoving]) {
                                            direction = MoveDirection.Up;
                                        }else if(x != 0 && cells[y, x - 1] == path[currentCellOnMoving]) {
                                            direction = MoveDirection.Left;
                                        }else if(x != grid.CellCount.X - 1 && cells[y, x + 1] == path[currentCellOnMoving]) {
                                            direction = MoveDirection.Right;
                                        }
                                        ManMoveToCell(path[currentCellOnMoving], direction);
                                        return;
                                    }
                                }
                            }
                        } else {
                            logicState = WorldLogicState.Done;
                            return;
                        }
                    }
                    return;
                case WorldLogicState.FindingPath:
                    path = graph.ShortestPath(cells[startInIndices.Y, startInIndices.X], cells[finishInIndices.Y, finishInIndices.X]);
                    path.Add(cells[startInIndices.Y, startInIndices.X]);
                    path.Reverse();
                    logicState = WorldLogicState.Visualization;
                    return;
                case WorldLogicState.Visualization:
                    visualisationPauseTimer -= dt;
                    if (visualisationPauseTimer < 0) {
                        if (visualisationAlgorithmActionCell < graph.AlgorithmActions.Count) {
                            graph.AlgorithmActions[visualisationAlgorithmActionCell].Cell.Sprite.Color = graph.AlgorithmActions[visualisationAlgorithmActionCell].Color;
                            visualisationAlgorithmActionCell++;
                        } else {
                            logicState = WorldLogicState.MovingOnPath;
                        }
                        visualisationPauseTimer = ResourceLoader.VisualisationPauseTime;
                    }
                    return;
                case WorldLogicState.Done:
                    Initializer.GameView.Center = new Vector2f(Initializer.WindowSize.X / 2, Initializer.WindowSize.Y / 2);
                    if (playInterface.DoneButton == null) {
                        playInterface.CreateDoneButton();
                    }
                    return;
            }
        }

        private List<Cell> GetNeighbors(Cell cell)
        {
            int x = 0;
            int y = 0;
            for(y = 0; y < grid.CellCount.Y; y++) {
                for (x = 0; x < grid.CellCount.X; x++) {
                    if (cells[y, x] == cell) {
                        return GetNeighbors(new Vector2i(x, y));
                    }
                }
            }
            return null;
        }

        private List<Cell> GetNeighbors(Vector2i cellIndices)
        {
            var neighbors = new List<Cell>();
            // Left neighbor
            if (cellIndices.X != 0) {
                neighbors.Add(cells[cellIndices.Y, cellIndices.X - 1]);
            }
            // Up neighbor
            if (cellIndices.Y != 0) {
                neighbors.Add(cells[cellIndices.Y - 1, cellIndices.X]);
            }
            // Right neighbor
            if (cellIndices.X != grid.CellCount.X - 1) {
                neighbors.Add(cells[cellIndices.Y, cellIndices.X + 1]);
            }
            // Down neighbor
            if (cellIndices.Y != grid.CellCount.Y - 1) {
                neighbors.Add(cells[cellIndices.Y + 1, cellIndices.X]);
            }
            return neighbors;
        }

        private void ManMoveToCell(Cell cell, MoveDirection direction)
        {
            world.Man.MoveDirection = direction;
            world.Man.NewPosition = cell.Position;
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
