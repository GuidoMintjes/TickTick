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

        SpriteGameObject camPosChanger;

        public static bool alive = false;

        Vector4 camOffset;

        public static Matrix Transform { get; set; }

        public Camera(Point _worldSize, Point newWindowSize, SpriteGameObject _camPosChanger, Vector4 _offset) {

            camPosChanger = _camPosChanger;

            camOffset = _offset;

            worldSize = _worldSize;
            windowSize = newWindowSize;

            CameraWindow = new Rectangle(0, 0, windowSize.X, windowSize.Y);

            alive = true;

        }

        public void followPlayer() {

            // Limit the camera view to the world
            //Math.Clamp(newCameraWindow.X, 0f, worldSize.X - CameraWindow.Width);
            //Math.Clamp(newCameraWindow.Y, 0f, worldSize.Y - CameraWindow.Height);

            float newCamPosX = -camPosChanger.GlobalPosition.X - (camPosChanger.BoundingBox.Width / 2);
            float newCamPosY = -camPosChanger.GlobalPosition.Y - (camPosChanger.BoundingBox.Height / 2);

            Console.WriteLine($"X: {newCamPosX} ;;; Y: {newCamPosY}");

            newCamPosX = Math.Clamp(newCamPosX, -(worldSize.X - (CameraWindow.Width / 2) + camOffset.W), camOffset.X);
            newCamPosY = Math.Clamp(newCamPosY, -700f, 0f);

            Console.WriteLine($"X: {newCamPosX} ;;; Y: {newCamPosY}");
            Console.WriteLine();

            Matrix position = Matrix.CreateTranslation(new Vector3(newCamPosX, newCamPosY, 0f));

            Matrix offset = Matrix.CreateTranslation(new Vector3(
                windowSize.X / 1.75f,
                windowSize.Y / 1.75f,
                0));

            Transform = position * offset;
        }

        public override void Update(GameTime gameTime) {

            followPlayer();

            /*

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

            */


            
        }
    }
}