using System.Collections.Generic;

namespace GraProckowa
{
    class LoadSprites
    {
        public static void Load(Dictionary<int, Sprite> spriteList)
        {            
            int mobFrames = 9;
            int projectileFrames = 2;
            int baseSquareSize = 45; //najlepiej wielokrotność mobFrames
            Vector squareXY = new Vector(baseSquareSize, baseSquareSize);
            Vector mobScale = new Vector(95, 120);
            int mobAnim = (int)(baseSquareSize / mobFrames);
            int projectileAnim = (int)(baseSquareSize / projectileFrames);
            int mobShiftX = (int)((mobScale.x - baseSquareSize) / 2);
            int mobShiftY = (int)(mobScale.y - baseSquareSize);
            

            spriteList.Add(22000, new Sprite(new Vector(1, 1), new Vector(0, 0), "Hero/hero", new Vector(0, 0))); // blank do zrobienia

            spriteList.Add(1, new Sprite(new Vector(1, 1), new Vector(45, 45), "Hero/hero", new Vector(0, 0)));

            spriteList.Add(20001, new Sprite(new Vector(1, 1), squareXY, "Obstacle/rock", new Vector(0, 0)));
            spriteList.Add(21001, new Sprite(new Vector(1, 1), squareXY, "Obstacle/water", new Vector(0, 0)));

            //2222222222222222222

            //spriteList.Add(1, new Sprite(new Vector(1, 1), mobScale, "Mob/Mob_1/mob", new Vector(0 - mobShiftX, 0 - mobShiftY)));
            //spriteList.Add(1000, new Sprite(new Vector(1, 1), mobScale, "Mob/Mob_1/mob", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                        
            for (int i = 0; i < 10; i++)
            {
                spriteList.Add(20 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-up-{i}", new Vector(0 - mobShiftX, -i * mobAnim - mobShiftY)));
                spriteList.Add(30 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-down-{i}", new Vector(0 - mobShiftX, i * mobAnim - mobShiftY)));
                spriteList.Add(40 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-left-{i}", new Vector(-i * mobAnim - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(50 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-right-{i}", new Vector(i * mobAnim - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(60 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-leftup-{i}", new Vector(-i * mobAnim - mobShiftX, -i * mobAnim - mobShiftY)));
                spriteList.Add(70 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-rightup-{i}", new Vector(i * mobAnim - mobShiftX, -i * mobAnim - mobShiftY)));
                spriteList.Add(80 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-leftdown-{i}", new Vector(-i * mobAnim - mobShiftX, i * mobAnim - mobShiftY)));
                spriteList.Add(90 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-rightdown-{i}", new Vector(i * mobAnim - mobShiftX, i * mobAnim - mobShiftY)));
            }

            for (int i = 0; i < 10; i++)
            {
                spriteList.Add(120 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-up-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(130 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-down-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(140 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-left-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(150 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-right-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(160 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-leftup-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(170 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-rightup-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(180 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-leftdown-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(190 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-rightdown-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
            }

            //2222222222222222222

            spriteList.Add(1001, new Sprite(new Vector(1, 1), mobScale, "Mob/Mob_1/mob", new Vector(0 - mobShiftX, 0 - mobShiftY)));
            spriteList.Add(1000, new Sprite(new Vector(1, 1), mobScale, "Mob/Mob_1/mob", new Vector(0 - mobShiftX, 0 - mobShiftY)));
            for (int i = 0; i < 10; i++)
            {
                spriteList.Add(1020 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-up-{i}", new Vector(0 - mobShiftX, -i * mobAnim - mobShiftY)));
                spriteList.Add(1030 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-down-{i}", new Vector(0 - mobShiftX, i * mobAnim - mobShiftY)));
                spriteList.Add(1040 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-left-{i}", new Vector(-i * mobAnim - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1050 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-right-{i}", new Vector(i * mobAnim - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1060 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-leftup-{i}", new Vector(-i * mobAnim - mobShiftX, -i * mobAnim - mobShiftY)));
                spriteList.Add(1070 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-rightup-{i}", new Vector(i * mobAnim - mobShiftX, -i * mobAnim - mobShiftY)));
                spriteList.Add(1080 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-leftdown-{i}", new Vector(-i * mobAnim - mobShiftX, i * mobAnim - mobShiftY)));
                spriteList.Add(1090 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-rightdown-{i}", new Vector(i * mobAnim - mobShiftX, i * mobAnim - mobShiftY)));
            }

            for (int i = 0; i < 10; i++)
            {
                spriteList.Add(1120 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-up-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1130 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-down-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1140 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-left-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1150 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-right-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1160 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-leftup-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1170 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-rightup-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1180 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-leftdown-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1190 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-melee-rightdown-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
            }

            for (int i = 0; i < 10; i++)
            {
                spriteList.Add(1220 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-shoot-up-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1230 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-shoot-down-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1240 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-shoot-left-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1250 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-shoot-right-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1260 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-shoot-leftup-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1270 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-shoot-rightup-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1280 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-shoot-leftdown-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
                spriteList.Add(1290 + i, new Sprite(new Vector(1, 1), mobScale, $"Mob/Mob_1/mob-shoot-rightdown-{i}", new Vector(0 - mobShiftX, 0 - mobShiftY)));
            }

            spriteList.Add(30001, new Sprite(new Vector(1, 1), new Vector(45, 45), "Projectile/Projectile_1/projectile", new Vector(0, 0)));
            for (int i = 1; i < 3; i++)
            {
                spriteList.Add(30020 + i, new Sprite(new Vector(1, 1), new Vector(45, 45), $"Projectile/Projectile_1/projectile-up-{i}", new Vector(0, -i * projectileAnim)));                
                spriteList.Add(30030 + i, new Sprite(new Vector(1, 1), new Vector(45, 45), $"Projectile/Projectile_1/projectile-down-{i}", new Vector(0, i * projectileAnim)));                
                spriteList.Add(30040 + i, new Sprite(new Vector(1, 1), new Vector(45, 45), $"Projectile/Projectile_1/projectile-left-{i}", new Vector(-i * projectileAnim, 0)));                
                spriteList.Add(30050 + i, new Sprite(new Vector(1, 1), new Vector(45, 45), $"Projectile/Projectile_1/projectile-right-{i}", new Vector(i * projectileAnim, 0)));                
                spriteList.Add(30060 + i, new Sprite(new Vector(1, 1), new Vector(45, 45), $"Projectile/Projectile_1/projectile-leftup-{i}", new Vector(-i * projectileAnim, -i * projectileAnim)));                
                spriteList.Add(30070 + i, new Sprite(new Vector(1, 1), new Vector(45, 45), $"Projectile/Projectile_1/projectile-rightup-{i}", new Vector(i * projectileAnim, -i * projectileAnim)));                
                spriteList.Add(30080 + i, new Sprite(new Vector(1, 1), new Vector(45, 45), $"Projectile/Projectile_1/projectile-leftdown-{i}", new Vector(-i * projectileAnim, i * projectileAnim)));                
                spriteList.Add(30090 + i, new Sprite(new Vector(1, 1), new Vector(45, 45), $"Projectile/Projectile_1/projectile-rightdown-{i}", new Vector(i * projectileAnim, i * projectileAnim)));               
            }
        }
    }
}