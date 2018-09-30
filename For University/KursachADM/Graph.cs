using SFML.Graphics;
using System.Collections.Generic;

namespace KursachADM
{
    class Graph
    {
        public List<AlgorithmAction> AlgorithmActions = new List<AlgorithmAction>();
        public Color VisitedColor = Color.Orange;
        public Color AddToMinCellsColor = Color.Magenta;
        public Color PathColor = Color.Red;
        public Dictionary<Cell, Dictionary<Cell, int>> Vertices = new Dictionary<Cell, Dictionary<Cell, int>>();

        public void AddVertex(Cell cell, Dictionary<Cell, int> edges)
        {
            Vertices[cell] = edges;
        }

        public List<Cell> ShortestPath(Cell start, Cell finish)
        {
            var previous = new Dictionary<Cell, Cell>();
            var distances = new Dictionary<Cell, int>();
            var nodes = new List<Cell>();
            List<Cell> path = null;

            foreach (var vertex in Vertices) {
                if (vertex.Key == start) {
                    distances[vertex.Key] = 0;
                } else {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0) {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                AlgorithmActions.Add(new AlgorithmAction(smallest, AddToMinCellsColor));
                nodes.Remove(smallest);

                if (smallest == finish) {
                    path = new List<Cell>();
                    while (previous.ContainsKey(smallest)) {
                        path.Add(smallest);
                        smallest = previous[smallest];
                        AlgorithmActions.Add(new AlgorithmAction(smallest, PathColor));
                    }
                    break;
                }

                if (distances[smallest] == int.MaxValue) {
                    break;
                }

                foreach (var neighbor in Vertices[smallest]) {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key]) {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                        AlgorithmActions.Add(new AlgorithmAction(neighbor.Key, VisitedColor));
                    }
                }
            }

            return path;
        }
    }

    class AlgorithmAction
    {
        public Cell Cell = null;
        public Color Color = Color.Transparent;

        public AlgorithmAction(Cell cell, Color color)
        {
            Cell = cell;
            Color = color;
        }
    }
}
