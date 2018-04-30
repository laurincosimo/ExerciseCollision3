using OpenTK;
using System;
using Zenseless.Geometry;

namespace Example
{
    public class Bullet
    {
        public Circle shape;
        public Vector2 direction;
        private static Random rand = new Random();

        public Bullet(float posX, float posY, float rad)
        {
            var dirX = rand.NextDouble() / 5 - 0.1f;
            shape = new Circle(posX, posY, rad);
            direction = new Vector2((float)dirX, 2);
        }
    }
}