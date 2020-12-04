namespace Shared.Vectors
{
    public struct Vector2D
    {
        public int x;
        public int y;

        public Vector2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2) => new Vector2D(v1.x + v2.x, v1.y + v2.y);
    }
}
