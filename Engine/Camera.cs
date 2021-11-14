using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Engine {
    
    public class Camera : GameObject {


        public static bool alive = false; //TODO: Un-static?

        private static Point cameraPos, desiredCameraPosition;

        private Rectangle WorldRectangle { get; set; }

        private Point windowSize;

        public Camera(Point windowSize, Rectangle levelSize) {

            this.windowSize = windowSize;
            WorldRectangle = levelSize;

            desiredCameraPosition = Point.Zero;

            alive = true;

            Reset();
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

        public void Reset() {

            cameraPos = new Point(0, 0);
        }

        /*
        Point worldSize;
        Point windowSize;

        SpriteGameObject camPosChanger;

        public static Vector2 cameraChange;

        public static bool alive = false; //TODO: Un-static?

        Vector4 camOffset;

        public static Matrix Transform { get; set; }

        public Camera(Point _worldSize, Point newWindowSize, SpriteGameObject _camPosChanger, Vector4 _offset) {

            camPosChanger = _camPosChanger;

            Transform = new Matrix();

            camOffset = _offset;

            worldSize = _worldSize;
            windowSize = newWindowSize;

            alive = true;
        }

        public override void Update(GameTime gameTime) {

            float newCamPosX = -camPosChanger.GlobalPosition.X - (camPosChanger.BoundingBox.Width / 2);
            float newCamPosY = -camPosChanger.GlobalPosition.Y - (camPosChanger.BoundingBox.Height / 2);

            newCamPosX = Math.Clamp(newCamPosX, -(worldSize.X - (windowSize.X / 2) + camOffset.W - camOffset.W * 1/1.15f), camOffset.X * 1.15f); //TODO: UNMAGIC
            newCamPosY = Math.Clamp(newCamPosY, -700f, 0f);

            Matrix position = Matrix.CreateTranslation(new Vector3(newCamPosX, newCamPosY, 0f));

            Matrix offset = Matrix.CreateTranslation(new Vector3(
                windowSize.X / 1.75f,
                windowSize.Y / 1.75f,
                0));

            position.M44 = 1.15f; //TODO: UNMAGIC

            Matrix newTransform = position * offset;

            cameraChange = new Vector2(newTransform.M41 - Transform.M41, newTransform.M42 - Transform.M42);

            Transform = newTransform;
        }


        public void Reset() {

            Transform = new Matrix(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
        }
        */
    }
}