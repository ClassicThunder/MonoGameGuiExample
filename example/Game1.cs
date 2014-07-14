//
// Press tab to toggle between screens.
//

using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GuiExample
{

    public class Game1 : Game
    {

        private readonly GraphicsDeviceManager _graphics;

        private Screen _currentScreen;
        private Screen[] _currentScreens;
        private KeyboardState _oldState;
        private int _index;

        public SpriteFont GreySpriteFont;
        public Texture2D GreyImageMap;
        public string GreyMap;

        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8
            };

            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += delegate
            {
                if (_currentScreen != null) { _currentScreen.OnResize(); }
            };

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

            _currentScreens = new Screen[] {                
                new WidgetDemonstration(),
                new InputTest(),          
                new LayoutTest(),
                new ButtonTest()
            };

            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {

            GreyImageMap = Content.Load<Texture2D>(@"GreySkin\ImageMap");
            GreyMap = File.OpenText(@"Content\GreySkin\Map.txt").ReadToEnd();
            GreySpriteFont = Content.Load<SpriteFont>(@"GreySkin\Texture");

            //DebugUtils.Init(_graphics.GraphicsDevice, GreySpriteFont);

            _index = 0;
            _currentScreen = _currentScreens[_index];
            _currentScreen.Init(this);
        }

        protected override void Update(GameTime gameTime)
        {

            var newState = Keyboard.GetState();

            if (_oldState.IsKeyUp(Keys.Tab) && newState.IsKeyDown(Keys.Tab))
            {
                if (_index + 1 == _currentScreens.Length)
                {
                    _index = 0;
                }
                else
                {
                    _index++;
                }

                _currentScreen = _currentScreens[_index];
                _currentScreen.Init(this);
            }

            _currentScreen.Update(gameTime);

            _oldState = newState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(_currentScreen.Color);

            _currentScreen.Draw();

            base.Draw(gameTime);
        }
    }
}
