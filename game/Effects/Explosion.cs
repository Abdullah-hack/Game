using game.Core;
using game.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace game.Effects
{
    public class Explosion : GameObject
    {
        private int frame = 0;
        private int frameDelay = 2; // faster animation
        private int counter = 0;

        private List<Image> frames = new List<Image>();

        public Explosion(PointF position)
        {
            Position = position;
            Size = new Size(200, 200);

            HasPhysics = false;
            IsRigidBody = false;
            IsActive = true;

            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_0.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_1.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_2.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_3.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_4.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_5.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_6.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_7.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_8.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_9.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_10.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_11.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_12.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_13.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_14.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_15.png"));
            frames.Add(Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\Red Explosion\1_16.png"));
            

            Sprite = frames[0];
        }

        public override void Update(GameTime gameTime)
        {
            counter++;

            if (counter >= frameDelay)
            {
                counter = 0;
                frame++;

                if (frame >= frames.Count)
                {
                    IsActive = false; // remove explosion AFTER animation
                    return;
                }

                Sprite = frames[frame];
            }
        }
    }


}

