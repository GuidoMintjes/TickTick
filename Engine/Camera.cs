using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Engine {
    
    public class Camera : GameObject {

        Point worldSize; 
        Point windowSize;

        public static Point CameraWindowChange { get; private set; } //TODO: Un-static

        static Rectangle CameraWindow { get; set; }

        SpriteGameObject camPosChanger;

        public static bool alive = false; //TODO: Un-static?

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

        public override void Update(GameTime gameTime) {

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
    }
}