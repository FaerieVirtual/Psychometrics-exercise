using MathNet.Numerics.Distributions;
using System;

int GenerateRndT() 
{ 
    Random rnd = new();
    int T = rnd.Next(20, 80);
    return T;
}

float TtoPercentile(double T)
{
    var normalDistribution = new Normal(50, 10);
    return MathF.Round((float)normalDistribution.CumulativeDistribution(T)*100, 1);
}

void Main() 
{
    do
    {
        Console.Clear();

        int T = GenerateRndT();
        float Percentile = TtoPercentile(T);

        Random rnd = new();
        int choice = rnd.Next(2) + 1;
        
        switch (choice)
        {
            case 1:
                Console.WriteLine($"Máš T score: {T}. Jaký je percentil?\n");
                double guess1 = Convert.ToDouble(Console.ReadLine());
                if ((float)guess1 >= Percentile - 0.5 && (float)guess1 <= Percentile + 0.5 )
                {
                    Console.WriteLine($"Ano, správně. Percentil je {Percentile}\n\n");
                } else
                {
                    Console.WriteLine($"Špatně. Percentil je {Percentile}\n\n");
                }
                break;
            case 2:
                Console.WriteLine($"Máš Percentil: {Percentile}. Jaký je T score?\n");
                int guess2 = Convert.ToInt16(Console.ReadLine());
                if (guess2 == T)
                {
                    Console.WriteLine($"Ano, správně. T score je {T}\n\n");
                }
                else
                {
                    Console.WriteLine($"Špatně. T je {T}\n\n");
                }
                break;
        }

        Console.ReadLine();
    } while(true);

}

Main();
