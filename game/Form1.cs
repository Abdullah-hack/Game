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
        LevelManager levelManager;

        PhysicsSystem physics = new PhysicsSystem();
        CollisionSystem collisions = new CollisionSystem();
        Image background = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\background.png");

        Player player = new Player
        {
            Position = new PointF(100, 400),
            Size = new Size(100, 100),
            Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\player\spaceship_enemy.png"),

            Movement = new KeyboardMovement(),
        };

        float bgY1 = 0;       // top position of first image
        float bgY2;           // top position of second image
        int scrollSpeed = 50;   // speed of background movement



        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Setting();
            SetupTimer();
            levelManager = new LevelManager(game);
            levelManager.LoadLevel();
        }

        private void SetupTimer()
        {
            timer1.Interval = 16;
            timer1.Start();
            bgY2 = -background.Height; // second image starts just above the first
        }


        private void Setting()
        {
            game.AddObject(player);
        }

        public void CheckExplosion()
        {
            foreach (var obj in game.Objects.ToList())
            {
                if (obj is Enemy enemy && enemy.health <= 0)
                {
                    // Spawn explosion
                    Explosion explosion = new Explosion(enemy.Position);
                    game.AddObject(explosion);

                    // Mark explosion done

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
                    enemy.fireTimer++;

                    if (enemy.fireTimer >= enemy.fireRate)
                    {
                        enemy.Fire(game);
                        enemy.fireTimer = 0;
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


            EnemyFire();

            ScrollBackGround();

            ShipAnimation();

            // Redraw the game
            Invalidate();

        }
    }
}
