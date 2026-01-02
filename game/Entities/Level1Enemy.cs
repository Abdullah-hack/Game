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
    public class Level1Enemy : Enemy
    {
        public Level1Enemy()
        {
            health = 30;
            Size = new SizeF(90, 90);
            fireRate = 120;
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
            bullet.Velocity = new PointF(0, 40);
            bullet.Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\enemy\enemyBullet.png");
            bullet.Position = new PointF(
                Position.X + Size.Width / 2 - bullet.Size.Width / 2,
                Position.Y + Size.Height + 2
            );

            game.AddObject(bullet);
        }
    }
}
