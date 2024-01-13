using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Entity
    {
        public Vector2 pos = new Vector2(), vel = new Vector2();

        public Entity()
        {

        }

        public void Tick()
        {
            
        }

        public void Render()
        {
            pos.Y -= 1f;
            pos.X += 1f;
        }
    }
}
