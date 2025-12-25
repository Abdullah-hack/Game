using game.Core;
using game.Entities;
using game.Movements;
using game.Systems;
using System.Resources;

namespace game
{
    public partial class Form1 : Form
    {
        Game game = new Game();
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
        }
        Image playerSprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\player.png");
        private void Setting()
        {
            game.AddObject(new Player
            {
                Position = new PointF(100, 200),
                Size = new Size(100, 100),
                Sprite = playerSprite,

                Movement = new KeyboardMovement(),
            });

            game.AddObject(new Player
            {
                Position = new PointF(250, 100),
                Size = new Size(100, 100),
                //HasPhysics = true,
                Movement = new PatrolMovement(left: 100, right: 500)
            });

            // A physics enabled rigid player — will stop on collision and gravity will be disabled
            game.AddObject(new Player
            {
                Position = new PointF(250, 350),
                Size = new Size(40, 40),
                IsRigidBody = true
            });

            game.AddObject(new Enemy
            {
                //Position = new PointF(300, 100),
                Position = new PointF(30, 10),
                Size = new Size(50, 50),
                HasPhysics = false // Enable physics with default gravity
            });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
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

        }
    }
}
