using EZInput;
using game.Core;
using game.Entities;
using game.Interfaces;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game.Movements
{
    public class KeyboardMovement : IMovement
    {
        public float Speed { get; set; } = 15f;

        public void Move(GameObject obj, GameTime gameTime)
        {
            if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                obj.Position = new PointF(obj.Position.X - Speed, obj.Position.Y);

            if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                obj.Position = new PointF(obj.Position.X + Speed, obj.Position.Y);

            if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                obj.Position = new PointF(obj.Position.X, obj.Position.Y - Speed);

            if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                obj.Position = new PointF(obj.Position.X, obj.Position.Y + Speed);
        }
    }
}
