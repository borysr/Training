﻿using Polygon.Library;
using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(5);

            DisplayPolygon("Square", square);

            var triangle = new Triangle(5);
            DisplayPolygon("Triangle", triangle);

            var octagon = new Octagon(5);
            DisplayPolygon("Octagon", octagon);
        }

        private static void DisplayPolygon(string polygonType, dynamic polygon)
        {
            try
            { 
                Console.WriteLine("{0} Number of Sides: {1}", polygonType, polygon.NumberOfSides);
                Console.WriteLine("{0} Side Length: {1}", polygonType, polygon.SideLength);
                Console.WriteLine("{0} Perimeter: {1}", polygonType, polygon.GetPerimeter());
                Console.WriteLine("{0} Area: {1}", polygonType, polygon.GetArea());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown while trying to process {0}:\n   {1}",
                    polygonType, ex.GetType().Name);
                Console.WriteLine();
            }
        }
    }
}
