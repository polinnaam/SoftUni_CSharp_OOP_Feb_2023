using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private const string PropertyValueExceptionMessage = "{0} cannot be zero or negative.";
        
        private double length;
        private double width;
        private double height;
        public Box (double lenght, double width, double height)
        {
            Length = lenght;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get { return length; }
            private set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentException($"{string.Format(PropertyValueExceptionMessage, nameof(Length))}");
                }
            }
        }
        public double Width 
        {
            get { return width; }
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException($"{string.Format(PropertyValueExceptionMessage, nameof(Width))}");
                }
            }
        }
        public double Height 
        {
            get { return height; }
            private set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException($"{string.Format(PropertyValueExceptionMessage, nameof(Height))}");
                }
            }
        }
        public double SurfaceArea()
        {
            double surfaceArea = (2 * Length * Width) + (2 * Length * this.Height) + ( 2 * Width * Height);
            return surfaceArea;
        }
        public double LateralSurfaceArea()
        {
            return (2 * (Length * Height + Width * Height));
        }
        public double Volume()
        {
            return (Length * Width * Height);
        }
    }
}
