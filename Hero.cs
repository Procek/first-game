using System;
using System.Collections.Generic;

namespace GraProckowa
{
    class Hero
    {
        public Point2d currentXY;
        public Point2d nextPoint;
        public int hitPointMax = 100;
        public int hitPoint = 100;
        public int damage = 1;
        public double moveCastSpeed = 400;
        public double meleeCastSpeed = 200;
        public double meleeCooldown = 200;
        public AnimType heroSkill = AnimType.None;
        public Course course = Course.Down;
        public int baseValueOnArea = 1001;
        public DateTime lastMoveCastTime = new DateTime(2020, 1, 1);
        DateTime lastMeleeCastTime = new DateTime(2020, 1, 1);
        DateTime lastMeleeTime = new DateTime(2020, 1, 1);
        public Vector screenPosition = new Vector(0, 0);     
        public bool moveSynch = true;
        public bool moveSynch2 = true;

        public Hero()
        {
            currentXY = new Point2d(1, 1);
        }

        public void Action(Location location, List<Mob> mobList, char check)
        {
            do
            {
                moveSynch = false;
                if (heroSkill != AnimType.None)
                {
                    SkillContinue(location, mobList);
                }

                else if (check == 'w' || check == 's' || check == 'a' || check == 'd')
                {
                    nextPoint = Direction.NextPoint(currentXY, check);
                    course = Direction.SetCourseNearPoint(currentXY, nextPoint);

                    if (MobOnCourse(location) && (DateTime.Now - lastMeleeTime).TotalMilliseconds >= meleeCooldown)
                    {
                        lastMeleeCastTime = DateTime.Now;
                        heroSkill = AnimType.Melee;
                        Melee(location, mobList);
                    }
                    else if (location.area[nextPoint.x, nextPoint.y, 2] == 0)
                    {
                        lastMoveCastTime = DateTime.Now;
                        heroSkill = AnimType.Move;
                        location.area[nextPoint.x, nextPoint.y, 2] = (int)Layer_2._Blank;
                        Move(location);
                    }
                }
            } while (moveSynch == true);
            
        }

        void Move(Location location)
        {
            if (!Animation.HeroMove(this, location))
            {
                location.area[currentXY.x, currentXY.y, 2] = 0;
                currentXY = nextPoint;
                location.area[currentXY.x, currentXY.y, 2] = baseValueOnArea + (int)course - 1; //course - 1 (wychodzi zero) lipa

                heroSkill = AnimType.None;
            }
        }

        void SkillContinue(Location location, List<Mob> mobList)
        {
            if (heroSkill == AnimType.Melee)    { Melee(location, mobList); }
            if (heroSkill == AnimType.Move)     { Move(location);           }
        }

        void Melee(Location location, List<Mob> mobList)
        {
            if (!Animation.Skill(AnimType.Melee, baseValueOnArea, location, course, lastMeleeCastTime, meleeCastSpeed, currentXY))
            {
                if (MobOnCourse(location))
                {
                    for (int i = 0; i < mobList.Count; i++)
                    {
                        if (mobList[i].currentXY.x == nextPoint.x && mobList[i].currentXY.y == nextPoint.y)
                        {
                            mobList[i].hitPoint -= damage;

                            if (mobList[i].hitPoint <= 0)
                            {
                                location.area[mobList[i].nextPoint.x, mobList[i].nextPoint.y, 2] = 0; //likwidacja Blank'a
                                mobList.RemoveAt(i);
                                location.area[nextPoint.x, nextPoint.y, 2] = 0;
                            }
                        }
                    }
                }
                lastMeleeTime = DateTime.Now;
                heroSkill = AnimType.None;
            }            
        }

        

        bool MobOnCourse(Location location)
            => location.area[nextPoint.x, nextPoint.y, 2] >= 1000 && location.area[nextPoint.x, nextPoint.y, 2] <= 20000;
    }
}