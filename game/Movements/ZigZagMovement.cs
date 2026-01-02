using game.Core;
using game.Entities;
using game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Movements
{
    public class ZigZagMovement : IMovement
    {
        private float leftBound;
        private float rightBound;

        private float speedX = 6f;
        private float speedY = 3f;

        private int dirY = 1;        // up/down
        private float baseY;         // center Y
        private float zigzagHeight;  // vertical range

        public ZigZagMovement(float left, float right, float zigzagHeight = 40f)
        {
            leftBound = left;
            rightBound = right;
            this.zigzagHeight = zigzagHeight;
        }

        public void Move(GameObject obj, GameTime gameTime)
        {
            // Initialize baseY once
            if (baseY == 0)
                baseY = obj.Position.Y;

            // Horizontal patrol
            obj.Position = new PointF(
                obj.Position.X + speedX,
                obj.Position.Y + speedY * dirY
            );

            // X bounds bounce
            if (obj.Position.X <= leftBound)
            {
                obj.Position = new PointF(leftBound, obj.Position.Y);
                speedX = Math.Abs(speedX);
            }
            else if (obj.Position.X >= rightBound)
            {
                obj.Position = new PointF(rightBound, obj.Position.Y);
                speedX = -Math.Abs(speedX);
            }

            // Zigzag Y movement
            if (obj.Position.Y >= baseY + zigzagHeight)
                dirY = -1;
            else if (obj.Position.Y <= baseY - zigzagHeight)
                dirY = 1;
        }
    }



}
