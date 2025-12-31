using game.Core;
using game.Entities;
using game.Movements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                
            }
            else if (level == 3)
            {
                
            }
        }

        public void NextLevel()
        {
            level++;
        }
        //gameObjects.Any(obj => obj is Enemy)

        public void CheckLevelComplete()
        {
            if (!game.Objects.Any(obj => obj is Enemy))
                NextLevel();
        }

        public void SpawnLevel1()
        {
            game.AddObject(new BossEnemy());

            //for (int i = 0; i < 4; i++)
            //{
            //    game.AddObject(new Enemy
            //    {
            //        Position = new PointF(i * 100, 200),
            //        Size = new Size(100, 100),
            //        Sprite = Image.FromFile(@"D:\smester 2\OOP\game\game\game\Resources\enemy\1.png"),
            //        Movement = new PatrolMovement(left: i * 100, right: i * 110)
            //    });
            //}
        }


    }
}
