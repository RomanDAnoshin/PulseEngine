using SFML.Graphics;

namespace Match_3
{
    public enum BackgroundType
    {
        None,
        DarkPurple,
        Turquoise
    }

    public class Background
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
                Color = ResourceLoader.ColorsList[(int)value];
            }
        }
        public Color Color { get; private set; } = Color.Black;

        public Background(BackgroundType type)
        {
            Type = type;
        }

        public void Draw()
        {
            Initializer.Window.Clear(Color);
        }
    }
}
