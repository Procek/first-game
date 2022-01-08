namespace GraProckowa
{
    struct Point2d
    {
        public int x;
        public int y;
        int container;

        public Point2d(int x, int y)
        {
            this.x = x;
            this.y = y;
            container = 0;
        }

        public void Reverse()
        {
            container = x;
            x = y;
            y = container;
        }
    }

    public class Vector
    {
        public float x;
        public float y;

        public Vector()
        {
            x = Zero().x;
            y = Zero().y;
        }

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector Zero()
        {
            return new Vector(0, 0);
        }
    }
}