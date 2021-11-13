using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Engine {
    
    public class Camera : GameObject {

        Point worldSize; 
        static Point windowSize;
        public static Point CameraWindowChange { get; private set; }

        public static Rectangle CameraWindow { get; private set; }

        GameObject camPosChanger;

        public Camera(Point worldSize, Point newWindowSize, GameObject _camPosChanger) {

            camPosChanger = _camPosChanger;

            this.worldSize = worldSize;
            windowSize = newWindowSize;

            CameraWindow = new Rectangle(0, 0, windowSize.X, windowSize.Y);
        }

        public override void Update(GameTime gameTime) {

            Point newPos = new Point(CameraWindow.X + (int) (camPosChanger.LocalPosition.X - camPosChanger.previousPosition.X),
                                        CameraWindow.Y + (int) (camPosChanger.LocalPosition.Y - camPosChanger.previousPosition.Y));
            
            Rectangle newCameraWindow = new Rectangle(newPos.X, newPos.Y, newPos.X + windowSize.X, newPos.Y + windowSize.Y);

            CameraWindowChange = new Point(newCameraWindow.X - CameraWindow.X, newCameraWindow.Y - CameraWindow.Y);

            CameraWindow = newCameraWindow;

            // Limit the camera view to the world
            Math.Clamp(CameraWindow.X, 0f, worldSize.X);
            Math.Clamp(CameraWindow.Y, 0f, worldSize.Y);
        }
    }
}