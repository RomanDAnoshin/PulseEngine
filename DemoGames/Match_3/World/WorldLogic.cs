using Match_3.World.Grid;
using Match_3.World.WorldObject;
using Pulse.World;
using Pulse.World.Grid;
using Pulse.World.Grid.Cell;
using SFML.System;
using System.Collections.Generic;

namespace Match_3.World
{
    enum WorldLogicState
    {
        DonutsMoving,
        FindAndDeleteMatches,
        MoveToEmptyAndSpawn,
        WaitInput
    }

    class WorldLogic : AbstractWorldLogic
    {
        private AbstractWorld world = null;
        private AbstractRectangularClickableGrid grid = null;
        private readonly Cell[,] cells = null;
        private WorldLogicState logicState;
        private Cell[] selectedCells = null;
        public static int Score = 0;

        public WorldLogic(AbstractWorld world, AbstractRectangularClickableGrid grid)
        {
            this.world = world;
            this.grid = grid;
            cells = grid.Cells as Cell[,];
            selectedCells = new Cell[2];
            logicState = WorldLogicState.FindAndDeleteMatches;

            for (var y = 0; y < grid.CellCount.Y; y++) {
                for (int x = 0; x < grid.CellCount.X; x++) {
                    SpawnDonut(cells[y, x]);
                    cells[y, x].Clicked += UpdateSelectedCellsList;
                }
            }
        }

        public override void DeleteNestedObjects()
        {
            
        }

        public override void Update(float dt)
        {
            switch (logicState) {
                case WorldLogicState.DonutsMoving:
                    if (!AreDonutsMoved()) {
                        logicState = WorldLogicState.FindAndDeleteMatches;
                        return;
                    }
                    return;
                case WorldLogicState.FindAndDeleteMatches:
                    var matches = GetMatchesList();
                    if (matches.Count != 0) {
                        DeleteMatches(matches);
                        if (
                            selectedCells[0] != null &&
                            selectedCells[1] != null
                        ) {
                            selectedCells[0].CellState = ClickableCellState.Normal;
                            selectedCells[1].CellState = ClickableCellState.Normal;
                            selectedCells[0] = null;
                            selectedCells[1] = null;
                        }
                        logicState = WorldLogicState.MoveToEmptyAndSpawn;
                        return;
                    } else if (
                        selectedCells[0] != null &&
                        selectedCells[1] != null
                    ) {
                        RebindDonutAndMoveToNewOwner(selectedCells[0], selectedCells[1]);
                        RebindDonutAndMoveToNewOwner(selectedCells[1], selectedCells[0]);
                        selectedCells[0].CellState = ClickableCellState.Normal;
                        selectedCells[1].CellState = ClickableCellState.Normal;
                        selectedCells[0] = null;
                        selectedCells[1] = null;
                        logicState = WorldLogicState.DonutsMoving;
                        for (var y = 0; y < grid.CellCount.Y; y++) {
                            for (var x = 0; x < grid.CellCount.X; x++) {
                                cells[y, x].CellState = ClickableCellState.Disabled;
                            }
                        }
                        return;
                    } else {
                        for (var y = 0; y < grid.CellCount.Y; y++) {
                            for (var x = 0; x < grid.CellCount.X; x++) {
                                cells[y, x].CellState = ClickableCellState.Normal;
                            }
                        }
                        logicState = WorldLogicState.WaitInput;
                        return;
                    }
                case WorldLogicState.MoveToEmptyAndSpawn:
                    MoveDonutsToEmptyCells();
                    SpawnAndMoveToEmptyCells();
                    logicState = WorldLogicState.DonutsMoving;
                    for (var y = 0; y < grid.CellCount.Y; y++) {
                        for (var x = 0; x < grid.CellCount.X; x++) {
                            cells[y, x].CellState = ClickableCellState.Disabled;
                        }
                    }
                    return;
                case WorldLogicState.WaitInput:
                    if(
                        selectedCells[0] != null &&
                        selectedCells[1] != null
                    ) {
                        RebindDonutAndMoveToNewOwner(selectedCells[0], selectedCells[1]);
                        RebindDonutAndMoveToNewOwner(selectedCells[1], selectedCells[0]);
                        logicState = WorldLogicState.DonutsMoving;
                        for (var y = 0; y < grid.CellCount.Y; y++) {
                            for (var x = 0; x < grid.CellCount.X; x++) {
                                cells[y, x].CellState = ClickableCellState.Disabled;
                            }
                        }
                        return;
                    }
                    return;

            }
        }

        public bool AreDonutsMoved()
        {
            for (var y = 0; y < grid.CellCount.Y; y++) {
                for (var x = 0; x < grid.CellCount.X; x++) {
                    if (
                        cells[y, x].Donut != null &&
                        cells[y, x].Donut.IsMoving
                    ) {
                        return true;
                    }
                }
            }
            return false;
        }

        public void DontMoveToPoint(Donut donut, Vector2f point)
        {
            donut.NewPosition = point;
        }

        public void DeleteMatches(List<Cell[]> matches)
        {
            foreach (var match in matches) {
                for (var i = 0; i < match.Length; i++) {
                    if (match[i].Donut != null) {
                        Score += match[i].Donut.Points;
                        match[i].DeleteDonut();
                    }
                }
            }
            matches = null;
        }

        public List<Cell[]> GetMatchesList()
        {
            var matchesList = new List<Cell[]>();
            var count = 1;
            // Vertical find
            for (var x = 0; x < grid.CellCount.X; x++) {
                for (var y = 0; y < grid.CellCount.Y - 1; y++) {
                    if (cells[y, x].Donut.Type == cells[y + 1, x].Donut.Type) {
                        count++;
                        if (y == grid.CellCount.Y - 2 && count > 2) {
                            var addibleCells = new Cell[count];
                            for (var i = 0; i < count; i++) {
                                addibleCells[i] = cells[y - i, x];
                            }
                            matchesList.Add(addibleCells);
                            count = 1;
                        }
                    } else if (count > 2) {
                        var addibleCells = new Cell[count];
                        for (var i = 0; i < count; i++) {
                            addibleCells[i] = cells[y - i, x];
                        }
                        matchesList.Add(addibleCells);
                        count = 1;
                    } else {
                        count = 1;
                    }
                }
                count = 1;
            }
            count = 1;
            // Horizontal find
            for (var y = 0; y < grid.CellCount.Y; y++) {
                for (var x = 0; x < grid.CellCount.X - 1; x++) {
                    if (cells[y, x].Donut.Type == cells[y, x + 1].Donut.Type) {
                        count++;
                        if (x == grid.CellCount.X - 2 && count > 2) {
                            var addibleCells = new Cell[count];
                            for (var i = 0; i < count; i++) {
                                addibleCells[i] = cells[y, x - i];
                            }
                            matchesList.Add(addibleCells);
                            count = 1;
                        }
                    } else if (count > 2) {
                        var addibleCells = new Cell[count];
                        for (var i = 0; i < count; i++) {
                            addibleCells[i] = cells[y, x - i];
                        }
                        matchesList.Add(addibleCells);
                        count = 1;
                    } else {
                        count = 1;
                    }
                }
                count = 1;
            }
            return matchesList;
        }

        public void MoveDonutsToEmptyCells()
        {
            for (var x = grid.CellCount.X - 1; x >= 0; x--) {
                for (var y = grid.CellCount.Y - 1; y >= 0; y--) {
                    if (cells[y, x].Donut == null) {
                        for (var yy = y; yy >= 0; yy--) {
                            if (cells[yy, x].Donut != null) {
                                RebindDonutAndMoveToNewOwner(cells[yy, x], cells[y, x]);
                                y--;
                            }
                        }
                    }
                }
            }
        }

        public void SpawnAndMoveToEmptyCells()
        {
            var spawnedDonuts = 1;
            for (var x = grid.CellCount.X - 1; x >= 0; x--) {
                for (var y = grid.CellCount.Y - 1; y >= 0; y--) {
                    if (cells[y, x].Donut == null) {
                        var position = cells[0, x].Position + Vector2f.Up * spawnedDonuts * (grid.Offset + Donut.Size.Y);
                        SpawnDonutOnPointAndMoveToCell(position, cells[y, x]);
                        spawnedDonuts++;
                    }
                }
                spawnedDonuts = 1;
            }
        }

        public void SpawnDonut(Cell cell)
        {
            cell.Collection.Add(new Donut(cell.Position));
        }

        public void SpawnDonutOnPointAndMoveToCell(Vector2f point, Cell cell)
        {
            var donut = new Donut(point)
            {
                NewPosition = cell.Position
            };
            cell.Collection.Add(donut);
        }

        public void RebindDonut(Cell oldOwner, Cell newOwner)
        {
            var donut = oldOwner.Donut;
            oldOwner.Collection.Remove(donut);
            newOwner.Collection.Add(donut);
        }

        public void RebindDonutAndMoveToNewOwner(Cell oldOwner, Cell newOwner)
        {
            var donut = oldOwner.Donut;
            donut.NewPosition = newOwner.Position;
            oldOwner.Collection.Remove(donut);
            newOwner.Collection.Add(donut);
        }

        public void UpdateSelectedCellsList(ClickableCellState cellState)
        {
            switch (cellState) {
                case ClickableCellState.Hovered:
                    for (var i = 0; i < selectedCells.Length; i++) {
                        if (
                            selectedCells[i] != null &&
                            selectedCells[i].CellState == ClickableCellState.Hovered
                        ) {
                            selectedCells[i] = null;
                            return;
                        }
                    }
                    return;
                case ClickableCellState.Selected:
                    if(
                        selectedCells[0] == null &&
                        selectedCells[1] == null
                    ) {
                        for(var y =0; y< grid.CellCount.Y; y++) {
                            for(var x=0; x< grid.CellCount.X; x++) {
                                if(cells[y,x].CellState == ClickableCellState.Selected) {
                                    selectedCells[0] = cells[y, x];
                                    return;
                                }
                            }
                        }
                    } else if(
                        selectedCells[0] == null &&
                        selectedCells[1] != null
                    ) {
                        for (var y = 0; y < grid.CellCount.Y; y++) {
                            for (var x = 0; x < grid.CellCount.X; x++) {
                                if (
                                    cells[y, x].CellState == ClickableCellState.Selected &&
                                    cells[y, x] != selectedCells[1]
                                ) {
                                    if (
                                        (x != 0 && cells[y, x - 1] == selectedCells[1]) ||
                                        (y != 0 && cells[y - 1, x] == selectedCells[1]) ||
                                        (x != grid.CellCount.X - 1 && cells[y, x + 1] == selectedCells[1]) ||
                                        (y != grid.CellCount.Y - 1 && cells[y + 1, x] == selectedCells[1])
                                    ) {
                                        selectedCells[0] = cells[y, x];
                                    } else {
                                        cells[y, x].CellState = ClickableCellState.Hovered;
                                    }
                                    return;
                                }
                            }
                        }
                    } else if(
                        selectedCells[0] != null &&
                        selectedCells[1] == null
                    ) {
                        for (var y = 0; y < grid.CellCount.Y; y++) {
                            for (var x = 0; x < grid.CellCount.X; x++) {
                                if (
                                    cells[y, x].CellState == ClickableCellState.Selected &&
                                    cells[y, x] != selectedCells[0]
                                ) {
                                    if (
                                        (x != 0 && cells[y, x - 1] == selectedCells[0]) ||
                                        (y != 0 && cells[y - 1, x] == selectedCells[0]) ||
                                        (x != grid.CellCount.X - 1 && cells[y, x + 1] == selectedCells[0]) ||
                                        (y != grid.CellCount.Y - 1 && cells[y + 1, x] == selectedCells[0])
                                    ) {
                                        selectedCells[1] = cells[y, x];
                                    } else {
                                        cells[y, x].CellState = ClickableCellState.Hovered;
                                    }
                                    return;
                                }
                            }
                        }
                    } else if(
                        selectedCells[0] != null &&
                        selectedCells[1] != null
                    ) {
                        for (var y = 0; y < grid.CellCount.Y; y++) {
                            for (var x = 0; x < grid.CellCount.X; x++) {
                                if (
                                    cells[y, x].CellState == ClickableCellState.Selected &&
                                    cells[y, x] != selectedCells[0] &&
                                    cells[y, x] != selectedCells[1]
                                ) {
                                    cells[y, x].CellState = ClickableCellState.Hovered;
                                    return;
                                }
                            }
                        }
                    }
                    return;
            }
        }
    }
}
