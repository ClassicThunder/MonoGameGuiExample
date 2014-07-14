using Microsoft.Xna.Framework;
using Ruminate.GUI.Framework;

namespace GuiExample {

    public abstract class Screen {

        public Color Color { get; set; }
        public Gui Gui { get; set; }

        public abstract void Init(Game1 game);
        public abstract void OnResize();
        public abstract void Update();
        public abstract void Draw();
    }
}
