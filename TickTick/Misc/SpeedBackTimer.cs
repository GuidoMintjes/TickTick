using System;
using System.Collections.Generic;
using System.Text;
using Engine;

class SpeedBackTimer : Timer {

    Level level;

    public SpeedBackTimer(Level level) : base(level) {

        this.level = level;
    }

    public override void HandleTimerEnd() {

        level.Player.ToggleSpeeding(false);
    }
}