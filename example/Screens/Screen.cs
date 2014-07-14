using Microsoft.Xna.Framework;
using Ruminate.GUI.Framework;

namespace GuiExample {

    public abstract class Screen {

        public Color Color { get; set; }
        public Gui Gui { get; set; }
        public Game Game { get; set; }

        public virtual void Init(Game1 game) { Game = game; }

        public abstract void OnResize();
        public abstract void Update(GameTime time);
        public abstract void Draw();
    }
}
