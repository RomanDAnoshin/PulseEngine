using SFML.System;

namespace Pulse.World
{
    public enum MoveDirection
    {
        Down,
        Up,
        Left,
        Right
    }

    public abstract class AbstractWorldMovableFourDirectionsObject : AbstractWorldObject
    {
        public bool IsMoving = false;
        public float MoveSpeed;
        public MoveDirection MoveDirection = MoveDirection.Down;
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
                IsMoving = true;
            }
        }

        public virtual void UpdateMove(float dt)
        {
            if (IsMoving) {
                    switch (MoveDirection) {
                        case MoveDirection.Up: MoveUp(dt); return;
                        case MoveDirection.Down: MoveDown(dt); return;
                        case MoveDirection.Left: MoveLeft(dt); return;
                        case MoveDirection.Right: MoveRight(dt); return;
                }
            }
        }

        private void MoveUp(float dt)
        {
            Position += Vector2f.Up * dt * MoveSpeed;

            if (Position.Y <= NewPosition.Y) {
                IsMoving = false;
                Position = NewPosition;
            }
        }

        private void MoveDown(float dt)
        {
            Position += Vector2f.Down * dt * MoveSpeed;

            if (Position.Y >= NewPosition.Y) {
                IsMoving = false;
                Position = NewPosition;
            }
        }

        private void MoveLeft(float dt)
        {
            Position += Vector2f.Left * dt * MoveSpeed;

            if (Position.X <= NewPosition.X) {
                IsMoving = false;
                Position = NewPosition;
            }
        }

        private void MoveRight(float dt)
        {
            Position += Vector2f.Right * dt * MoveSpeed;

            if (Position.X >= NewPosition.X) {
                IsMoving = false;
                Position = NewPosition;
            }
        }
    }
}
