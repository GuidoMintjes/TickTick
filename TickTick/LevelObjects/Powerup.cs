using System;
using Microsoft.Xna.Framework;
using Engine;

class Powerup : CollectibleObject {


    public Powerup(Level level, Vector2 startPosition) : base(level, startPosition, "Sprites/LevelObjects/Powerup/Apple") { }

    public override void HandleCollision() {

        level.Player.IsSpeeding = true;
    }
}