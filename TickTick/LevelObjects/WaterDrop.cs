using System;
using Microsoft.Xna.Framework;
using Engine;

class WaterDrop : CollectibleObject {

    public WaterDrop(Level level, Vector2 startPosition) : base(level, startPosition, "Sprites/LevelObjects/spr_water") { }

    public virtual void MoveDrop(GameTime gametime) { }

    public override void HandleCollision() {

        Console.WriteLine("Water");
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