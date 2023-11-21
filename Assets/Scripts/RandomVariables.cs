using System;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomVariables : MonoBehaviour
{

    public static int bernoulli(double p)
    {
        
        double u = (double)Random.Range(0.0f,1f);
        return (u < p) ? 1 : 0;
    }

    static double logistic(double x){
        return 1.0 / (1.0 + Math.Exp(-x));
    }
    public static int binomial(int n, double p){
        int successes = 0;
        for (int i = 0; i < n; i++){
            if ((double)Random.Range(0.0f,1f)< p)
                successes++;
        }
        return successes;
    }
    static double normal(double mu, double sigma){
        double u1 = 1.0 - (double)Random.Range(0.0f,1f);
        double u2 = 1.0 - (double)Random.Range(0.0f,1f);
        double standardNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        return mu + sigma * standardNormal;
    }
    static double exponential(double lambda)
    {
        double u = (double)Random.Range(0.0f,1f);
        return -Math.Log(1.0 - u) / lambda;
    }
    public static double probabilityOfBiome(double mediaOfBiome, double varianceOfBiome){
        // Geração de variável aleatória normal
        double valorNormal = normal(mediaOfBiome, varianceOfBiome);
        // Aplicação da função logística para transformar em probabilidade
        return logistic(valorNormal);
    }
    public static double uniform(double xMin, double xMax){
        double u = (double)Random.Range(0.0f,1f);
        return xMin + (xMax - xMin) * u;
    }
    // reset numberOfTries to 0 when fish is catched
    public static bool catchAFish(int numberOfTries, double rarity){
        
        Thread.Sleep(Random.Range(0,3)*1000);
        return uniform(1, ObterIntervaloUniforme(rarity)) <= numberOfTries;
    }
    public static int ObterIntervaloUniforme(double rarity){
        double limiteSuperiorBase = 1.0;
        int limiteSuperior = (int)(limiteSuperiorBase * rarity);
        return limiteSuperior;
    }
    public static double ObterProbRaridade(Double rarity, double p){
        return rarity*p;
    }
    public void test(){
        int bernoulliVariable = bernoulli(0.5);
        if (bernoulliVariable == 1){
            // vou assumir que temos 3 raridades diferentes 
            int n = 5;
            // Parâmetros da distribuição normal para cada estação
            double mediaOfBiome = 0.8;
            double varianceOfBiome = 0.2;
            // Estação atual (pode ser ajustada conforme necessário)

            double p = probabilityOfBiome(mediaOfBiome, varianceOfBiome);
            double algo=ObterProbRaridade(0.5,p);
            int binomialRandomVariable = binomial(n, algo);
            if (binomialRandomVariable >= 3){
                // da return da raridade alta
            }
            if (binomialRandomVariable == 2){
                // da return da raridade media
            }
            if (binomialRandomVariable < 2){
                // da return da raridade baixa
            }
        }
        else print("não apanhou nenhum peixe");
    }
}