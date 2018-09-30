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
        public int StepsCount = 10;
        public Passerby Passerby = null;
        public Home Home = null;

        public World()
        {
            Vector2i passerbyPositionInIndices = new Vector2i(
                MathF.RandomInt(StepsCount + 1, 320 - (StepsCount + 1)), 
                MathF.RandomInt(StepsCount + 1, 320 - (StepsCount + 1))
                );
            
            var gridSize = new Vector2i(
                passerbyPositionInIndices.X + StepsCount + 1, 
                passerbyPositionInIndices.Y + StepsCount + 1
                );
            Grid = new RectangularSpriteGrid(gridSize, CellSize, ResourceLoader.CellSprite);
            
            WorldLogic = new WorldLogic(this, Grid, passerbyPositionInIndices);
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
            Home.Draw(window);
            Passerby.Draw(window);
        }
    }
}
