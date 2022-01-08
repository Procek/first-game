using System;

namespace GraProckowa
{
    class Animation
    {
        public static bool Skill(AnimType animType, int baseValueOnArea, Location location, Course course, DateTime lastSkillCastTime, double skillCastSpeed, Point2d currentXY)
        {            
            int frames = 9;            

            int frameNumber = (int)((DateTime.Now - lastSkillCastTime).TotalMilliseconds / (skillCastSpeed / frames));

            if (frameNumber < frames)
            {
                if (course != (int)Course.None)
                {
                    location.area[currentXY.x, currentXY.y, 2] = baseValueOnArea + frameNumber + (int)course + (int)animType;
                }
                return true;
            }
            return false;
        }

        public static bool Move(Mob mob, Hero hero, Location location)
        {
            int frames = 9;            
            double diagonalParam;

            if (mob.course == Course.Up || mob.course == Course.Down || mob.course == Course.Left || mob.course == Course.Right)
            {
                diagonalParam = 1;
            }
            else
            {
                diagonalParam = 1.2;
            }

            int frameNumber = (int)((DateTime.Now - mob.lastMoveCastTime).TotalMilliseconds / (mob.moveCastSpeed * diagonalParam / frames));
            
            if (frameNumber < frames)
            {
                if (mob.course != (int)Course.None && hero.moveSynch2 == true)
                {
                    location.area[mob.currentXY.x, mob.currentXY.y, 2] = mob.baseValueOnArea + (int)mob.course + frameNumber;
                }
                return true;
            }
            mob.moveSynch = true;
            return false;
        }

        public static bool Move(Projectile projectile, Location location)
        {
            int frames = 2;
            double diagonalParam;

            if (projectile.course == Course.Up || projectile.course == Course.Down || projectile.course == Course.Left || projectile.course == Course.Right)
            {
                diagonalParam = 1;
            }
            else
            {
                diagonalParam = 1.2;
            }

            int frameNumber = (int)((DateTime.Now - projectile._lastMoveTime).TotalMilliseconds / (projectile._moveSpeed * diagonalParam / frames));

            if (frameNumber < frames)
            {
                if (projectile.course != (int)Course.None)
                {
                    location.area[projectile._currentXY.x, projectile._currentXY.y, 3] = projectile.baseValueOnArea + (int)projectile.course + frameNumber;
                }
                return true;
            }
            return false;
        }

        static int container = 0;
        public static bool HeroMove(Hero hero, Location location)
        {
            int frames = 9;

            int frameNumber = (int)((DateTime.Now - hero.lastMoveCastTime).TotalMilliseconds / (hero.moveCastSpeed / frames));

            if (frameNumber < frames)
            {
                if (hero.course != (int)Course.None)
                {
                    location.area[hero.currentXY.x, hero.currentXY.y, 2] = hero.baseValueOnArea + frameNumber + (int)hero.course;

                    if (container == frameNumber)
                    {
                        hero.moveSynch2 = true;
                        
                        if (hero.course == Course.Up) { hero.screenPosition.y += 5; }
                        if (hero.course == Course.Down) { hero.screenPosition.y -= 5; }
                        if (hero.course == Course.Left) { hero.screenPosition.x += 5; }
                        if (hero.course == Course.Right) { hero.screenPosition.x -= 5; }
                        container++;
                    }
                    else
                    {
                        hero.moveSynch2 = false;
                    }
                }
                return true;
            }
            hero.moveSynch = true;
            hero.moveSynch2 = true;
            container = 0;
            return false;
        }
    }
}