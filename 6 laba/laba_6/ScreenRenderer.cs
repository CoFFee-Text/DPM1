using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    // Интерфейс реализатора (способ отрисовки)
    public interface IRenderingEngine
    {
        void BeginRender();
        void EndRender();
        void RenderRectangle(float x, float y, float width, float height);
        void RenderEllipse(float x, float y, float radiusX, float radiusY);
        void RenderLine(float x1, float y1, float x2, float y2);
    }
    public class ScreenRenderer : IRenderingEngine
    {
        public void BeginRender()
        {
            Console.WriteLine("[Screen] The beginning of rendering");
        }

        public void EndRender()
        {
            Console.WriteLine("[Screen] The end of rendering");
        }

        public void RenderRectangle(float x, float y, float width, float height)
        {
            Console.WriteLine($"[Screen] Rectangle ({x},{y}) size {width} x{height}");
        }

        public void RenderEllipse(float x, float y, float radiusX, float radiusY)
        {
            Console.WriteLine($"[Screen] Ellipse ({x},{y}) radii {radiusX},{radiusY}");
        }

        public void RenderLine(float x1, float y1, float x2, float y2)
        {
            Console.WriteLine($"[Screen] Line from ({x1},{y1}) to ({x2},{y2})");
        }
    }

    public class PrintRenderer : IRenderingEngine
    {
        public void BeginRender()
        {
            Console.WriteLine("[Print] The beginning of rendering");
        }

        public void EndRender()
        {
            Console.WriteLine("[Print] The end of rendering");
        }

        public void RenderRectangle(float x, float y, float width, float height)
        {
            Console.WriteLine($"[Print] Rectangle ({x},{y}) size {width} x{height}");
        }

        public void RenderEllipse(float x, float y, float radiusX, float radiusY)
        {
            Console.WriteLine($"[Print] Ellipse ({x},{y}) radii {radiusX},{radiusY}");
        }

        public void RenderLine(float x1, float y1, float x2, float y2)
        {
            Console.WriteLine($"[Print] Line from ({x1},{y1}) to ({x2},{y2})");
        }
    }
}