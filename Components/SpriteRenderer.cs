using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameTemplate
{
    public class SpriteRenderer : Component
    {
        public Texture2D Sprite { get; set; }
        public Vector2 Origin { get; set; }
        public int OffSetY { get; set; } = 0;
        public int OffSetX { get; set; } = 0;
        public float Scale { get; set; } = 1f;
        public Rectangle Rectangle { get; set; }
        public SpriteEffects SpriteEffect { get; set; } = SpriteEffects.None;

        public override void Start()
        {
            Origin = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
        }

        /// <summary>
        /// Sets the sprite of a component through the instance of a SpriteRenderer
        /// </summary>
        /// <param name="spriteName"></param>
        public void SetSprite(string spriteName)
        {
            Sprite = GameWorld.Instance.Content.Load<Texture2D>(spriteName);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //if not using spritesheet
            if (Rectangle.IsEmpty)
                spriteBatch.Draw(Sprite, new Vector2(GameObject.Transform.Position.X + OffSetX, GameObject.Transform.Position.Y + OffSetY), null, Color.White, 0, Origin, Scale, SpriteEffect, 1);
            else
            {
                spriteBatch.Draw(Sprite, new Vector2(GameObject.Transform.Position.X + OffSetX, GameObject.Transform.Position.Y + OffSetY), Rectangle, Color.White, 0, Origin, Scale, SpriteEffect, 1);
            }
        }
    }
}
