using Pulse;
using Pulse.World;
using SFML.Graphics;
using SFML.System;

namespace KursachADM
{
    class Man : AbstractWorldMovableFourDirectionsObject
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

        public Man(Vector2f position)
        {
            MoveSpeed = 80f;
            AnimatoinsHandler = new FourDirectionsMoveAnimatoinsHandler(ResourceLoader.ManMoveAnimationsSprites, MoveDirection);
            foreach (var obj in AnimatoinsHandler.Collection) {
                var animation = obj as Animation;
                animation.Speed = 7;
            }
            
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
            if (IsMoving) {
                AnimatoinsHandler.Update(dt);
            }
        }

        public override void Draw(RenderWindow window)
        {
            AnimatoinsHandler.Draw(window);
        }

        public override void UpdateMove(float dt)
        {
            base.UpdateMove(dt);
            AnimatoinsHandler.CurrentAnimationIndex = (int)MoveDirection;
        }
    }
}
