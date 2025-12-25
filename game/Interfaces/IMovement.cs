using game.Core;
using game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Interfaces
{
    public interface IMovement
    {
        void Move(GameObject obj, GameTime gameTime);
    }
}
