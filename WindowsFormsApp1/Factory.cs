using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Factory
    {
        public abstract Figures Create();
    }

    public class FPens: Factory
    {
        public override Figures Create()
        {
            return new Pens();
        }
    }

    public class FSquare : Factory
    {
        public override Figures Create()
        {
            return new Square();
        }
    }

    public class FLine : Factory
    {
        public override Figures Create()
        {
            return new Line();
        }
    }

    public class FEllipse : Factory
    {
        public override Figures Create()
        {
            return new Ellipse();
        }
    }

    public class FTriangle : Factory
    {
        public override Figures Create()
        {
            return new Triangle();
        }
    }

}
