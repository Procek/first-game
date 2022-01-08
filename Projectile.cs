using System;

namespace GraProckowa
{
    class Projectile
    {
        Point2d _startXY;
        public Point2d _currentXY;
        Point2d _targetXY;
        public double _moveSpeed = 50;
        public int _damage = 1;
        bool isAnimation = false;
        public Course course = Course.None;
        public int baseValueOnArea = 30001;
        public DateTime _lastMoveTime = DateTime.Now;

        double _linearFuncParamA;
        double _linearFuncParamB;

        public Projectile(Point2d firedXY, Point2d targetXY, int damage)
        {
            _startXY = firedXY;
            _currentXY = firedXY;
            _targetXY = targetXY;
            _damage = damage;

            if (Math.Abs(_startXY.x - _targetXY.x) >= Math.Abs(_startXY.y - _targetXY.y))
            {
                _linearFuncParamA = (double)(-(_targetXY.y - _startXY.y)) / (_startXY.x - _targetXY.x);
                _linearFuncParamB = (double)(_startXY.x * _targetXY.y - _targetXY.x * _startXY.y) / (_startXY.x - _targetXY.x);
            }
            else
            {
                _startXY.Reverse();
                _targetXY.Reverse();

                _linearFuncParamA = (double)(-(_targetXY.y - _startXY.y)) / (_startXY.x - _targetXY.x);
                _linearFuncParamB = (double)(_startXY.x * _targetXY.y - _targetXY.x * _startXY.y) / (_startXY.x - _targetXY.x);

                _startXY.Reverse();
                _targetXY.Reverse();
            }
        }

        public bool Fly(Location location, Hero hero)
        {
            if (!isAnimation)
            {
                nextStep = MoveOnLinearFunction();
                course = Direction.SetCourse(_currentXY, nextStep);
            }

            if (!Animation.Move(this, location)) //ccccccccccccccccccccccccc
            {
                location.area[_currentXY.x, _currentXY.y, 3] = 0;
                _currentXY = MoveOnLinearFunction();
                location.area[_currentXY.x, _currentXY.y, 3] = (int)Layer_3.Projectile;
                _lastMoveTime = DateTime.Now;
                isAnimation = false;
                return !IsCollision(location, hero);
            }
            isAnimation = true;
            return true;
        }

        bool IsCollision(Location location, Hero hero)
        {
            if (IsOpaqueCollision(location.area[_currentXY.x, _currentXY.y, 2]))
            {
                location.area[_currentXY.x, _currentXY.y, 3] = 0;
                return true;
            }
            else if (IsHeroCollision(ref hero.currentXY))
            {
                hero.hitPoint -= _damage;
                Console.SetCursorPosition(1, 1);
                Console.Write(hero.hitPoint);
                location.area[_currentXY.x, _currentXY.y, 3] = 0;
                return true;
            }
            return false;
        }

        Point2d nextStep;
        Point2d MoveOnLinearFunction()
        {
            nextStep = _currentXY;

            if (Math.Abs(_startXY.x - _targetXY.x) >= Math.Abs(_startXY.y - _targetXY.y))
            {
                nextStep.x += _startXY.x < _targetXY.x ? 1 : -1;
                nextStep.y = (int)Math.Round(_linearFuncParamA * nextStep.x + _linearFuncParamB, 0);
                return nextStep;
            }
            nextStep.Reverse();
            _targetXY.Reverse();
            _startXY.Reverse();

            nextStep.x += _startXY.x < _targetXY.x ? 1 : -1;
            nextStep.y = (int)Math.Round(_linearFuncParamA * nextStep.x + _linearFuncParamB, 0);

            nextStep.Reverse();
            _targetXY.Reverse();
            _startXY.Reverse();

            return nextStep;
        }

        bool IsOpaqueCollision(int valueOnArea)
            => valueOnArea >= 20001 && valueOnArea <= 21000;

        bool IsHeroCollision(ref Point2d heroXY)
            => _currentXY.x == heroXY.x && _currentXY.y == heroXY.y;
    }
}