using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpm_Lab5
{
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
        public void BeginRender() => Console.WriteLine("[Screen] Start Rendering Session");
        public void EndRender() => Console.WriteLine("[Screen] End Rendering Session");

        public void RenderRectangle(float x, float y, float width, float height)
            => Console.WriteLine($"[Screen] Draw Rect at ({x},{y}) size {width}x{height}");

        public void RenderEllipse(float x, float y, float radiusX, float radiusY)
            => Console.WriteLine($"[Screen] Draw Ellipse at ({x},{y}) radii {radiusX},{radiusY}");

        public void RenderLine(float x1, float y1, float x2, float y2)
            => Console.WriteLine($"[Screen] Draw Line from ({x1},{y1}) to ({x2},{y2})");
    }

    public class PrintRenderer : IRenderingEngine
    {
        public void BeginRender() => Console.WriteLine("[Print] Start Print Job");
        public void EndRender() => Console.WriteLine("[Print] End Print Job");

        public void RenderRectangle(float x, float y, float width, float height)
            => Console.WriteLine($"[Print] Print Rect at ({x},{y}) size {width}x{height}");

        public void RenderEllipse(float x, float y, float radiusX, float radiusY)
            => Console.WriteLine($"[Print] Print Ellipse at ({x},{y}) radii {radiusX},{radiusY}");

        public void RenderLine(float x1, float y1, float x2, float y2)
            => Console.WriteLine($"[Print] Print Line from ({x1},{y1}) to ({x2},{y2})");
    }

    public abstract class GraphicObject : IDrawable
    {
        protected IRenderingEngine _engine;
        protected float _x, _y;

        public GraphicObject(IRenderingEngine engine, float x, float y)
        {
            _engine = engine;
            _x = x;
            _y = y;
        }

        public abstract void Draw();

        public void Move(float dx, float dy)
        {
            _x += dx;
            _y += dy;
        }
    }
    public class Rectangle : GraphicObject
    {
        private float _width, _height;

        public Rectangle(IRenderingEngine engine, float x, float y, float width, float height)
            : base(engine, x, y)
        {
            _width = width;
            _height = height;
        }

        public override void Draw()
        {
            _engine.RenderRectangle(_x, _y, _width, _height);
        }
    }

    public class Ellipse : GraphicObject
    {
        private float _radiusX, _radiusY;

        public Ellipse(IRenderingEngine engine, float x, float y, float radiusX, float radiusY)
            : base(engine, x, y)
        {
            _radiusX = radiusX;
            _radiusY = radiusY;
        }

        public override void Draw()
        {
            _engine.RenderEllipse(_x, _y, _radiusX, _radiusY);
        }
    }

    public class Line : GraphicObject
    {
        private float _x2, _y2;

        public Line(IRenderingEngine engine, float x1, float y1, float x2, float y2)
            : base(engine, x1, y1)
        {
            _x2 = x2;
            _y2 = y2;
        }

        public override void Draw()
        {
            _engine.RenderLine(_x, _y, _x2, _y2);
        }
    }
}
