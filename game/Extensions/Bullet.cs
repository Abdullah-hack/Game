using game.Core;
using game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Extensions
{
    public class Bullet : GameObject
    {
        public GameObject Owner;
        public Bullet()
        {
            //Velocity = new PointF(0, -10); // move upward
            //Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\player\bullet.png");
            Size = new Size(50, 30); // adjust as needed
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Position.Y + Size.Height < 0) // off top of screen
                IsActive = false;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Sprite, Position.X, Position.Y, Size.Width, Size.Height);
        }

        public override void OnCollision(GameObject other)
        {

            //if (other == Owner)
            //    return;

            if (other is Enemy || other is Player)
                IsActive = false;

        }
    }

}
