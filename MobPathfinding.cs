using System;

namespace GraProckowa
{
    static class MobPathfinding
    {
        public static Point2d Move(Point2d currentXY, Point2d targetXY, Location location)
        {
            Point2d startingPointXY = currentXY;

            if (Math.Abs(currentXY.x - targetXY.x) >= Math.Abs(currentXY.y - targetXY.y))
            {
                MoveOnLinearFunction(ref currentXY, ref targetXY);
            }
            else
            {
                currentXY.Reverse();
                targetXY.Reverse();

                MoveOnLinearFunction(ref currentXY, ref targetXY);

                currentXY.Reverse();
            }

            return Pathfinding(ref startingPointXY, ref currentXY, location);
        }

        static Point2d Pathfinding(ref Point2d startingPointXY, ref Point2d currentXY, Location location)
        {
            if (IsObstacle(location.area[currentXY.x, startingPointXY.y, 2]) && location.area[startingPointXY.x, currentXY.y, 2] == 0)
            {
                currentXY.x = startingPointXY.x; //avoiding corner
                return currentXY;
            }
            else if (IsObstacle(location.area[startingPointXY.x, currentXY.y, 2]) && location.area[currentXY.x, startingPointXY.y, 2] == 0)
            {
                currentXY.y = startingPointXY.y; //avoiding corner
                return currentXY;
            }

            if ((IsObstacle(location.area[currentXY.x, startingPointXY.y, 2]) && location.area[startingPointXY.x, currentXY.y, 2] != 0) ||  //cel na ukos, góra i dół zablokowane
                (IsObstacle(location.area[startingPointXY.x, currentXY.y, 2]) && location.area[currentXY.x, startingPointXY.y, 2] != 0))    //uporządkować
            {
                return startingPointXY;
            }

            if (location.area[currentXY.x, currentXY.y, 2] != 0)
            {
                return startingPointXY; //przezroczysta przeszkoda na linii prostej do celu (pathfinding do zrobienia)
            }
            return currentXY;
        }

        static void MoveOnLinearFunction(ref Point2d currentXY, ref Point2d targetXY)
        {
            if (!(currentXY.x == targetXY.x && currentXY.y == targetXY.y))
            {
                double a = (double)(-(targetXY.y - currentXY.y)) / (currentXY.x - targetXY.x);
                double b = (double)(currentXY.x * targetXY.y - targetXY.x * currentXY.y) / (currentXY.x - targetXY.x);

                currentXY.x += currentXY.x < targetXY.x ? 1 : -1;
                currentXY.y = (int)Math.Round(a * currentXY.x + b, 0);
            }
        }

        static bool IsObstacle(int valueOnArea)
            => valueOnArea >= 1000 /*20001*/ && valueOnArea <= 22000;
    }
}