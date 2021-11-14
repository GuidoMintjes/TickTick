using Microsoft.Xna.Framework;
using System;

namespace Engine
{
    /// <summary>
    /// An object that can make another object visible for a certain amount of time.
    /// </summary>
    public class Timer : GameObject
    {
        protected GameObject target;
        protected float timeLeft;

        /// <summary>
        /// Creates a new VisibilityTimer with the given target object.
        /// </summary>
        /// <param name="target">The game object whose visibility you want to manage.</param>
        public Timer(GameObject target)
        {
            timeLeft = 0;
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {
            // if the timer has already passed earlier, don't do anything
            if (timeLeft <= 0)
                return;

            // if enough time has passed, make the target object invisible
            timeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeLeft <= 0)
                HandleTimerEnd();
        }

        /// <summary>
        /// Makes the target object visible, and starts a timer for the specified number of seconds.
        /// </summary>
        /// <param name="seconds">How long the target object should be visible.</param>
        public void StartTimer(float seconds)
        {
            timeLeft = seconds;
            //target.Visible = true;
        }


        public virtual void HandleTimerEnd() {

            //Console.WriteLine("Main timer used!");
            //target.Visible = false;
        }
    }
}