using EZInput;
using game.Core;
using game.Effects;
using game.Entities;
using game.Movements;
using game.Systems;
using System.Numerics;
using System.Resources;
using System.Security.Policy;
using game.Sounds;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace game
{
    public partial class Form1 : Form
    {

        Game game = new Game();
        LevelManager levelManager;
        FileHelper fileHelper;

        PhysicsSystem physics = new PhysicsSystem();
        CollisionSystem collisions = new CollisionSystem();

        Image background = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\background.png");

        Player player = new Player
        {
            Position = new PointF(650, 800),
            Size = new Size(80, 110),
            Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\player\spaceship_enemy.png"),

            Movement = new KeyboardMovement(),
        };

        float bgY1 = 0;       // top position of first image
        float bgY2;           // top position of second image
        int scrollSpeed = 50;   // speed of background movement



        public Form1(bool startNewGame)
        {
            InitializeComponent();

            levelManager = new LevelManager(game);
            fileHelper = new FileHelper();

            DoubleBuffered = true;
            SetupTimer();

            if (startNewGame)
            {
                player.Score = 0;
                levelManager.level = 1;
            }
            else
            {
                List<string> list = fileHelper.Load();
                player.Score = int.Parse(list[0]);
                levelManager.level = int.Parse(list[1]);
            }            
            Setting();
        }



        private void SetupTimer()
        {
            timer1.Interval = 16;
            timer1.Start();
        }


        private void Setting()
        {
            game.AddObject(player);

            bgY2 = -background.Height; // second image starts just above the first
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1080, 920);   // game resolution
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            levelManager.LoadLevel();
            SoundManager.PlayMusic(@"D:\smester 2\OOP\game\game\game\Resources\sounds\bg_music.mp3");
        }

        public void CheckExplosion()
        {
            foreach (var obj in game.Objects.ToList())
            {
                if (obj is Enemy enemy && enemy.health <= 0)
                {
                    if (enemy is BossEnemy)
                    {
                        Explosion exp = new Explosion(enemy.Position, " ");
                        game.AddObject(exp);
                    }
                    else
                    {
                        Explosion explosion = new Explosion(enemy.Position);
                        game.AddObject(explosion);
                    }

                    SoundManager.PlayEffect(@"D:\smester 2\OOP\game\game\game\Resources\sounds\explosion.mp3");

                    enemy.IsActive = false;
                    player.Score += 50;
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

                player.Sprite = player.spaceshipFrames[player.currentFrame];
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
            DrawHUD(g);
        }


        private void DrawHUD(Graphics g)
        {
            Font font = new Font("Arial", 16, FontStyle.Bold);
            Brush brush = Brushes.White;

            g.DrawString($"Score: {player.Score}", font, brush, 20, 20);
            g.DrawString($"Health: {player.Health}", font, brush, 20, 50);
            g.DrawString($"Level: {levelManager.level}", font, brush, 20, 80);
        }


        private void GameOver()
        {
            if (player.Health <= 0)
            {
                fileHelper.Save(player.Score, levelManager.level);
                GameOver gameOver = new GameOver();
                gameOver.Show();
                Close();
                //MessageBox.Show("Game Over!");
            }
        }


        private void CheckLevelComplete()
        {
            if (!levelManager.CheckLevelComplete())
                return;

            timer1.Stop();

            int nextLevel;

            // Decide next level
            if (levelManager.level == 3) // Boss completed
            {
                nextLevel = 1;
                fileHelper.Save(player.Score, nextLevel);
                GameOver gameOver = new GameOver();
                gameOver.Show();
                Close();
                return;
            }
            else
                nextLevel = levelManager.level + 1;

            // SAVE progress IMMEDIATELY
            fileHelper.Save(player.Score, nextLevel);

            LevelCompleteForm levelForm =
                new LevelCompleteForm(player.Score);

            DialogResult result = levelForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                levelManager.level = nextLevel;
                levelManager.LoadLevel();
                timer1.Start();
            }
            else if (result == DialogResult.Retry)
            {
                MainForm main = new MainForm();
                main.Show();
                Close();
            }
        }






        private void timer1_Tick_1(object sender, EventArgs e)
        {
            game.ScreenSize = ClientSize;

            player.CheckFire(game);

            CheckExplosion();
            
            game.Update(new GameTime());   // Update all game objects
            
            physics.Apply(game.Objects.ToList());   // Apply physics to all objects
            
            collisions.Check(game.Objects.ToList());   // Check for collisions between objects

            game.Cleanup();   // Cleanup objects marked for removal

            CheckLevelComplete();

            GameOver();

            EnemyFire();

            ScrollBackGround();

            ShipAnimation();
         
            Invalidate();   // Redraw the game

        }
    }
}
