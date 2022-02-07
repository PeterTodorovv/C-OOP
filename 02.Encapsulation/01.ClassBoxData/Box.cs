using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    class Box
    {
        private double lenght;
        private double width;
        private double height;

        public double Lenght { get => lenght; set { 
                if (value <= 0) 
                {
                    throw new ArgumentException($"Lenght cannot be zero or negative.");
                } 
            } 
        }
        public double Width { get => width; set{
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
            }
        } 
        public double Height { get => height; set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
            }
        }

    }
}
