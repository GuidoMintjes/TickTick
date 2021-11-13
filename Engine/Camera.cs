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

            Point newPos = new Point((int) ((float) CameraWindow.X + (camPosChanger.LocalPosition.X - camPosChanger.previousPosition.X)),
                                        (int) ((float) CameraWindow.Y + (camPosChanger.LocalPosition.Y - camPosChanger.previousPosition.Y)));
            
            Rectangle newCameraWindow = new Rectangle(newPos.X, newPos.Y, CameraWindow.Width, CameraWindow.Height);

            CameraWindowChange = new Point(newCameraWindow.X - CameraWindow.X, newCameraWindow.Y - CameraWindow.Y);

            if (CameraWindowChange.X != 0 || CameraWindowChange.Y != 0) {

                Console.WriteLine($"{CameraWindow.Width} --- {CameraWindow.Height}");
                Console.WriteLine();
                Console.WriteLine($"{worldSize.X} --- {worldSize.Y}");
                Console.WriteLine();
            }

            // Limit the camera view to the world
            Math.Clamp(newCameraWindow.X, 0f, worldSize.X - CameraWindow.Width);
            Math.Clamp(newCameraWindow.Y, 0f, worldSize.Y - CameraWindow.Height);

            CameraWindow = newCameraWindow;
        }
    }
}