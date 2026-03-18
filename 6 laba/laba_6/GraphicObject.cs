using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    public abstract class GraphicObject : IDrawable
    {
        protected IRenderingEngine _engine;
        public GraphicObject(IRenderingEngine engine)
        {
            _engine = engine;
        }
        public abstract void Draw();
        public abstract void Move(float dx, float dy);
    }

    public class Rectangle : GraphicObject
    {
        private float _x, _y, _width, _height;
        public Rectangle(float x, float y, float width, float height, IRenderingEngine engine) : base(engine)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public override void Draw()
        {
            // Вызываем соответствующий метод рендеринга для прямоугольника
            _engine.RenderRectangle(_x, _y, _width, _height);
        }
        public override void Move(float dx, float dy)
        {
            _x += dx;
            _y += dy;
            Console.WriteLine($"The rectangle has been moved to ({dx}, {dy}). New coordinates: ({_x}, {_y})");
        }
    }

    public class Ellipse : GraphicObject
    {
        private float _x, _y, _radiusX, _radiusY;
        public Ellipse(float x, float y, float radiusX, float radiusY, IRenderingEngine engine) : base(engine)
        {
            _x = x;
            _y = y;
            _radiusX = radiusX;
            _radiusY = radiusY;
        }

        public override void Draw()
        {
            // Вызываем соответствующий метод рендеринга для прямоугольника
            _engine.RenderEllipse(_x, _y, _radiusX, _radiusY);
        }
        public override void Move(float dx, float dy)
        {
            _x += dx;
            _y += dy;
            Console.WriteLine($"The Ellipse has been moved to ({dx}, {dy}). New coordinates: ({_x}, {_y})");
        }
    }

    public class Line : GraphicObject
    {
        private float _x1, _y1, _x2, _y2;
        public Line(float x1, float y1, float x2, float y2, IRenderingEngine engine) : base(engine)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        public override void Draw()
        {
            // Вызываем соответствующий метод рендеринга для прямоугольника
            _engine.RenderLine(_x1, _y1, _x2, _y2);
        }
        public override void Move(float dx, float dy)
        {
            _x1 += dx;
            _y1 += dy;
            _x2 += dx;
            _y2 += dy;
            Console.WriteLine($"The Line has been moved to ({dx}, {dy}). New coordinates: ({_x1},{_y1}) - ({_x2},{_y2})");
        }
    }
}
