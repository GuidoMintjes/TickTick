using System;
using Microsoft.Xna.Framework;
using Engine;

class CollectibleObject : SpriteGameObject {

    protected Level level;

    protected float bounce;
    protected Vector2 startPosition;
    protected float counter = 10;
    public static Random rng = new Random();

    public CollectibleObject(Level level, Vector2 startPosition, string spritePath) : base(spritePath, TickTick.Depth_LevelObjects) {
        
        this.level = level;
        this.startPosition = startPosition;

        SetOriginToCenter();

        Reset();
    }

    public override void Update(GameTime gameTime) {

        double t = gameTime.TotalGameTime.TotalSeconds * 3.0f + LocalPosition.X;
        bounce = (float)Math.Sin(t) * 0.2f;
        localPosition.Y += bounce;

        // check if the player collects this object
        if (Visible && level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player)) {
            Visible = false;
            ExtendedGame.AssetManager.PlaySoundEffect("Sounds/snd_watercollected");

            HandleCollision();
        }
    }

    public override void Reset() {
        localPosition = startPosition;
        Visible = true;

        base.Reset();
    }


    public virtual void HandleCollision() {

        Console.WriteLine("Collectibel");
    }
}