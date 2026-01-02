using EZInput;
using game.Core;
using game.Extensions;
using game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Entities
{
    public class Player : GameObject
    {
        // Movement strategy: demonstrates composition over inheritance.
        // Different movement behaviors can be injected (KeyboardMovement, PatrolMovement, etc.).
        public List<Image> spaceshipFrames = new List<Image>();
        public int currentFrame = 0;
        public int frameCount;
        public int frameDelay = 5; // how many ticks per frame
        public int tickCount = 0;

        public Player()
        {
            spaceshipFrames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Animation\1.png"));
            spaceshipFrames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Animation\2.png"));
            spaceshipFrames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Animation\3.png"));
            spaceshipFrames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Animation\4.png"));

            frameCount = spaceshipFrames.Count;

        }

        public IMovement? Movement { get; set; }

        public Size ScreenSize { get; set; }


        // Domain state
        public int Health { get; set; } = 100;
        public int Score { get; set; } = 0;

        public void KeepInsideBounds(Size screenSize)
        {
            float x = Position.X;
            float y = Position.Y;

            if (x < 0) x = 0;
            if (y < 0) y = 0;

            if (x + Size.Width > screenSize.Width)
                x = screenSize.Width - Size.Width;

            if (y + Size.Height > screenSize.Height)
                y = screenSize.Height - Size.Height;

            Position = new PointF(x, y);
        }

       public void Fire(Game game)
       {
            Bullet bullet = new Bullet();
            bullet.Owner = this;
            bullet.Velocity = new PointF(0,  -30);
            bullet.Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\player\bullet.png");
            bullet.Position = new PointF(
            Position.X + Size.Width / 2 - bullet.Size.Width / 2, // center horizontally
            Position.Y - bullet.Size.Height - 2                       // spawn above the player
            );

            game.AddObject(bullet);
        }

        public void CheckFire(Game game)
        {
            if (EZInput.Keyboard.IsKeyPressed(Key.Space))
            {
                Fire(game);
            }
        }


        /// Update the player: delegate movement to the Movement strategy (if provided) and then apply base update.
        /// Shows the Strategy pattern (movement behavior varies independently from Player class).
        public override void Update(GameTime gameTime)
        {
            Movement?.Move(this, gameTime);
            KeepInsideBounds(ScreenSize);
            base.Update(gameTime);
        }

        //if (Movement != null)
        //{
        //    Movement.Move(this, gameTime);
        //}

        /// Draw uses base implementation; override if player needs custom visuals.

        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }

        /// Collision reaction for the player. Demonstrates single responsibility: domain reaction is handled here.
        public override void OnCollision(GameObject other)
        {
            if (other is Enemy)
                Health -= 10;
            if (other is Bullet bullet && bullet.Owner is Enemy)
                Health -= 10;
            

            //if (other is PowerUp)
            //    Health += 20;
        }
    }
}
