class Triangle
{
    private double side = 0;
    private double perimet = 0;
    public Triangle(double side)
    {
        this.side = side;
    }
    public double hide()
    {
        return Math.Sqrt(3) / 2 * side;
    }

    public void bisector()
    {
        Console.WriteLine("биссектриса: " + hide());
    }
    public void height()
    {
        Console.WriteLine("высота: " + hide());
    }
    public double perimeter()
    {
        perimet = side*3;
        return perimet;
    }
    public double square()
    {
        return Math.Sqrt(3) / 4 * side * side;
    }
    public void info()
    {
        Console.WriteLine("площадь: " + square());
        Console.WriteLine("периметр: " + perimeter());
        Console.WriteLine("высота: " + hide());
        Console.WriteLine("биссектриса: " + hide());
        Console.WriteLine("Сторона: " + side);
    }
}

class Tetrahedron : Triangle
{
    public double volum = 0;
    private double side = 0;
    public Tetrahedron(double side) : base(side) 
    { 
        this.side = side;
    }
    public double hide()
    {
        return Math.Sqrt(3) / 2 * side;
    }
    public double volume()
    {
        /*volum = (Math.Pow(side, 3) * Math.Sqrt(2))/12;*/
        return square() * hide();
    }

    

    public double perimeter()
    {
        return side * 12;
    }
    public double square()
    {
        return 2 * base.square() + 3 * side * hide();
    }
    public void info()
    {
        Console.WriteLine("периметр: " + perimeter());
        Console.WriteLine("обьем: " + volume());
        Console.WriteLine("площадь: " + square());
        Console.WriteLine("высота: " + hide());
    }
}

class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("введите N равносторонних треугольников: ");

        int n = Int32.Parse(Console.ReadLine());
        Triangle[] mass = new Triangle[n];
        double squerss = 0;
        for (int i = 0; i < n; i++)
        {
            double side = 0;
            Console.WriteLine("введите длинну стороны: ");

            side = double.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            mass[i] = new Triangle(side);
            squerss += mass[i].square();
        }
        Console.WriteLine("Среднее значение площадей треугольников " + (squerss/n) + "\n");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("информация о " + (i + 1) + " треугольнике: "); mass[i].info();
            Console.WriteLine("\n");
        }
        
        Console.Write("введите N пирамид: ");

        int n2 = Int32.Parse(Console.ReadLine());
        Tetrahedron[] mass2 = new Tetrahedron[n2];
        for (int i = 0; i < n2; i++)
        {
            double side = 0;

            Console.WriteLine("введите длинну стороны: ");

            side = double.Parse(Console.ReadLine());
            mass2[i] = new Tetrahedron(side);
            Console.WriteLine("\nинформация о " + (i+1) + " тетраэдере: ");

            mass2[i].info();
        }

        double minvolume = double.MaxValue;
        int index = 0;
        for (int i = 0; i < n2; i++)
        {
            if (minvolume > mass2[i].volume())
            {
                minvolume = mass2[i].volume();
                index = i;
            }
        }
        Console.WriteLine("\nтетраэдер с минимальным обьемом: " + (index+1));
    }
}