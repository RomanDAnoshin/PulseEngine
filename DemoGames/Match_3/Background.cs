using Pulse;
using SFML.Graphics;

namespace Match_3
{
    enum BackgroundType
    {
        None,
        DarkPurple,
        Turquoise
    }

    class Background : BackgroundColor
    {
        private BackgroundType type = BackgroundType.None;
        public BackgroundType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                Color = ResourceLoader.Colors[(int)value];
            }
        }

        public Background(BackgroundType type) : base(ResourceLoader.Colors[(int)type])
        {
            Type = type;
        }
    }
}
