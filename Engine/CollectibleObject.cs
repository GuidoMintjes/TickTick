using System;
using Microsoft.Xna.Framework;

namespace Engine {
    class CollectibleObject : SpriteGameObject{

        protected float bounce;
        Vector2 startPosition;
        protected float counter = 10;
        public static Random rng = new Random();

        public CollectibleGameObject(Level level, Vector2 startPosition) : base("Sprites/LevelObjects/Powerup/Appleup.png", TickTick.Depth_LevelObjects) {
            this.level = level;
            this.startPosition = startPosition;

            SetOriginToCenter();

            Reset();
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            double t = gameTime.TotalGameTime.TotalSeconds * 3.0f + LocalPosition.X;
            bounce = (float)Math.Sin(t) * 0.2f;
            localPosition.Y += bounce;

            // check if the player collects this object
            if (Visible && level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player)) {
                Visible = false;
                ExtendedGame.AssetManager.PlaySoundEffect("Sounds/snd_watercollected");
            }

        }
    }
}
