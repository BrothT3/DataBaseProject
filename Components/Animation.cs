using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameTemplate
{
    public class Animation
    {
        public float FPS { get; private set; }
        public string Name { get; private set; }
        public Texture2D[] Sprites { get; private set; }
        public Texture2D Sprite { get; private set; }
        public Rectangle[] Rectangles { get; private set; }

        /// <summary>
        /// Creates an animation from a series of individual sprites
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprites"></param>
        /// <param name="fps"></param>
        public Animation(string name, Texture2D[] sprites, float fps)
        {
            Name = name;
            Sprites = sprites;
            FPS = fps;
        }

        /// <summary>
        /// Creates an animation from a spritesheet
        /// </summary>
        /// <param name="name"></param>
        /// <param name="texture"></param>
        /// <param name="frames"></param>
        /// <param name="fps"></param>
        public Animation(string name, Texture2D texture, int frames, float fps)
        {
            Name = name;
            Sprite = texture;
            FPS = fps;
            int width = Sprite.Width / frames;
            Rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle(i * width, 0, width, Sprite.Height);
            }

        }
    }
}
