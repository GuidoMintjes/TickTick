using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Engine {
    public class Camera : GameObject {

        public static bool alive = false; //TODO: Un-static?

        private static Point cameraPos;

        private Point windowSize;

        private Rectangle WorldRectangle { get; set; }

        public Camera(Point windowSize, Rectangle levelSize) {

            this.windowSize = windowSize;
            WorldRectangle = levelSize;

            alive = true;

            CamReset();
        }


        /// <summary>
        /// Moves the camera object by an amount of pixels
        /// </summary>
        /// <param name="p">Amount of pixels to move the camera in the x and y axes</param>
        public void MoveCamera(Point p) {

            int newX = cameraPos.X + windowSize.X + p.X;
            int newY = cameraPos.Y + windowSize.Y + p.Y;

            if (cameraPos.X + p.X >= 0 && cameraPos.Y + p.Y <= 0) {

                if (newX + 416 <= WorldRectangle.Right && newY <= WorldRectangle.Bottom) {

                    cameraPos.X += p.X;
                    cameraPos.Y += p.Y;
                }
            }
        }


        /// <summary>
        /// Returns a Vector2 that holds camera X and Y values
        /// </summary>
        /// <returns>Vector2 that holds X and Y value of the top left pixel that the window will show</returns>
        public static Vector2 GetCameraPosition() {

            return new Vector2(cameraPos.X, cameraPos.Y);
        }


        public void CamReset() {

            cameraPos = new Point(0, 0);
        }
    }
}