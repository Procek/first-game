using System;

namespace GraProckowa
{
    class Direction
    {
        public static Point2d NextPoint(Point2d current, Point2d target)
        {
            double subX = Math.Abs(target.x - current.x);
            double subY = Math.Abs(target.y - current.y);

            if (subX == 0 && subY == 0)
            {
                return current;
            }

            if (subX >= subY)
            {
                current.x += (int)Math.Round((target.x - current.x) / subX, 0);
                current.y += (int)Math.Round((target.y - current.y) / subX, 0);
                return current;
            }

            current.x += (int)Math.Round((target.x - current.x) / subY, 0);
            current.y += (int)Math.Round((target.y - current.y) / subY, 0);
            return current;
        }

        public static Point2d NextPoint(Point2d current, char keyCheck)
        {
            if (keyCheck == 'w') { current.y--; return current; }
            if (keyCheck == 's') { current.y++; return current; }
            if (keyCheck == 'a') { current.x--; return current; }
            if (keyCheck == 'd') { current.x++; return current; }

            return current;
        }

        public static Course SetCourse(Point2d current, Point2d target)
        {
            Point2d nextPoint = NextPoint(current, target);
            return SetCourseNearPoint(current, nextPoint);
        }

        public static Course SetCourseNearPoint(Point2d current, Point2d nextPoint)
        {
            if (nextPoint.x == current.x && nextPoint.y < current.y) return Course.Up;
            if (nextPoint.x == current.x && nextPoint.y > current.y) return Course.Down;
            if (nextPoint.x < current.x && nextPoint.y == current.y) return Course.Left;
            if (nextPoint.x > current.x && nextPoint.y == current.y) return Course.Right;
            if (nextPoint.x < current.x && nextPoint.y < current.y) return Course.LeftUp;
            if (nextPoint.x > current.x && nextPoint.y < current.y) return Course.RightUp;
            if (nextPoint.x < current.x && nextPoint.y > current.y) return Course.LeftDown;
            if (nextPoint.x > current.x && nextPoint.y > current.y) return Course.RightDown;

            return Course.None;
        }
    }
}
