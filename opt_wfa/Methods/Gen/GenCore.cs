using opt_wfa.Data_Types;
using opt_wfa.Factory;
using opt_wfa.Methods.Gen.GenFactory;
using opt_wfa.Methods.Gen.GenUnits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace opt_wfa.Methods.Gen
{
    class GenCore
    {
        private iFunc _func;
        private RandomHelper _random;
        private GenWorker _GenWorker;
       // private PopulationWorker _PopulationWorker;
        private double _Pm = 0.1;
        private double _Pc = 0.7;
        private double _Pi = 0.05;
        private int _populationLength = 100;
        private Population _currentPopulation;
        private int N_Populations = 100;
        private double eps = 0.000001;


        gFactory _GF;
        public GenCore(iFunc _func)
        {
            this._func = _func;
            _random = new RandomHelper();
            
            //this._PopulationWorker = new PopulationWorker(_random, this._GenWorker, this._Pc);
            List<Individual> fens = new List<Individual>();
            this._GF = new gFactory(gFactory.GenType.Real);
            for (int i = 0; i < _populationLength; i++)
            {
                fens.Add(new Individual(this._GF.GetGenoTypeImplementation(
                    new Vector(_func.arguments, _random, 20))));
            }
            this._GenWorker = new GenWorker(_random, _Pm, this._GF);
            _currentPopulation = new Population(fens, this._GenWorker);
        }
        public Vector Run()
        {
            int knot = 0;
            int k = 0;
            double avg_old = 0; double avg = 0;
            ABcontainer<int> minmax = new ABcontainer<int>(0, 0);
            while (k < N_Populations)
            {
                _currentPopulation = Fitnesses(_currentPopulation);
                avg_old = avg;
                avg = AvgHelper.AvgFitness(_currentPopulation);
                minmax = AvgHelper.AvgFitnessMinMax(_currentPopulation);
                if ((_currentPopulation.population[minmax.A].Phenotype -
                    _currentPopulation.population[minmax.B].Phenotype).norm() < eps
                    || (Math.Abs(_currentPopulation.population[minmax.A].fitness -
                    _currentPopulation.population[minmax.B].fitness) < eps) || knot > 10)
                {
                    var cool = _currentPopulation.population[minmax.A];
                    break;
                }
                if (Math.Abs(avg_old - avg) < eps)
                {
                    knot++;
                }
                else
                {
                    knot = 0;
                }
                if (k == 0)
                {
                    _currentPopulation.getNextPopulation(); //= this._PopulationWorker.getNextPopulation(_currentPopulation);
                }
                else
                {
                    var strongest = Selection(_currentPopulation, avg);
                    strongest.getNextPopulation();
                    _currentPopulation = strongest;  //this._PopulationWorker.getNextPopulation(strongest);
                }

                k++;
            }
            return _currentPopulation.population[minmax.A].Phenotype;
        }
        private Population Selection(Population allPopulation, double avg)
        {
            
            double avgStrongest = avg * 2;
            Population strongest = new Population(this._GenWorker);
           
            while (avgStrongest > avg)
            {
                strongest = new Population(this._GenWorker);
                while (strongest.population.Count < allPopulation.population.Count / 2)
                {
                    var ind = Tournament(allPopulation);
                    
                    if (strongest.population.Exists(item => item == ind))
                    {
                       
                    }
                    else
                    {
                        strongest.Add(ind);
                    }
                }
                avgStrongest = AvgHelper.AvgFitness(strongest);
            }
            return strongest;
        }
        private Individual Tournament(Population allPopulation)
        {
            Population turnirSet = new Population(this._GenWorker   );
            
            int tcount = 2;
            int i = 0;
            while (turnirSet.population.Count < tcount)
            {

                var d1 = _random.nextDouble();
                i = (int)Math.Round(d1 * (allPopulation.population.Count - 1));
                turnirSet.Add(allPopulation.population[i]);
            }
            Individual ind = AvgHelper.FindBest(turnirSet);
            return ind;
        }
       
        private Population Fitnesses(Population population)
        {
            for (int i = 0; i < population.population.Count; i++)
            {
                population.population[i].fitness = Fitness(population.population[i]);
            }
            return population;
        }
        
       
        private double Fitness(Individual individual)
        {
            return _func.f(individual.Phenotype);
        }

    }

    public class AvgHelper
    {
        public static Individual FindBest(Population turnirset)
        {
            var Ab = AvgFitnessMinMax(turnirset);
            return turnirset.population[Ab.A];
        }
        public static ABcontainer<int> AvgFitnessMinMax(Population population)
        {

            double min = population.population.Min(item => item.fitness);
            double max = population.population.Max(item => item.fitness);
            int imin = population.population.FindIndex(item => item.fitness == min);
            int imax = population.population.FindIndex(item => item.fitness == max);
            ABcontainer<int> MinMax = new ABcontainer<int>(imin, imax);
            return MinMax;
        }
        public static double AvgFitness(Population population)
        {

            double sum = population.population.Sum(item => item.fitness);
            double avg = sum / population.population.Count;
            return avg;
        }

    }
    
    

}
