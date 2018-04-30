using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenseless.Geometry;

namespace Example
{
    public class Asteroid
    {
        public Circle shape;
        public Vector2 direction;
        private static Random rand = new Random();
        public int life;

        public Asteroid(int life_)
        {
            life = life_;
            var randX = rand.NextDouble() * 2d - 1d;
            var randY = rand.NextDouble() /-2d -0.5d;

            direction = new Vector2((float)randX, (float)randY);

            var posX = rand.NextDouble() * 2d - 1d;
            var posY = 1.2;
            shape = new Circle((float)posX, (float)posY, 0.2f);
        }
        public List<Asteroid> BreakAsteroid()
        {
            var result = new List<Asteroid>();
            result.Add(new Asteroid(life - 1));
            result.Add(new Asteroid(life - 1));
            return result;
        }
    }

}
