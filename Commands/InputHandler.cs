using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGameTemplate
{
    public class InputHandler
    {
        private static InputHandler instance;

        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                }
                return instance;
            }
        }

        private Dictionary<Keys, ICommand> playerKeybinds = new Dictionary<Keys, ICommand>();
        private Dictionary<Keys, ICommand> cameraKeybinds = new Dictionary<Keys, ICommand>();
        public InputHandler()
        {
            Player player = (Player)GameWorld.Instance.FindObjectOfType<Player>();

            
            playerKeybinds.Add(Keys.D, new MoveCommand(new Vector2(1, 0)));
            playerKeybinds.Add(Keys.W, new MoveCommand(new Vector2(0, -1)));
            playerKeybinds.Add(Keys.A, new MoveCommand(new Vector2(-1, 0)));
            playerKeybinds.Add(Keys.S, new MoveCommand(new Vector2(0, 1)));

            cameraKeybinds.Add(Keys.Right, new MoveCommand(new Vector2(8, 0)));
            cameraKeybinds.Add(Keys.Up, new MoveCommand(new Vector2(0, -8)));
            cameraKeybinds.Add(Keys.Left, new MoveCommand(new Vector2(-8, 0)));
            cameraKeybinds.Add(Keys.Down, new MoveCommand(new Vector2(0, 8)));
        }

        public void Execute(Player player)
        {
            KeyboardState keyState = Keyboard.GetState();

            
            foreach (Keys k in playerKeybinds.Keys)
            {
                if (keyState.IsKeyDown(k))
                {
                    playerKeybinds[k].Execute(player);
                    
                }
            
            }

            //If camera is wanted
            if (GameWorld.Instance.CameraEnabled)
            {
                Camera c = GameWorld.Instance._camera;
                Execute(c);
            }
        }

        public void Execute(Camera camera)
        {
            KeyboardState keyState = Keyboard.GetState();

            foreach (Keys key in cameraKeybinds.Keys)
            {
                if (keyState.IsKeyDown(key))
                {
                    cameraKeybinds[key].Execute(camera);
                }
            }
        }
    }

}
