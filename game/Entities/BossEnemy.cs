using game.Core;
using game.Extensions;
using game.Movements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Entities
{
    public class BossEnemy : Enemy
    {
        public BossEnemy() 
        {
            health = 180;
            Size = new SizeF(160, 180);
            fireRate = 70;
            //Movement = new PatrolMovement(100, 300);
            Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Boss.png");
        }

        public override void Fire(Game game)
        {
            // Normal downward bullets
            RadialFire(game);
        }

        public void RadialFire(Game game)
        {
            float speed = 30f;

            PointF[] directions =
            {
                new PointF(0, 1),   
                new PointF(1, 1),
                new PointF(0.5f, 1),  
                new PointF(-1, 1),
                new PointF(-0.5f, 1),
                new PointF(-1.5f, 1),
                new PointF(1.5f, 1),
                };

            foreach (var dir in directions)
            {
                Bullet bullet = new Bullet();
                bullet.Owner = this;
                bullet.Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\enemy\enemyBullet.png");

                bullet.Velocity = new PointF(dir.X * speed, dir.Y * speed);
                bullet.Position = new PointF(
                    Position.X + Size.Width / 2,
                    Position.Y + Size.Height / 2
                );

                game.AddObject(bullet);
            }




        }


    }


}
