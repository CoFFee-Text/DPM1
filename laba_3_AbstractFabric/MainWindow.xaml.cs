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

namespace laba_3_AbstractFabric
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFigureFactory currentFactory;
        public MainWindow()
        {
            InitializeComponent();
        }

       
        public interface IFigureFactory
        {
            Circle CreateCircle();
            Square CreateSquare();
            Triangle CreateTriangle();
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

        // colors //
        public class RedFactory : IFigureFactory
        {
            public Circle CreateCircle() => new Circle
            {
                Color = Colors.Red
            };
            public Square CreateSquare() => new Square
            {
                Color = Colors.Red
            };
            public Triangle CreateTriangle() => new Triangle
            {
                Color = Colors.Red
            };
        }

        public class OrangeFactory : IFigureFactory
        {
            public Circle CreateCircle() => new Circle
            {
                Color = Colors.Orange
            };
            public Square CreateSquare() => new Square
            {
                Color = Colors.Orange
            };
            public Triangle CreateTriangle() => new Triangle
            {
                Color = Colors.Orange
            };
        }

        public class GreenFactory : IFigureFactory
        {
            public Circle CreateCircle() => new Circle
            {
                Color = Colors.Green
            };
            public Square CreateSquare() => new Square
            {
                Color = Colors.Green
            };
            public Triangle CreateTriangle() => new Triangle
            {
                Color = Colors.Green
            };
        }

        private void SelectedIndexColorList(object sender, SelectionChangedEventArgs e)
        {
            for_figures.Children.Clear();

            string selectedItem = ((TextBlock)colorsList.SelectedItem).Text;


            switch (selectedItem)
            {
                case "Red":
                    currentFactory = new RedFactory();
                    break;
                case "Orange":
                    currentFactory = new OrangeFactory();
                    break;
                case "Green":
                    currentFactory = new GreenFactory();
                    break;
                default:
                    return;
            }

            //Создаем фигуры, используя только абстракцию IFigureFactory
            var circle = currentFactory.CreateCircle();
            var square = currentFactory.CreateSquare();
            var triangle = currentFactory.CreateTriangle();

            for_figures.Children.Add(circle.CreateUIElement());
            for_figures.Children.Add(square.CreateUIElement());
            for_figures.Children.Add(triangle.CreateUIElement());
        }
    }
}
