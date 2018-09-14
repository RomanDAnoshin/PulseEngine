using Pulse.System;
using SFML.System;

namespace Pulse.World
{
    public abstract class AbstractWorldMovableObject : AbstractWorldObject
    {
        public bool IsMoved = false;
        public float MoveSpeed;
        protected Vector2f normalizedMoveVector = Vector2f.Zero;
        public virtual Vector2f NormalizedMoveVector
        {
            get
            {
                return normalizedMoveVector;
            }
            set
            {
                normalizedMoveVector = value;
                newPosition = normalizedMoveVector * MoveSpeed + Position;
            }
        }
        protected Vector2f newPosition = Vector2f.Zero;
        public virtual Vector2f NewPosition
        {
            get
            {
                return newPosition;
            }
            set
            {
                newPosition = value;
                var moveVector = newPosition - Position;
                var length = MathF.GetVectorLength(moveVector);
                normalizedMoveVector = moveVector / length;
                IsMoved = true;
            }
        }

        public virtual void UpdateMove(float dt)
        {
            if (IsMoved) {
                Position += NormalizedMoveVector * dt * MoveSpeed;
                if (NormalizedMoveVector.Y != 0) {
                    // Vertical move
                    if (NormalizedMoveVector.Y > 0) {
                        // Move down
                        if (Position.Y >= NewPosition.Y) {
                            IsMoved = false;
                            var position = Position;
                            position.Y = NewPosition.Y;
                            normalizedMoveVector.Y = 0;
                        }
                    } else {
                        // Move up
                        if (Position.Y <= NewPosition.Y) {
                            IsMoved = false;
                            var position = Position;
                            position.Y = NewPosition.Y;
                            normalizedMoveVector.Y = 0;
                        }
                    }
                }
                if (NormalizedMoveVector.X != 0) {
                    // Horizontal move
                    if (NormalizedMoveVector.X > 0) {
                        // Move right
                        if (Position.X >= NewPosition.X) {
                            IsMoved = false;
                            var position = Position;
                            position.X = NewPosition.X;
                            normalizedMoveVector.X = 0;
                        }
                    } else {
                        // Move left
                        if (Position.X <= NewPosition.X) {
                            IsMoved = false;
                            var position = Position;
                            position.X = NewPosition.X;
                            normalizedMoveVector.X = 0;
                        }
                    }
                }
            }
        }
    }
}
