using game.Core;
using game.Effects;
using game.Extensions;
using game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Entities
{
    public class Enemy : GameObject
    {
        // Optional movement behavior: demonstrates composition and allows testable movement logic.
        public IMovement? Movement { get; set; }

        // Default enemy velocity is set in constructor to give basic movement out-of-the-box.

        public int health = 10;
        public int fireRate = 100;
        public int fireTimer = 0;

        public Enemy()
        {
            //Velocity = new PointF(-2, 0);
        }


        public virtual void Fire(Game game)
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

        /// Update will call movement behavior (if any) and then apply base update to move by velocity.
        public override void Update(GameTime gameTime)
        {

            Movement?.Move(this, gameTime); // movement must be called
            base.Update(gameTime);
            fireTimer++;
        }

        /// Custom draw: demonstrates polymorphism (override base draw to provide enemy visuals).
        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }

        /// On collision, enemy deactivates when hit by bullets (encapsulation of reaction logic inside the entity).

        public override void OnCollision(GameObject other)
        {
            if (other is Bullet bullet && bullet.Owner is Enemy)
            {
                return;
            }
            if (other is Bullet)
            {
                TakeDamage(1); 
            }
        }

        public virtual void TakeDamage(int damage)
        {
            health -= damage;
        }

    }
}
