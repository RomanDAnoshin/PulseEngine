using SFML.System;
using SFML.Graphics;
using Pulse.World;
using Pulse.System;

namespace Match_3.World.WorldObject
{
    enum DonutType
    {
        None,
        Blue,
        Green,
        Orange,
        Pink,
        Yellow
    }

    class Donut : AbstractWorldMovableObject
    {
        public static Vector2f Size = new Vector2f(60f);
        public int Points = 1;
        public DonutType Type = DonutType.None;
        
        public override Vector2f Position
        {
            get
            {
                return Sprite.Position;
            }
            set
            {
                Sprite.Position = value;
            }
        }
        public Sprite Sprite = null;

        public Donut(Vector2f position)
        {
            MoveSpeed = 220f;
            var type = (DonutType)MathF.RandomGenerator.Next(1, 6);
            Type = type;
            Sprite = new Sprite(ResourceLoader.DonutSprites[(int)type]);
            Position = position;
        }

        public override void DeleteNestedObjects()
        {
            Sprite = null;
        }

        public override void Update(float dt)
        {
            UpdateMove(dt);
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(Sprite);
        }
    }
}
