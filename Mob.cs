using System;
using System.Collections.Generic;

namespace GraProckowa
{
    class Mob
    {
        public Point2d currentXY;
        public Point2d targetXY;
        public Point2d nextPoint;
        public int sightRange = 20;
        public int meleeRange = 1;
        public int hitPointMax = 5;
        public int hitPoint = 5;
        public int damage = 1;
        public double moveCastSpeed = 400;
        public double meleeCastSpeed = 500;
        public double meleeCooldown = 1000;
        public double shootCastSpeed = 1000;
        public double shootCooldown = 5000;                
        public bool isRanged = true;
        public bool isMelee = true;
        public bool isMovable = true;
        AnimType mobSkill = AnimType.None;
        public Course course = Course.Down;
        public int baseValueOnArea = 1001;
        public DateTime lastMoveCastTime = new DateTime(2020, 1, 1);
        DateTime lastMeleeCastTime = new DateTime(2020, 1, 1);
        DateTime lastMeleeTime = new DateTime(2020, 1, 1);
        DateTime lastShootCastTime = new DateTime(2020, 1, 1);
        DateTime lastShootTime = new DateTime(2020, 1, 1);

        public bool moveSynch = true; //cccccccccccccc

        public Mob(Point2d bornMobXY)
        {
            currentXY = bornMobXY;
            targetXY = currentXY;
        }

        public void Action(Location location, Hero hero, List<Projectile> projectileList)
        {
            do
            {
                moveSynch = false;
                if (mobSkill != AnimType.None)
                {
                    SkillContinue(location, hero, projectileList);
                    
                }
                else if (HeroInSight(hero))
                {
                    if (IsVisible.Check(currentXY, hero.currentXY, location))
                    {
                        targetXY = hero.currentXY;
                        course = Direction.SetCourse(currentXY, hero.currentXY);

                        if (isRanged && HeroOutsideMelee(hero) && (DateTime.Now - lastShootTime).TotalMilliseconds >= shootCooldown)
                        {
                            lastShootCastTime = DateTime.Now;
                            mobSkill = AnimType.Shoot;
                            Shoot(projectileList, location);
                        }
                        else if (isMelee && HeroInsideMelee(hero) && (DateTime.Now - lastMeleeTime).TotalMilliseconds >= meleeCooldown)
                        {
                            lastMeleeCastTime = DateTime.Now;
                            mobSkill = AnimType.Melee;
                            Melee(hero, location);
                        }
                    }

                    if (isMovable && mobSkill == AnimType.None && !HasReachedPoint() && !HeroInsideMelee(hero))
                    {
                        lastMoveCastTime = DateTime.Now;
                        mobSkill = AnimType.Move;
                        course = MovementCourse(location);
                        Move(hero, location);
                    }
                }
            } while (moveSynch == true);
            
        }

        void SkillContinue(Location location, Hero hero, List<Projectile> projectileList)
        {
            if (mobSkill == AnimType.Shoot) { Shoot(projectileList, location); }
            if (mobSkill == AnimType.Melee) { Melee(hero, location);           }
            if (mobSkill == AnimType.Move)  { Move(hero, location);            }
        }

        void Shoot(List<Projectile> projectileList, Location location)
        {
            if (!Animation.Skill(AnimType.Shoot, baseValueOnArea, location, course, lastShootCastTime, shootCastSpeed, currentXY))
            {
                projectileList.Add(new Projectile(currentXY, targetXY, damage));
                lastShootTime = DateTime.Now;
                mobSkill = AnimType.None;
            }
        }

        void Melee(Hero hero, Location location)
        {
            if (!Animation.Skill(AnimType.Melee, baseValueOnArea, location, course, lastMeleeCastTime, meleeCastSpeed, currentXY))
            {
                if (isMelee && HeroInsideMelee(hero)) //obrażenia punktowe, nie naokoło - do zrobienia
                {
                    hero.hitPoint -= damage;

                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine(hero.hitPoint);
                }
                lastMeleeTime = DateTime.Now;
                mobSkill = AnimType.None;
            }
        }
        
        void Move(Hero hero, Location location)
        {
            if (!Animation.Move(this, hero, location))
            {
                location.area[currentXY.x, currentXY.y, 2] = 0;
                currentXY = nextPoint;
                location.area[currentXY.x, currentXY.y, 2] = baseValueOnArea + (int)course - 1;
                mobSkill = AnimType.None;                
            }
        }
        
        Course MovementCourse(Location location)
        {
            nextPoint = MobPathfinding.Move(currentXY, targetXY, location);

            if (location.area[nextPoint.x, nextPoint.y, 2] == 0)
            {
                location.area[nextPoint.x, nextPoint.y, 2] = (int)Layer_2._Blank;
            }

            return Direction.SetCourseNearPoint(currentXY, nextPoint);
        }

        bool HeroInSight(Hero hero)        
            => Math.Abs(currentXY.x - hero.currentXY.x) <= sightRange && Math.Abs(currentXY.y - hero.currentXY.y) <= sightRange;        

        bool HeroOutsideMelee(Hero hero)
            => Math.Abs(currentXY.x - hero.currentXY.x) > meleeRange || Math.Abs(currentXY.y - hero.currentXY.y) > meleeRange;        

        bool HeroInsideMelee(Hero hero)
            => Math.Abs(currentXY.x - hero.currentXY.x) <= meleeRange && Math.Abs(currentXY.y - hero.currentXY.y) <= meleeRange;

        bool HasReachedPoint()
            => currentXY.x == targetXY.x && currentXY.y == targetXY.y;        
    }
}