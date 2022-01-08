using System;
using System.Collections.Generic;

namespace GraProckowa
{
    class Location
    {
        public int[,,] area;

        public Location(int areaSizeX, int areaSizeY, int layer)
        {
            area = new int[areaSizeX, areaSizeY, layer];
        }

        public void CreateArea()
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                area[i, 0, 2] = 20001;
                area[i, area.GetLength(1) - 1, 2] = (int)Layer_2.Stone;
            }

            for (int i = 0; i < area.GetLength(1); i++)
            {
                area[0, i, 2] = 20001;
                area[area.GetLength(0) - 1, i, 2] = (int)Layer_2.Stone;
            }

            Rectangle(18, 3, 1, 9, 21001);
            Rectangle(18, 13, 1, 5, 21001);

            Rectangle(20, 3, 3, 2, 20001);
            Rectangle(30, 9, 2, 5, 20001);
            Rectangle(25, 17, 4, 3, 20001);

            area[28, 20, 2] = 1001;

            area[17, 13, 2] = 1001;
            area[17, 14, 2] = 1001;
            area[17, 15, 2] = 1001;
            area[16, 13, 2] = 1001;
            area[16, 14, 2] = 1001;
            area[16, 15, 2] = 1001;

            area[19, 14, 2] = 1;
        }

        public void LoadCreatures(List<Mob> mobList, Hero hero)
        {
            for (int i = 0; i < area.GetLength(1); i++)
            {
                for (int j = 0; j < area.GetLength(0); j++)
                {
                    if (area[j, i, 2] == 1)
                    {
                        hero.currentXY = new Point2d(j, i);
                    }
                    else if (area[j, i, 2] == 1001)
                    {
                        mobList.Add(new Mob(new Point2d(j, i)));
                    }
                }
            }
        }

        void Rectangle(int leftUpCornerX, int leftUpCornerY, int horizontal, int vertical, int obstacle)
        {
            for (int i = leftUpCornerY; i < vertical + leftUpCornerY; i++)
            {
                for (int j = leftUpCornerX; j < horizontal + leftUpCornerX; j++)
                {
                    area[j, i, 2] = obstacle;
                }
            }
        }
    }
}