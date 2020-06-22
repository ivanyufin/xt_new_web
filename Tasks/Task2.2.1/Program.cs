using System;
using System.Collections.Generic;
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
        static Board board = Board.getInstance();
        static Player player = (Player)board.GameObjects[0];
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }

    class GameObject 
    {
        private Point position;
        /// <summary>
        /// Позиция на игровом поле
        /// </summary>
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

        private string name;
        /// <summary>
        /// Имя(название) игрового объекта
        /// </summary>
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

        private Board mainBoard;
        /// <summary>
        /// Главное игровое поле
        /// </summary>
        public Board MainBoard
        {
            get
            {
                return mainBoard;
            }
            set
            {
                mainBoard = value;
            }
        }

        private Player player;
        public Player Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }
        }
    }

    abstract class Character : GameObject
    {
        private double health;
        /// <summary>
        /// Здоровье
        /// </summary>
        public virtual double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (health > 0)
                    health = value;
            }
        }

        private int level;
        /// <summary>
        /// Уровень
        /// </summary>
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
        /// <summary>
        /// Прогресс
        /// </summary>
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

        #region Movement
        public void GoUP()
        {
            if (this.Position.Y > 0)
            {
                //Здесь должна быть проверка на столкновение с барьером
                this.Position = new Point(this.Position.X, this.Position.Y - 1);
            }
        }

        public void GoUP(double step)
        {
            if (this.Position.Y > 0)
                //Здесь должна быть проверка на столкновение с барьером
                this.Position = new Point(this.Position.X, this.Position.Y - step);
        }

        public void GoDown()
        {
            if(this.Position.Y < MainBoard.Height)
                //Здесь должна быть проверка на столкновение с барьером
                this.Position = new Point(this.Position.X, this.Position.Y + 1);
        }

        public void GoDown(double step)
        {
            if (this.Position.Y < MainBoard.Height)
                //Здесь должна быть проверка на столкновение с барьером
                this.Position = new Point(this.Position.X, this.Position.Y + step);
        }

        public void GoLeft()
        {
            if(this.Position.X > 0)
                //Здесь должна быть проверка на столкновение с барьером
                this.Position = new Point(this.Position.X - 1, this.Position.Y);
        }

        public void GoLeft(double step)
        {
            if (this.Position.X > 0)
                //Здесь должна быть проверка на столкновение с барьером
                this.Position = new Point(this.Position.X - step, this.Position.Y);
        }

        public void GoRight()
        {
            if (this.Position.X < MainBoard.Width)
                //Здесь должна быть проверка на столкновение с барьером
                this.Position = new Point(this.Position.X + 1, this.Position.Y);
        }

        public void GoRight(double step)
        {
            if (this.Position.X < MainBoard.Width)
                //Здесь должна быть проверка на столкновение с барьером
                this.Position = new Point(this.Position.X + step, this.Position.Y);
        }
        #endregion
    }

    class Player : Character
    {
        private static Player instance;

        private Player() { }

        private double armor;
        /// <summary>
        /// Броня
        /// </summary>
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

        /// <summary>
        /// Суперспособности
        /// </summary>
        public Ability Ability;

        private double health;
        public override double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value > 0)
                    health = value;
                else
                {
                    Console.WriteLine("Game Over");
                }
            }
        }

        public static Player getInstance()
        {
            if (instance == null)
                instance = new Player();
            return instance;
        }
    }

    class Board
    {
        Player player = Player.getInstance();
        private static Board instance;

        private List<GameObject> arrayGameObjects;
        private Board() 
        {
            arrayGameObjects = new List<GameObject>();
            width = 0;
            height = 0;
            player.MainBoard = this;
            arrayGameObjects.Add(player);
        }

        public static Board getInstance()
        {
            if (instance == null)
                instance = new Board();
            return instance;
        }

        private double width;
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
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
        /// <summary>
        /// Высота игрового поля
        /// </summary>
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

        /// <summary>
        /// Создает игровой объект
        /// </summary>
        /// <param name="gameObject">Игровой объект для создания</param>
        public void AddObject(GameObject gameObject)
        {
            gameObject.MainBoard = this;
            gameObject.Player = player;
            arrayGameObjects.Add(gameObject);
        }

        private GameObject[] gameObjects;
        /// <summary>
        /// Возвращает массив игровых объектов
        /// </summary>
        public GameObject[] GameObjects
        {
            get
            {
                gameObjects = arrayGameObjects.ToArray();
                return gameObjects;
            }
        }

        /// <summary>
        /// Удаляет игровой объект по ссылке
        /// </summary>
        /// <param name="gameObject">Удаляемые игровой объект</param>
        public void DeleteObject(GameObject gameObject)
        {
            arrayGameObjects.Remove(gameObject);
        }

        /// <summary>
        /// Удаляет игровой объект по индексу в массиве
        /// </summary>
        /// <param name="index">Индекс удаляемого объекта</param>
        public void DeleteObject(int index)
        {
            arrayGameObjects.RemoveAt(0);
        }
    }

    class Enemy : Character
    {
        private double power;
        /// <summary>
        /// Сила удара по игроку
        /// </summary>
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

        /// <summary>
        /// Наносит урон игроку
        /// </summary>
        public void DoDamage()
        {
            Player.Health -= power;
        }
    }

    class Bonus : GameObject
    {
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

    class Barrier : GameObject
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
