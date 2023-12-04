using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;
using Random = System.Random;
public class RandomVariables : MonoBehaviour
{
    // Discretas
    public static int bernoulli(double p)
    {
        double u = new Random().NextDouble();
        return (u < p) ? 1 : 0;
    }

    public static int binomial(int n, double p)
    {
        int successes = 0;
        for (int i = 0; i < n; i++)
            successes += bernoulli(p);

        return successes;
    }

    public static int uniformDiscrete(int min, int max)
    {
        return min + (int)((max - min + 1) * uniform(0, 1));
    }

    // Contínuas
    public static double uniform(double xMin, double xMax)
    {
        double u = new Random().NextDouble();
        return xMin + (xMax - xMin) * u;
    }

    public static double erlang(double b, int c)
    {
        double prod = 1.0;
        for (int i = 0; i < c; i++) prod *= uniform(0, 1);
        return -b * Math.Log(prod);
    }
    static double exponential(double lambda)
    {
        double u = new Random().NextDouble();
        return -Math.Log(u) * lambda;
    }
    public static int finalPrice(int price, double lambda){
        return (int)(price*exponential(lambda));
    }

    // Functions
    // reset numberOfTries to 0 when fish is catched
    public static int waitingTime(int c)
    {
        return (int)erlang(1, c) * 1000;
    }

    public static bool catchAFish(int numberOfTries, double mingameScore)
    {
        return uniformDiscrete(0, ObterIntervaloUniforme(mingameScore)) <= numberOfTries;
    }

    // result => [0, 40]
    public static int ObterIntervaloUniforme(double mingameScore)
    {
        double proportion = 0.3;
        return 40 - (int)(mingameScore * proportion);
    }

    public static Level catchAFishByRarity(double isca)
    {
        int binomialRandomVariable = binomial(2, isca);
        return LevelMethods.getLevel(binomialRandomVariable);
    }

    public static void saveFile()
    {
        Int64 x;
        try
        {
            //Open the File
            StreamWriter sw = new StreamWriter("C:\\Users\\alexm\\Desktop\\Worksplace\\Unity\\Fishy-Game-Business-Edition\\Assets\\Results.txt", false, Encoding.ASCII);

            // Variables
            // double isca = 0.8;
            // double minigameScore = 50;
            int c = 0;

            for (x = 0; x < 100000; x++)
            {
                sw.WriteLine((float)erlang(1, c));
            }

            //close the file
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }
}