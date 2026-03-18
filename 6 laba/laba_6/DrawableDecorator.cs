using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    public abstract class DrawableDecorator : IDrawable // decorator 
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
    // Декоратор рамки
    public class BorderDecorator : DrawableDecorator
    {
        private int _borderWidth;

        public BorderDecorator(IDrawable wrappee, int borderWidth) : base(wrappee)

        {
            _borderWidth = borderWidth;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Frame thickness {_borderWidth}]");
        }
    }

    // Декоратор тени
    public class ShadowDecorator : DrawableDecorator
    {
        private int _blurRadius;

        public ShadowDecorator(IDrawable wrappee, int blurRadius) : base(wrappee)
        {
            _blurRadius = blurRadius;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Shadow with blur {_blurRadius}]");
        }
    }

    // Декоратор прозрачности
    public class TransparencyDecorator : DrawableDecorator
    {
        private int _alphaChannel;

        public TransparencyDecorator(IDrawable wrappee, int alphaChannel) : base(wrappee)
        {
            _alphaChannel = alphaChannel;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Transparency: {_alphaChannel}]");
        }
    }
}
