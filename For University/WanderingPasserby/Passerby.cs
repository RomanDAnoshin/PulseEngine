using Pulse;
using Pulse.World;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace WanderingPasserby
{
    class Passerby : AbstractWorldMovableFourDirectionsObject
    {
        public static Vector2f Size = new Vector2f(60f);
        public FourDirectionsMoveAnimatoinsHandler AnimatoinsHandler = null;

        public override Vector2f Position
        {
            get
            {
                return AnimatoinsHandler.Position;
            }
            set
            {
                AnimatoinsHandler.Position = value;
            }
        }

        public Passerby(Vector2f position)
        {
            MoveSpeed = 200f;
            AnimatoinsHandler = new FourDirectionsMoveAnimatoinsHandler(ResourceLoader.PasserbyMoveAnimationsSprites, MoveDirection);
            Position = position;
        }

        public override void DeleteNestedObjects()
        {
            AnimatoinsHandler.DeleteNestedObjects();
            AnimatoinsHandler = null;
        }

        public override void Update(float dt)
        {
            UpdateMove(dt);
            AnimatoinsHandler.Update(dt);
        }

        public override void Draw(RenderWindow window)
        {
            AnimatoinsHandler.Draw(window);
        }
    }

    class FourDirectionsMoveAnimatoinsHandler : AbstractAnimationHandler
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
