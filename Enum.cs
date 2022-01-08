namespace GraProckowa
{
    enum Course
    {
        None,
        Up = 20,
        Down = 30,
        Left = 40,
        Right = 50,
        LeftUp = 60,
        RightUp = 70,
        LeftDown = 80,
        RightDown = 90
    }

    enum AnimType
    {
        None,
        Move,
        Melee = 100,
        Shoot = 200,
        Projectile
    }

    enum Layer_0 //ground
    {
        
    }

    enum Layer_1 //loot
    {

    }

    enum Layer_2 //obstacle, mobs, hero
    {
        None = 0,

        HeroBase = 1, //hero 1 - 1000
        HeroUp = 21,     //21 - 30
        HeroDown = 31,   //31 - 40
        HeroLeft = 41,
        HeroRight = 51,
        HeroLeftUp = 61,
        HeroRightUp = 71,
        HeroLeftDown = 81,
        HeroRightDown = 91,

        MobBase = 1001, //mobs 1000 - 20000 / zera na końcu - korekty do animacji / 100 - cast melee / 200 - cast shoot       
        MobUp = 1021,
        MobDown = 1031,
        MobLeft = 1041,
        MobRight = 1051,
        MobLeftUp = 1061,
        MobRightUp = 1071,
        MobLeftDown = 1081,
        MobRightDown = 1091,

        Stone = 20001, //opaque 20001 - 21000 //od 20001 elementy mapy z narożnikami do uwzględnienia w pathfindingu        
        Water = 21001, //transparent 21001 - 22000
        _Blank = 22000 //nextPoint w ruchu moba (blokada dla innych mobów i bohatera)
    }

    enum Layer_3 //projectiles 30001 - 40000, effects 40001 - 50000
    {
        Projectile = 30001,
        ProjectileUp = 30021,
        ProjectileDown = 30031,
        ProjectileLeft = 30041,
        ProjectileRight = 30051,
        ProjectileLeftUp = 30061,
        ProjectileRightUp = 30071,
        ProjectileLeftDown = 30081,
        ProjectileRightDown = 30091
    }

    enum Layer_4 //info
    {

    }
}