using System;
using Microsoft.Xna.Framework;
using Engine;

class Powerup : CollectibleObject {

    public Powerup(Level level, Vector2 startPosition) : base(level, startPosition, "Sprites/LevelObjects/Powerup/Apple") { }

    public override void HandleCollision() {

        Visible = false;
        level.Player.ToggleSpeeding(true);

        level.SpeedTimer.StartTimer(3f);    //TODO UNMAGIC THIS NUMBER
    }
}