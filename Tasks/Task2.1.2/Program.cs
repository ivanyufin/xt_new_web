using System;
using System.Collections.Generic;
using System.Linq;
using Figures;

namespace Task2._1._2
{
    class Program
    {
        static double x = 0;
        static double y = 0;
        //Функция получения координат центра. Вынес из-за повторяющегося кода
        static void GetCoordinate(string output)
        {
            Console.WriteLine();
            Console.WriteLine(output);
            string center = Console.ReadLine();
            x = double.Parse(center.Split(' ')[0]);
            y = double.Parse(center.Split(' ')[1]);
        }

        static void Main(string[] args)
        {
            int input = 0;
            List<Figure> figures = new List<Figure>();
            do
            {
                try
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1: Добавить фигуру");
                    Console.WriteLine("2: Вывести фигуры");
                    Console.WriteLine("3: Очистить холст");
                    Console.WriteLine("4: Выход");
                    input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.WriteLine("Выберите тип фигуры:");
                            Console.WriteLine("1: Кольцо");
                            Console.WriteLine("2: Круг");
                            Console.WriteLine("3: Прямоугольник");
                            Console.WriteLine("4: Квадрат");
                            Console.WriteLine("5: Треугольник");
                            Console.WriteLine("6: Линия");
                            int type = int.Parse(Console.ReadLine());
                            switch (type)
                            {
                                case 1:
                                    GetCoordinate("Через пробел введите координаты центра (X, Y)");
                                    Console.WriteLine("Введите внешний радиус");
                                    double outerRadius = double.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите внутренний радиус");
                                    double innerRadius = double.Parse(Console.ReadLine());
                                    Ring ring = new Ring(x, y, outerRadius, innerRadius);
                                    figures.Add(ring);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    GetCoordinate("Через пробел введите координаты центра (X, Y)");
                                    Console.WriteLine("Введите радиус");
                                    double radius = double.Parse(Console.ReadLine());
                                    Circle circle = new Circle(x, y, radius);
                                    figures.Add(circle);
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    GetCoordinate("Через пробел введите координаты (X, Y)");
                                    Console.WriteLine("Введите одну вертикальную сторону(например, левую)");
                                    double leftSide = double.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите одну горизонтальную сторону(например, верхнюю)");
                                    double topSide = double.Parse(Console.ReadLine());
                                    Rectangle rectangle = new Rectangle(x, y, leftSide, topSide);
                                    figures.Add(rectangle);
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    GetCoordinate("Через пробел введите координаты (X, Y)");
                                    Console.WriteLine("Введите одну сторону");
                                    double side = double.Parse(Console.ReadLine());
                                    Square square = new Square(x, y, side);
                                    figures.Add(square);
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    GetCoordinate("Через пробел введите координаты (X, Y)");
                                    Console.WriteLine("Через пробел введите углы a, b, c");
                                    string angle = Console.ReadLine();
                                    double a = double.Parse(angle.Split(' ')[0]);
                                    double b = double.Parse(angle.Split(' ')[1]);
                                    double c = double.Parse(angle.Split(' ')[2]);
                                    Console.WriteLine("Введите сторону AC");
                                    double sideA = double.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите сторону CB");
                                    double sideB = double.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите сторону BA");
                                    double sideC = double.Parse(Console.ReadLine());
                                    Triangle triangle = new Triangle(x, y, a, b, c, sideA, sideB, sideC);
                                    figures.Add(triangle);
                                    Console.WriteLine();
                                    break;
                                case 6:
                                    GetCoordinate("Через пробел введите координаты (X, Y)");
                                    Console.WriteLine("Введите длину линии");
                                    double length = double.Parse(Console.ReadLine());
                                    Line line = new Line(x, y, length);
                                    figures.Add(line);
                                    Console.WriteLine();
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine();
                            Console.WriteLine("<---------------Фигуры--------------->");
                            Console.WriteLine();
                            //Вывод названия фигуры и ее характеристик
                            for (int i = 0; i < figures.Count; i++)
                            {
                                Console.WriteLine("<---------------" + figures[i].Name + "--------------->");
                                for (int j = 0; j < figures[i].Specifications.Count; j++)
                                {
                                    Console.WriteLine(figures[i].Specifications.Keys.ToArray()[j] + ": " + figures[i].Specifications.Values.ToArray()[j]);
                                }
                            }
                            Console.WriteLine("<------------------------------------->");
                            Console.WriteLine();
                            break;
                        case 3:
                            figures.Clear();
                            break;
                        case 4:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Недопустимое значение");
                    continue;
                }
            }
            while (input != 4);
        }
    }
}

namespace Figures
{
    class Figure
    {
        private double x;
        private double y;
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public virtual string Name => "Фигура";

        public Dictionary<string, double> Specifications;
    }

    //Круглая фигура
    class RoundFigure : Figure
    {
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
    }

    //Круг
    class Circle : RoundFigure
    {

        public Circle(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
            Specifications = new Dictionary<string, double>();
            Specifications.Add("Координата центра X", X);
            Specifications.Add("Координата центра Y", Y);
            Specifications.Add("Радиус", Radius);
        }

        /// <summary>
        /// Длина круга
        /// </summary>
        public double Circumference
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        public double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public override string Name => "Круг";
    }

    //Кольцо
    class Ring : RoundFigure
    {
        public Ring(double x, double y, double outerRadius, double innerRadius)
        {
            X = x;
            Y = y;
            Radius = outerRadius;
            this.innerRadius = innerRadius;
            Specifications = new Dictionary<string, double>();
            Specifications.Add("Координата центра X", X);
            Specifications.Add("Координата центра Y", Y);
            Specifications.Add("Внешний радиус", outerRadius);
            Specifications.Add("Внутренний радиус", innerRadius);
        }

        private double innerRadius;
        /// <summary>
        /// Радиус внутренней окружности
        /// </summary>
        public double InnerRadius
        {
            get
            {
                return innerRadius;
            }
        }

        /// <summary>
        /// Площадь колца
        /// </summary>
        public double Area
        {
            get
            {
                return Math.PI * (Radius * Radius - innerRadius * innerRadius);
            }
        }

        /// <summary>
        /// Суммарная длина окружностей кольца
        /// </summary>
        public double Circumference
        {
            get
            {
                return (2 * Math.PI * Radius) + (2 * Math.PI * innerRadius);
            }
        }

        public override string Name => "Кольцо";
    }

    //Линия
    class Line : Figure
    {
        public Line(double x, double y, double length)
        {
            X = x;
            Y = y;
            this.length = length;
            Specifications = new Dictionary<string, double>();
            Specifications.Add("Координата X", X);
            Specifications.Add("Координата Y", Y);
            Specifications.Add("Длина", length);
        }
        public Line(double length)
        {
            this.length = length;
        }

        private double length;
        /// <summary>
        /// Длина линии
        /// </summary>
        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public override string Name => "Линия";
    }

    //Многоугольник
    class Polygon : Figure
    {
        /// <summary>
        /// Угол многоугольника
        /// </summary>
        private double[] angles;
        public double[] Angles
        {
            get
            {
                return angles;
            }
            set
            {
                angles = value;
            }
        }

        /// <summary>
        /// Сторона многоугольника
        /// </summary>
        private Line[] sides;
        public Line[] Sides
        {
            get
            {
                return sides;
            }
            set
            {
                sides = value;
            }
        }
        private double perimeter;
        /// <summary>
        /// Периметр многоугольника
        /// </summary>
        public virtual double Perimeter => perimeter;

        private double area;
        /// <summary>
        /// Площадь многоугольника
        /// </summary>
        public virtual double Area => area;
    }

    //Прямоугольник
    class Rectangle : Polygon
    {
        /// <summary>
        /// Определяет прямоугольник по координатам X, Y и сторонам
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="sideAB">Левая и правая сторона</param>
        /// <param name="sideBC">Верхняя и нижняя сторона</param>
        public Rectangle(double x, double y, double sideAB, double sideBC)
        {
            X = x;
            Y = y;
            Angles = new double[4] { 90, 90, 90, 90 };
            verticalSide = new Line(sideAB);
            horizontalSide = new Line(sideBC);
            Sides = new Line[] { verticalSide, horizontalSide };
            Specifications = new Dictionary<string, double>();
            Specifications.Add("Координата X", X);
            Specifications.Add("Координата Y", Y);
            Specifications.Add("Углы", 90);
            Specifications.Add("Вертикальные стороны(левая и правая)", sideAB);
            Specifications.Add("Горизонтальные стороны(верхняя и нижняя)", sideBC);
        }

        private Line verticalSide;
        /// <summary>
        /// Вертикальная сторона
        /// </summary>
        public Line VerticalSide
        {
            get
            {
                return verticalSide;
            }
            set
            {
                verticalSide = value;
                Sides[0] = verticalSide;
            }
        }
        private Line horizontalSide;
        /// <summary>
        /// Горизонтальная сторона
        /// </summary>
        public Line HorizontalSide
        {
            get
            {
                return horizontalSide;
            }
            set
            {
                horizontalSide = value;
                Sides[1] = horizontalSide;
            }
        }

        /// <summary>
        /// Периметр прямоугольника
        /// </summary>
        public override double Perimeter => 2 * (verticalSide.Length + horizontalSide.Length);

        /// <summary>
        /// Площадь прямоугольника
        /// </summary>
        public override double Area => verticalSide.Length * horizontalSide.Length;

        public override string Name => "Прямоугольник";
    }

    //Квадрат
    class Square : Polygon
    {
        public Square(double x, double y, double side)
        {
            X = x;
            Y = y;
            Angles = new double[4] { 90, 90, 90, 90 };
            this.side = new Line(side);
            Sides = new Line[] { this.side };
            Specifications = new Dictionary<string, double>();
            Specifications.Add("Координата X", X);
            Specifications.Add("Координата Y", Y);
            Specifications.Add("Сторона", side);
        }

        private Line side;
        /// <summary>
        /// Сторона квадрата
        /// </summary>
        public Line Side
        {
            get
            {
                return side;
            }
            set
            {
                side = value;
                Sides[0] = side;
            }
        }

        /// <summary>
        /// Периметр квадрата
        /// </summary>
        public override double Perimeter => 4 * side.Length;

        /// <summary>
        /// Площадь квадрата
        /// </summary>
        public override double Area => side.Length * side.Length;

        public override string Name => "Квадрат";
    }

    //Треугольник
    class Triangle : Polygon
    {
        //A->C->B, по часовой стрелке
        /// <summary>
        /// Определяет треугольник
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="a">угол, образованный сторонами AB и AC</param>
        /// <param name="b">угол, образованный сторонами AB и BC</param>
        /// <param name="c">угол, образованный сторонами BC и AC</param>
        /// <param name="sideA">Сторона AC</param>
        /// <param name="sideB">Сторона CB</param>
        /// <param name="sideC">Сторона BA</param>
        public Triangle(double x, double y, double a, double b, double c, double sideA, double sideB, double sideC)
        {
            X = x;
            Y = y;
            Angles = new double[3] { a, b, c };
            this.sideA = new Line(sideA);
            this.sideB = new Line(sideB);
            this.sideC = new Line(sideC);
            Sides = new Line[3] { this.sideA, this.sideB, this.sideC };
            Specifications = new Dictionary<string, double>();
            Specifications.Add("Координата X", X);
            Specifications.Add("Координата Y", Y);
            Specifications.Add("Угол a", a);
            Specifications.Add("Угол b", b);
            Specifications.Add("Угол c", c);
            Specifications.Add("Сторона AC", sideA);
            Specifications.Add("Сторона CB", sideB);
            Specifications.Add("Сторона BA", sideC);
        }

        private Line sideA;
        /// <summary>
        /// Первая сторона
        /// </summary>
        public Line A
        {
            get
            {
                return sideA;
            }
            set
            {
                sideA = value;
                Sides[0] = sideA;
            }
        }

        private Line sideB;
        /// <summary>
        /// Вторая сторона
        /// </summary>
        public Line B
        {
            get
            {
                return sideB;
            }
            set
            {
                sideB = value;
                Sides[1] = sideB;
            }
        }

        private Line sideC;
        /// <summary>
        /// Третья сторона
        /// </summary>
        public Line C
        {
            get
            {
                return sideC;
            }
            set
            {
                sideC = value;
                Sides[2] = sideC;
            }
        }

        /// <summary>
        /// Периметр треугольника
        /// </summary>
        public override double Perimeter => sideA.Length + sideB.Length + sideC.Length;

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public override double Area => (A.Length * A.Length * Math.Sin(Angles[1]) * Math.Sin(Angles[2])) / (2 * Math.Sin(Angles[0]));

        public override string Name => "Треугольник";
    }
}