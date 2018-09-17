using Pulse.System;
using Pulse.World;
using Pulse.World.Grid;
using SFML.Graphics;
using SFML.System;

namespace WanderingPasserby
{
    class World : AbstractWorld
    {
        public RectangularSpriteGrid Grid = null;
        public AbstractWorldLogic WorldLogic = null;
        public static Vector2f CellSize = new Vector2f(60f);
        public Passerby Passerby = null;
        public Home Home = null;

        public World()
        {
            int stepsCount = 10;
            Vector2i passerbyPositionInIndices = new Vector2i(
                MathF.RandomInt(stepsCount + 1, 320 - (stepsCount + 1)), 
                MathF.RandomInt(stepsCount + 1, 320 - (stepsCount + 1))
                );
            
            var gridSize = new Vector2i(
                passerbyPositionInIndices.X + stepsCount + 1, 
                passerbyPositionInIndices.Y + stepsCount + 1
                );
            Grid = new RectangularSpriteGrid(gridSize, CellSize, ResourceLoader.CellSprite);
            
            WorldLogic = new WorldLogic(this, Grid, passerbyPositionInIndices, stepsCount);
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
            Passerby.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            Initializer.GameView.Center = Passerby.Position;
            Grid.Draw(window);
            Passerby.Draw(window);
        }
    }
}
