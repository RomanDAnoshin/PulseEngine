using Match_3.World.WorldObject;
using Pulse;
using Pulse.World.Grid.Cell;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Match_3.World.Grid
{
    class Cell : RectangularSpriteClickableCell
    {
        public Donut Donut
        {
            get
            {
                if (Collection.Count == 0) {
                    return null;
                } else {
                    return Collection[0] as Donut;
                }
            }
        }

        public Cell(Vector2f position, Vector2f size, Sprite[] sprites): base(position, size, sprites)
        {
            Collection = new List<AbstractGameObject>();
        }

        public void DeleteDonut()
        {
            if (Donut != null) {
                Donut.DeleteNestedObjects();
                Collection.Remove(Donut);
            }
        }
    }
}
