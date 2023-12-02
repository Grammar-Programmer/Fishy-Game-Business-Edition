using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
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

    public static double normal(double mu, double sigma)
    {
        double p, p1, p2;
        do
        {
            p1 = uniform(-1, 1);
            p2 = uniform(-1, 1);
            p = p1 * p1 + p2 * p2;
        } while (p >= 1);

        return mu + sigma * p1 * Math.Sqrt(-2 * Math.Log(p) / p);
    }
    static double exponential(double lambda)
    {
        double u = new Random().NextDouble();
        return -Math.Log(u) * lambda;
    }

    // Functions
    // reset numberOfTries to 0 when fish is catched
    public static int waitingTime(double rarityCana)
    {
        // o jogador vai esperar em meida 10000 ms * a raridade da cada 
        double mu = 10000 * (1 - rarityCana);
        return (int)(normal(mu, 1000));
    }

    public static bool catchAFish(int numberOfTries, double mingameScore)
    {
        return uniformDiscrete(0, ObterIntervaloUniforme(mingameScore)) <= numberOfTries;
    }

    // result => [0, 20]
    public static int ObterIntervaloUniforme(double mingameScore)
    {
        double proportion = 0.2;
        return 20 - (int)(mingameScore * proportion);
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
            double minigameScore = 0.0;

            for (x = 0; x < 100000; x++)
            {
                sw.WriteLine(uniformDiscrete(0, ObterIntervaloUniforme(minigameScore)));
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