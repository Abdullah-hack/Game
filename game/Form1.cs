using EZInput;
using game.Core;
using game.Effects;
using game.Entities;
using game.Movements;
using game.Systems;
using System.Numerics;
using System.Resources;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace game
{
    public partial class Form1 : Form
    {
        Game game = new Game();
        Player player = new Player
        {
            Position = new PointF(100, 400),
            Size = new Size(100, 100),
            Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\player\spaceship_enemy.png"),

            Movement = new KeyboardMovement(),
        };
        PhysicsSystem physics = new PhysicsSystem();
        CollisionSystem collisions = new CollisionSystem();
        //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Setting();
            SetupTimer();
        }

        private void SetupTimer()
        {
            timer1.Interval = 16; // ~60 FPS
            //timer.Tick += timer1_Tick_1;
            timer1.Start();
            bgY2 = -background.Height; // second image starts just above the first

        }

        Image playerSprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\player\spaceship_enemy.png");
        Image enemySprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\enemy\1.png");
        Image bullet = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\player\bullet.png");
        Image background = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\background.png");

        float bgY1 = 0;       // top position of first image
        float bgY2;           // top position of second image
        int scrollSpeed = 50;   // speed of background movement

        private void Setting()
        {
            game.AddObject(player
            );

            game.AddObject(new Enemy
            {
                Position = new PointF(300, 200),
                Size = new Size(100, 100),
                Sprite = enemySprite,
                Movement = new PatrolMovement(left: 100, right: 200)
            });

            //game.AddObject(new Enemy
            //{
            //    Position = new PointF(450, 200),
            //    Size = new Size(100, 100),
            //    Sprite = enemySprite,
            //    //HasPhysics = true,
            //    Movement = new PatrolMovement(left: 300, right: 400)
            //});

            //// A physics enabled rigid player — will stop on collision and gravity will be disabled
            //game.AddObject(new Player
            //{
            //    Position = new PointF(250, 350),
            //    Size = new Size(40, 40),
            //    IsRigidBody = true
            //});

            //game.AddObject(new Enemy
            //{
            //    //Position = new PointF(300, 100),
            //    Position = new PointF(30, 10),
            //    Size = new Size(50, 50),
            //    HasPhysics = false // Enable physics with default gravity
            //});
        }

        public void CheckExplosion()
        {
            foreach (var obj in game.Objects.ToList())
            {
                if (obj is Enemy enemy && enemy.IsDead && !enemy.HasExploded)
                {
                    // Spawn explosion
                    Explosion explosion = new Explosion(enemy.Position);
                    game.AddObject(explosion);

                    // Mark explosion done
                    enemy.HasExploded = true;

                    // NOW deactivate enemy
                    enemy.IsActive = false;
                }
            }
        }

        public void ScrollBackGround()
        {
            bgY1 += scrollSpeed;
            bgY2 += scrollSpeed;

            // Reset positions to loop background
            if (bgY1 >= background.Height)
                bgY1 = -background.Height;

            if (bgY2 >= background.Height)
                bgY2 = -background.Height;
        }

        public void ShipAnimation()
        {
            player.tickCount++;
            if (player.tickCount >= player.frameDelay)
            {
                player.tickCount = 0;
                player.currentFrame++;
                if (player.currentFrame >= player.frameCount)
                    player.currentFrame = 0;

                player.Sprite = player.spaceshipFrames[player.currentFrame]; // update the sprite
            }
        }

        public void EnemyFire()
        {
            foreach (var obj in game.Objects.ToList())
            {
                if (obj is Enemy enemy)
                {
                    enemy.FireCounter++;

                    if (enemy.FireCounter >= enemy.FireRate)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            enemy.Fire(game);
                        }
                        enemy.FireCounter = 0;
                    }
                }
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(background, 0, bgY1, ClientSize.Width, background.Height);
            g.DrawImage(background, 0, bgY2, ClientSize.Width, background.Height);
            game.Draw(e.Graphics);
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            game.ScreenSize = ClientSize;

            player.CheckFire(game);

            CheckExplosion();
            // Update all game objects
            game.Update(new GameTime());

            // Apply physics to all objects
            physics.Apply(game.Objects.ToList());

            // Check for collisions between objects
            collisions.Check(game.Objects.ToList());

            // Cleanup objects marked for removal
            game.Cleanup();

            // Redraw the game
            Invalidate();

            ScrollBackGround();

            ShipAnimation();

            EnemyFire();













        }
    }
}
