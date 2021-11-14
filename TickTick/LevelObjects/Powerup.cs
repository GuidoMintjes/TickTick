using System;
using Microsoft.Xna.Framework;
using Engine;

class Powerup : CollectibleObject {

    const float powerUpTime = 3f;

    public Powerup(Level level, Vector2 startPosition) : base(level, startPosition, "Sprites/LevelObjects/Powerup/Apple") { }

    public override void HandleCollision() {

        Visible = false;
        level.Player.SetSpeeding(true);

        level.SpeedTimer.StartTimer(powerUpTime);
    }
}