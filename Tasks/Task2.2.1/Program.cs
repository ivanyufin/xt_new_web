using System;
using System.Windows;

namespace Task2._2._1
{
    enum Ability
    {
        None,
        Invulnerability,//Неуязвимость
        DoubleDamage,//Двойной урон
        Recovery//Восстановление жизни
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class Character
    {
        private Point position;
        public Point Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        private double health;
        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (health >= 0)
                    health = value;
                else
                    throw new ArgumentOutOfRangeException("health", "Недопустимое значение для здоровья");
            }
        }

        private int level;
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        private double xp;
        public double XP
        {
            get
            {
                return xp;
            }
            set
            {
                if (xp >= 0)
                    xp = value;
                else
                    throw new ArgumentOutOfRangeException("xp", "Недопустимое значение для прогресса");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }

    class Player : Character
    {
        private double armor;
        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                armor = value;
            }
        }
        public Ability Ability;
    }

    class Board
    {
        private double width;
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        private double height;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }

    class Enemy : Character
    {
        private double power;
        public double Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
            }
        }
    }

    class Bonus
    {
        private Point position;
        public Point Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        private double health;
        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        private double armor;
        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                armor = value;
            }
        }

        public Ability Ability;
    }

    class Barrier
    {
        private Point position;
        public Point Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        private double width;
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        private double height;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }

    #region Enemyes
    class Wolf : Enemy
    {
        public Wolf()
        {
            Position = new Point(0, 0);
            Health = 100;
            Level = 1;
            XP = 0;
            Name = "Wolf";
            Power = 10;
        }

        public Wolf(Point position, double health, int level, double xp, string name, double power)
        {
            Position = position;
            Health = health;
            Level = level;
            XP = xp;
            Name = name;
            Power = power;
        }
    }

    class Bear : Enemy
    {
        public Bear()
        {
            Position = new Point(0, 0);
            Health = 200;
            Level = 1;
            XP = 0;
            Name = "Bear";
            Power = 20;
        }

        public Bear(Point position, double health, int level, double xp, string name, double power)
        {
            Position = position;
            Health = health;
            Level = level;
            XP = xp;
            Name = name;
            Power = power;
        }
    }

    class Fox : Enemy
    {
        public Fox()
        {
            Position = new Point(0, 0);
            Health = 70;
            Level = 1;
            XP = 0;
            Name = "Fox";
            Power = 7;
        }

        public Fox(Point position, double health, int level, double xp, string name, double power)
        {
            Position = position;
            Health = health;
            Level = level;
            XP = xp;
            Name = name;
            Power = power;
        }
    }

    class Boar : Enemy
    {
        public Boar()
        {
            Position = new Point(0, 0);
            Health = 150;
            Level = 1;
            XP = 0;
            Name = "Boar";
            Power = 15;
        }

        public Boar(Point position, double health, int level, double xp, string name, double power)
        {
            Position = position;
            Health = health;
            Level = level;
            XP = xp;
            Name = name;
            Power = power;
        }
    }
    #endregion

    #region Barriers
    class Wood : Barrier
    {
        public Wood()
        {
            Position = new Point(0, 0);
            Width = 5;
            Height = 10;
        }
        public Wood(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }

    class Rock : Barrier
    {
        public Rock()
        {
            Position = new Point(0, 0);
            Width = 1;
            Height = 2;
        }
        public Rock(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }

    class Bush : Barrier
    {
        public Bush()
        {
            Position = new Point(0, 0);
            Width = 2;
            Height = 3;
        }
        public Bush(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }

    class Swamp : Barrier
    {
        public Swamp()
        {
            Position = new Point(0, 0);
            Width = 15;
            Height = 20;
        }
        public Swamp(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }
    #endregion

    #region Bonuses
    class Apple : Bonus
    {
        public Apple()
        {
            Position = new Point(0, 0);
            Health = 5;
            Armor = 2;
            Ability = Ability.None;
        }
        public Apple(Point position, double health, double armor, Ability ability)
        {
            Position = position;
            Health = health;
            Armor = armor;
            Ability = ability;
        }
    }

    class Cherry : Bonus
    {
        public Cherry()
        {
            Position = new Point(0, 0);
            Health = 2;
            Armor = 0;
            Ability = Ability.None;
        }
        public Cherry(Point position, double health, double armor, Ability ability)
        {
            Position = position;
            Health = health;
            Armor = armor;
            Ability = ability;
        }
    }

    class Strawberry : Bonus
    {
        public Strawberry()
        {
            Position = new Point(0, 0);
            Health = 3;
            Armor = 0;
            Ability = Ability.None;
        }
        public Strawberry(Point position, double health, double armor, Ability ability)
        {
            Position = position;
            Health = health;
            Armor = armor;
            Ability = ability;
        }
    }

    class Pear : Bonus
    {
        public Pear()
        {
            Position = new Point(0, 0);
            Health = 4;
            Armor = 0;
            Ability = Ability.None;
        }
        public Pear(Point position, double health, double armor, Ability ability)
        {
            Position = position;
            Health = health;
            Armor = armor;
            Ability = ability;
        }
    }
    #endregion
}
