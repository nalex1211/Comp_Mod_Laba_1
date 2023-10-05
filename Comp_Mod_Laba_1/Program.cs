//using System;

//class Program
//{
//    static double Function(double x)
//    {
//        return (Math.Log(x) * Math.Sin(x)) / (Math.Pow(x, 4) + 1);
//    }

//    static double SimpsonRule(double a, double b, int n)
//    {
//        double h = (b - a) / n;
//        double sum = Function(a) + Function(b);

//        for (int i = 1; i < n; i += 2)
//        {
//            sum += 4 * Function(a + i * h);
//        }

//        for (int i = 2; i < n - 1; i += 2)
//        {
//            sum += 2 * Function(a + i * h);
//        }

//        return (h / 3) * sum;
//    }

//    static void Main()
//    {
//        double a = 1.0;
//        double b = 10.0;
//        int n = 4;
//        double epsilon = 1e-4;
//        double currentEstimate, previousEstimate;

//        previousEstimate = SimpsonRule(a, b, n);
//        n *= 2;

//        do
//        {
//            currentEstimate = SimpsonRule(a, b, n);
//            double diff = Math.Abs(currentEstimate - previousEstimate);
//            if (diff < epsilon)
//                break;

//            previousEstimate = currentEstimate;
//            n *= 2;

//        } while (true);

//        Console.WriteLine($"Integral Estimate: {currentEstimate}");
//        Console.WriteLine($"Number of Intervals: {n}");
//    }
//}

class Program
{
    static double Function(double x)
    {
        return 1.0 / Math.Sqrt(x * (1 + x * x));
    }

    static double SimpsonRule(double a, double b, int n)
    {
        double h = (b - a) / n;
        double sum = Function(a) + Function(b);

        for (int i = 1; i < n; i += 2)
        {
            sum += 4 * Function(a + i * h);
        }

        for (int i = 2; i < n - 1; i += 2)
        {
            sum += 2 * Function(a + i * h);
        }

        return (h / 3) * sum;
    }

    static void Main()
    {
        double a = 0.01;
        double b = 1.0;
        int n = 4;
        double epsilon = 0.5;
        double currentEstimate, previousEstimate;


        double singularIntegral = SimpsonRule(a, b, n);
        previousEstimate = singularIntegral;

        n *= 2;

        do
        {
            currentEstimate = SimpsonRule(a, b, n);
            if (Math.Abs(currentEstimate - previousEstimate) < epsilon)
                break;

            previousEstimate = currentEstimate;
            n *= 2;

        } while (true);

        Console.WriteLine($"Integral Estimate: {currentEstimate}");
        Console.WriteLine($"Number of Intervals: {n}");
    }
}
