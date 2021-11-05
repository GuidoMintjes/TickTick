using System;
using Microsoft.Xna.Framework;
using Engine;

class WaterDrop : SpriteGameObject {
    Level level;
    protected float bounce;
    Vector2 startPosition;
    protected float counter = 10;
    public static Random rng = new Random();

    public WaterDrop(Level level, Vector2 startPosition) : base("Sprites/LevelObjects/spr_water", TickTick.Depth_LevelObjects) {
        this.level = level;
        this.startPosition = startPosition;

        SetOriginToCenter();

        Reset();
    }

    public virtual void MoveDrop(GameTime gametime) {


    }

    public override void Update(GameTime gameTime) {
        base.Update(gameTime);

        MoveDrop(gameTime);

        double t = gameTime.TotalGameTime.TotalSeconds * 3.0f + LocalPosition.X;
        bounce = (float)Math.Sin(t) * 0.2f;
        localPosition.Y += bounce;

        // check if the player collects this water drop
        if (Visible && level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player)) {
            Visible = false;
            ExtendedGame.AssetManager.PlaySoundEffect("Sounds/snd_watercollected");
        }

    }

    public override void Reset() {
        localPosition = startPosition;
        Visible = true;
    }

}
 class WobblyDrop : WaterDrop {

    public WobblyDrop(Level level, Vector2 startPosition) : base(level, startPosition) {

        velocity = new Vector2(-2, 0);
    }

    public override void MoveDrop(GameTime gameTime) {

        counter -= 1;

        if (counter <= 0) {

            velocity *= -1;
            counter = 10;
        }

            localPosition += velocity;
    }
}
class RisingDrop : WaterDrop {

    int counterTwo;

    public RisingDrop(Level level, Vector2 startPosition) : base(level, startPosition) {

        counterTwo = rng.Next(100, 201);
    }

    public override void MoveDrop(GameTime gameTime) {

        counterTwo -= 1;

        if (counterTwo <= 0) {

            counterTwo = rng.Next(100, 201);
            localPosition -= new Vector2(0, 20);
        }
    }
}