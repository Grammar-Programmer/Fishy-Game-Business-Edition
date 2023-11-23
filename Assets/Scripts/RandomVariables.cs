using System;
using System.Threading;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomVariables : MonoBehaviour
{

    public static int bernoulli(double p)
    {
        Random random = new Random();
        double u = random.NextDouble();
        return (u < p) ? 1 : 0;
    }

    static double logistic(double x){
        return 1.0 / (1.0 + Math.Exp(-x));
    }
    public static int binomial(int n, double p){
        Random random = new Random();
        int successes = 0;
        for (int i = 0; i < n; i++){
            if (random.NextDouble() < p)
                successes++;
        }
        return successes;
    }
    static double normal(double mu, double sigma){
        Random random = new Random();
        double u1 = 1.0 - random.NextDouble();
        double u2 = 1.0 - random.NextDouble();
        double standardNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        return mu + sigma * standardNormal;
    }
    static double exponential(double lambda)
    {
        Random random = new Random();
        double u = random.NextDouble();
        return -Math.Log(1.0 - u) / lambda;
    }
    public static double probabilityOfBiome(double mediaOfBiome, double varianceOfBiome){
        double valorNormal = normal(mediaOfBiome, varianceOfBiome);
        return valorNormal;
    }
    double uniform(double xMin, double xMax){
        Random random = new Random();
        double u = random.NextDouble();
        return xMin + (xMax - xMin) * u;
    }
    // reset numberOfTries to 0 when fish is catched
    static double waitingTime(double rarityCana)
    {
       // o jogador vai esperar em meida 10000 ms * a raridade da cada 
        double mu = 10000 * (1-rarityCana);
        return NormalRandomVariable(mu, 1000);
    } 

    public bool catchAFish(int numberOfTries, double rarityCana){
        Thread.Sleep(waitingTime(rarityCana));
        return uniform(1, ObterIntervaloUniforme(rarityCana)) <= numberOfTries;
    }
    public static int ObterIntervaloUniforme(double rarityCana,double successGame){ // invés de receber a raidade recebe um valor do mini game1
        double limiteSuperiorBase = 1.0;
        int limiteSuperior = (int)((limiteSuperiorBase * (rarityCana + successGame)));
        return limiteSuperior;
    }
    public static double ObterProbRaridade(double p, double isca){
        return p*isca;
    }


    public static int catchAFishByRarity( double isca){
        

        int binomialRandomVariable = binomial(n, insca );
         if (binomialRandomVariable >    2){
                // da return da raridade alta
                // return nivel 5
        
                return 5
                
            }
            if (binomialRandomVariable == 2){
                // da return da raridade media
                // retorna nivel 3
                return 3
            }
            if (binomialRandomVariable < 2){
                // da return da raridade baixa
                // retorna nivel 1
                return 1
            }

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

            double algo = ObterProbRaridade(0.5,p);
            int binomialRandomVariable = binomial(n, algo);
            if (binomialRandomVariable >= 3){
                // da return da raridade alta
                // return nivel 5
            }
            if (binomialRandomVariable == 2){
                // da return da raridade media
                // retorna nivel 3
            }
            if (binomialRandomVariable < 2){
                // da return da raridade baixa
                // retorna nivel 3
            }
        }
        else print("não apanhou nenhum peixe");
    }
}