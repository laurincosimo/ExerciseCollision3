using Zenseless.Geometry;

namespace Example
{
    public class Player
    {
        public bool isInvincible;
        public Circle shape;

        public Player()
        {
            shape = new Circle(0.0f, -0.85f, 0.05f);
            isInvincible = false;
        }
    }
}