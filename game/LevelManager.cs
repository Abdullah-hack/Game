using game.Core;
using game.Effects;
using game.Entities;
using game.Interfaces;
using game.Movements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace game
{
    public class LevelManager
    {
        public int level = 1;
        public Game game;

        public LevelManager(Game game)
        {
            this.game = game;
        }

        public void LoadLevel()
        {
            if (level == 1)
            {
                SpawnLevel1();
            }
            else if (level == 2)
            {
                SpawnLevel2();
            }
            else if (level == 3)
            {
                SpawnBossLevel();
            }
        }

        public void NextLevel()
        {
            level++;    
        }
        //gameObjects.Any(obj => obj is Enemy)

        public bool CheckLevelComplete()
        {
            if (!game.Objects.Any(obj => obj is Enemy enemy && enemy.IsActive) && !game.Objects.Any(obj => obj is Explosion exp && exp.IsActive))
                return true;
            else 
                return false;
        }

        public void SpawnLevel1()
        {
            int startY = -100;

            for (int i = 1; i < 4; i++)
            {
                float x = i * 90;
                float targetY = i * 50;

                Level1Enemy enemy = new Level1Enemy();
                enemy.Position = new PointF(x, startY);
                enemy.Velocity = new PointF(i * 2, 0);

                IMovement patrol = new PatrolMovement(left: i * 100, right: i * 300);

                enemy.Movement = new EntryMovement(targetY, speed: 2f, nextMovement: patrol);

                game.AddObject(enemy);
            }

        }

        public void SpawnLevel2()
        {
            int startY = -100;

            game.AddObject(new Level2Enemy
            {
                Position = new PointF(200, startY),
                Velocity = new PointF(0, 0),
                Movement = new EntryMovement(100, 2f, new ZigZagMovement(100, 400, 50)),
            });

            game.AddObject(new Level2Enemy
            {
                Position = new PointF(300, startY),
                Velocity = new PointF(0, 0),
                Movement = new EntryMovement(50, 2f, new ZigZagMovement(100, 700, 40)),
            });

            game.AddObject(new Level2Enemy
            {
                Position = new PointF(450, startY),
                Velocity = new PointF(0, 0),
                Movement = new EntryMovement(50, 2f, new ZigZagMovement(50, 800, 20)),
            });
        }

        public void SpawnBossLevel()
        {
            game.AddObject(new BossEnemy
            {
                Position = new PointF(400, -100),
                Velocity = new PointF(0, 0),
                Movement = new EntryMovement(100, 2f, new ZigZagMovement(50, 900, 60)),
            });
        } 


    }
}
