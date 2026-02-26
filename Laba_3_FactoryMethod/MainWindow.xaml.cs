using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laba_3_FactoryMethod
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public abstract class Figure
        {
            public Color Color { get; set; }

            // Метод, создающий визуальный элемент для отображения
            public abstract UIElement CreateUIElement(double size = 50);
        }

        // circle //
        public class Circle : Figure
        {
            public override UIElement CreateUIElement(double size = 50)
            {
                return new Ellipse
                {
                    Width = size,
                    Height = size,
                    Fill = new SolidColorBrush(Color),
                    Margin = new Thickness(5)
                };
            }
        }
        public abstract class CircleCreator
        {
            public abstract Circle CreateCircle();
        }

        public class RedCircleCreator : CircleCreator
        {
            public override Circle CreateCircle() => new Circle
            {
                Color = Colors.Red
            };
        }
        public class GreenCircleCreator : CircleCreator
        {
            public override Circle CreateCircle() => new Circle
            {
                Color = Colors.Green
            };
        }

        public class OrangeCircleCreator : CircleCreator
        {
            public override Circle CreateCircle() => new Circle
            {
                Color = Colors.Orange
            };
        }


        // square //
        public class Square : Figure
        {
            public override UIElement CreateUIElement(double size = 50)
            {

                return new Rectangle
                {
                    Width = size,
                    Height = size,
                    Fill = new SolidColorBrush(Color),
                    Margin = new Thickness(5)
                };
            }
        }

        public abstract class SquareCreator
        {
            public abstract Square CreateSquare();
        }

        public class RedSquareCreator : SquareCreator
        {
            public override Square CreateSquare() => new Square
            {
                Color = Colors.Red
            };
        }
        public class GreenSquareCreator : SquareCreator
        {
            public override Square CreateSquare() => new Square
            {
                Color = Colors.Green
            };
        }

        public class OrangeSquareCreator : SquareCreator
        {
            public override Square CreateSquare() => new Square
            {
                Color = Colors.Orange
            };
        }


        // triangle //
        public class Triangle : Figure
        {
            public override UIElement CreateUIElement(double size = 50)
            {
                var polygon = new Polygon
                {
                    Points = new PointCollection
                   {
                   new Point(size / 2, 0),
                   new Point(0, size),
                   new Point(size, size)
                   },
                    Fill = new SolidColorBrush(Color),
                    Margin = new Thickness(5),
                    Width = size,
                    Height = size,
                    Stretch = Stretch.Fill
                };
                return polygon;
            }
        }

        public abstract class TriangleCreator
        {
            public abstract Triangle CreateTriangle();
        }

        public class RedTriangleCreator : TriangleCreator
        {
            public override Triangle CreateTriangle() => new Triangle
            {
                Color = Colors.Red
            };
        }
        public class GreenTriangleCreator : TriangleCreator
        {
            public override Triangle CreateTriangle() => new Triangle
            {
                Color = Colors.Green
            };
        }

        public class OrangeTriangleCreator : TriangleCreator
        {
            public override Triangle CreateTriangle() => new Triangle
            {
                Color = Colors.Orange
            };
        }


        // button //
        private void CreateFiguresButton(object sender, RoutedEventArgs e)
        {
            for_figures.Children.Clear();

            if (colorsList.SelectedItem == null)
            {
                MessageBox.Show("The color is not selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string selectedItem = ((TextBlock)colorsList.SelectedItem).Text;

            CircleCreator circleCreator;
            SquareCreator squareCreator;
            TriangleCreator triangleCreator;

            switch (selectedItem)
            {

                case "Red":
                    circleCreator = new RedCircleCreator();
                    squareCreator = new RedSquareCreator();
                    triangleCreator = new RedTriangleCreator();
                    break;
                case "Orange":
                    circleCreator = new OrangeCircleCreator();
                    squareCreator = new OrangeSquareCreator();
                    triangleCreator = new OrangeTriangleCreator();
                    break;
                case "Green":
                    circleCreator = new GreenCircleCreator();
                    squareCreator = new GreenSquareCreator();
                    triangleCreator = new GreenTriangleCreator();
                    break;
                default:
                    return;
            }

            Circle circle = circleCreator.CreateCircle();
            Square square = squareCreator.CreateSquare();
            Triangle triangle = triangleCreator.CreateTriangle();

            for_figures.Children.Add(circle.CreateUIElement());
            for_figures.Children.Add(square.CreateUIElement());
            for_figures.Children.Add(triangle.CreateUIElement());
        }


    }
}
