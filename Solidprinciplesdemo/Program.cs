using System;

namespace Solidprinciplesdemo
{

    //Single responsibility Principle 
    public class DefineImage
    {

        int height;
        int length;
        int width;

        float area;

        void CalulateArea(int height, int length)
        {
            this.area = height * length;
        }
        void CalulateVolume() { }
        void PlotImageOnChart() { }

    }

    public class Dimensions
    {
        public int height;
        public int length;
        public int width;


    }

    public class ImageCalculations
    {
        public double CalulateArea(int height, int length)
        {
            return height * length;
        }
    }


    //Open Closed Principle 

    public class PlotGraph : Dimensions
    {
        int x;
        int y;

        public void PlotXCoordinates() {

        }
        public void PlotYCoordinates()
        {

        }
    }

    // Liskov Substitution principle 

    /// <summary>
    /// Add circle to the project 
    /// </summary>
    /// 


    interface IArea
    {
        double CalulateArea(int radius);        
    }

    public class Circle : Dimensions, IArea
    {
        int radius;
        public double CalulateArea(int radius)
        {
            return 3.14 * radius * radius;
        }
    }

    public class Square : Dimensions, IArea
    {
        
        public double CalulateArea(int radius)
        {
            return length * length;
        }
    }

    //Interface Seggregation Principle 
    //Calculate angle of arc 

    public interface IArcAngle {
        double CalcualteAngleOfAnArc();
    }



    //Dependency Injection 
    public static class ImageTypeResolver
    {
        private static IArea area;
        internal static IArea Area { get => area; set => area = value; }

        // public static string imgType;
        public static void ResolveType(string imgType)
        {
            if (imgType == "Circle")
                Area = new Circle();
            else if (imgType == "Square")
                Area =  new Square();
            else
                Area =  new Circle();
        }



    }

    class Program

    {
        public static object ImageType { get; private set; }

        static void Main(string[] args)
        {

            //Dependency Injection Principle 

            double _area;

           
            if (args[0].ToString() == "Circle")
            {
                Circle _circle = new Circle();
                _area = _circle.CalulateArea(4);
            }
            else if (args[0].ToString() == "Square")
            {
                Square _square = new Square();
                _area = _square.CalulateArea(4);
            }
            else
            {
                ImageCalculations _imgArea = new ImageCalculations();
                _area = _imgArea.CalulateArea(1, 2);  
            }


            //new way  

              ImageTypeResolver.ResolveType(args[0].ToString());
              ImageTypeResolver.Area.CalulateArea(4);

            Console.WriteLine(_area);
           
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
