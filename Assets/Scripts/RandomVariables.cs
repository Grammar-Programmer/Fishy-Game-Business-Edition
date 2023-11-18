using System;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomVariables: MonoBehaviour{

    public static int bernoulli(double p){
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
    static double exponential(double lambda){
        Random random = new Random();
        double u = random.NextDouble();
        return -Math.Log(1.0 - u) / lambda;
    }
    public static double ProbabilidadePescarNaEstacao(string estacao, double muVerao, double sigmaVerao, double muOutonoInverno, double sigmaOutonoInverno){
        // Geração de variável aleatória normal
        double valorNormal;
        if (estacao.ToLower() == "verao" || estacao.ToLower() == "primavera") valorNormal = normal(muVerao, sigmaVerao);
        else valorNormal = normal(muOutonoInverno, sigmaOutonoInverno);
        // Aplicação da função logística para transformar em probabilidade
        double probabilidade = logistic(valorNormal);
        return probabilidade;
    }
    bool catchAFish(int numberOfTries){
        double probability=0.1;
        int medianTries=5;
        int HighTries=9;
        if(numberOfTries>=HighTries) probability=0.9;
        else if(numberOfTries>=medianTries) probability=0.5;
        return 1== bernoulli(probability);
    }
    public void test(){
        int bernoulliVariable = bernoulli(0.5);
        if( bernoulliVariable == 1){
            // vou assumir que temos 3 raridades diferentes 
            int n = 5;
            // Parâmetros da distribuição normal para cada estação
            double muVerao = 0.8;
            double sigmaVerao = 0.2;
            double muOutonoInverno = 0.5;
            double sigmaOutonoInverno = 0.3;

            // Estação atual (pode ser ajustada conforme necessário)
            string estacao = "verao";

            double p = ProbabilidadePescarNaEstacao(estacao, muVerao, sigmaVerao, muOutonoInverno, sigmaOutonoInverno);;		
            int binomialRandomVariable = binomial(n, p);
            if( binomialRandomVariable >= 3 ){
                // da return da raridade alta
            }if( binomialRandomVariable == 2){
                // da return da raridade media
            }
            if( binomialRandomVariable < 2){
                // da return da raridade baixa
                }
        }else print("não apanhou nenhum peixe");
    }
}