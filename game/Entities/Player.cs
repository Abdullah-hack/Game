using game.Core;
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

            //if (other is PowerUp)
            //    Health += 20;
        }
    }
}
