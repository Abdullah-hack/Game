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
    public class EntryMovement : IMovement
    {
        private float targetY;
        private float speed;
        private IMovement nextMovement;

        public EntryMovement(float targetY, float speed, IMovement nextMovement)
        {
            this.targetY = targetY;
            this.speed = speed;
            this.nextMovement = nextMovement;
        }

        public void Move(GameObject obj, GameTime gameTime)
        {
            obj.Position = new PointF(obj.Position.X, obj.Position.Y + speed);

            if (obj.Position.Y >= targetY)
            {
                obj.Position = new PointF(obj.Position.X, targetY);

                if (obj is Enemy enemy)
                    enemy.Movement = nextMovement; // switch movement
            }
        }
    }

}
