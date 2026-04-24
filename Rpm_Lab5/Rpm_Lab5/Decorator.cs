using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpm_Lab5
{
    public abstract class DrawableDecorator : IDrawable
    {
        protected IDrawable _wrappee;

        public DrawableDecorator(IDrawable wrappee)
        {
            _wrappee = wrappee;
        }

        public virtual void Draw()
        {
            _wrappee.Draw();
        }
    }

    public class BorderDecorator : DrawableDecorator
    {
        private int _borderWidth;

        public BorderDecorator(IDrawable wrappee, int borderWidth) : base(wrappee)
        {
            _borderWidth = borderWidth;
        }

        public override void Draw()
        {
            _wrappee.Draw();
            Console.WriteLine($"   + [Border: {_borderWidth}px]");
        }
    }

    public class ShadowDecorator : DrawableDecorator
    {
        public ShadowDecorator(IDrawable wrappee) : base(wrappee) { }

        public override void Draw()
        {
            _wrappee.Draw();
            Console.WriteLine("   + [Shadow Effect]");
        }
    }

    public class TransparencyDecorator : DrawableDecorator
    {
        private double _opacity;

        public TransparencyDecorator(IDrawable wrappee, double opacity) : base(wrappee)
        {
            _opacity = opacity;
        }

        public override void Draw()
        {
            _wrappee.Draw();
            Console.WriteLine($"   + [Transparency: {_opacity * 100}%]");
        }
    }
}
