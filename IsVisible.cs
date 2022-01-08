using System;

namespace GraProckowa
{
    static class IsVisible
    {
        public static bool Check(Point2d observer, Point2d target, Location location)
        {
            double linearFuncParamA;
            double linearFuncParamB;

            if (Math.Abs(observer.x - target.x) >= Math.Abs(observer.y - target.y))
            {
                linearFuncParamA = (double)(-(target.y - observer.y)) / (observer.x - target.x);
                linearFuncParamB = (double)(observer.x * target.y - target.x * observer.y) / (observer.x - target.x);
            }
            else
            {
                observer.Reverse();
                target.Reverse();

                linearFuncParamA = (double)(-(target.y - observer.y)) / (observer.x - target.x);
                linearFuncParamB = (double)(observer.x * target.y - target.x * observer.y) / (observer.x - target.x);

                observer.Reverse();
                target.Reverse();
            }

            if (Math.Abs(observer.x - target.x) >= Math.Abs(observer.y - target.y))
            {
                while (!(observer.x == target.x && observer.y == target.y))
                {
                    observer.x += observer.x < target.x ? 1 : -1;
                    observer.y = (int)Math.Round(linearFuncParamA * observer.x + linearFuncParamB, 0);

                    if (IsOpaque(location.area[observer.x, observer.y, 2]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                while (!(observer.x == target.x && observer.y == target.y))
                {
                    observer.Reverse();
                    target.Reverse();

                    observer.x += observer.x < target.x ? 1 : -1;
                    observer.y = (int)Math.Round(linearFuncParamA * observer.x + linearFuncParamB, 0);

                    observer.Reverse();
                    target.Reverse();

                    if (IsOpaque(location.area[observer.x, observer.y, 2]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool IsOpaque(int valueOnArea)
            => valueOnArea >= 20001 && valueOnArea <= 21000;
    }
}