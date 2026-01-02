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
    public class Level2Enemy : Enemy
    {
        public Level2Enemy()
        {
            health = 40;
            Size = new SizeF(80, 80);
            fireRate = 80;
            Movement = new PatrolMovement(100, 300);
            Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\enemy\1.png");
        }

        public override void Fire(Game game)
        {
            // Normal downward bullets
            EnemyFire(game);
        }

        public void EnemyFire(Game game)
        {
            Bullet bullet = new Bullet();
            bullet.Owner = this;
            bullet.Velocity = new PointF(0, 20);
            bullet.Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\enemy\enemyBullet.png");
            bullet.Position = new PointF(
                Position.X + Size.Width / 2 - bullet.Size.Width / 2,
                Position.Y + Size.Height + 2
            );

            game.AddObject(bullet);
        }
    }
}
