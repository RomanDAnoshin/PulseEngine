using Pulse.World;
using SFML.Graphics;
using System.Collections.Generic;

namespace Pulse
{
    public class FourDirectionsMoveAnimatoinsHandler : AbstractAnimationHandler
    {
        public FourDirectionsMoveAnimatoinsHandler(Sprite[,] sprites, MoveDirection moveDirection)
        {
            Collection = new List<AbstractGameObject>();
            for (var i = 0; i < sprites.GetLength(0); i++) {
                Sprite[] spritesRow = new Sprite[sprites.GetLength(1)];
                for (var j = 0; j < sprites.GetLength(1); j++) {
                    spritesRow[j] = sprites[i, j];
                }
                Collection.Add(new Animation(spritesRow));
            }
            CurrentAnimationIndex = (int)moveDirection;
        }
    }
}
