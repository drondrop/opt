using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenOperators;
using System;
using System.Linq;
namespace opt_wfa.Methods.Gen
{
   
    public class GenWorker
    {
        ICrossover _implcrossover;
        IMutation _implmutation;
        IInvertion _implIInvertion;
        private RandomHelper _random;
        public GenWorker(RandomHelper _random, double _Pm,gFactory fc)
        {
            _implcrossover = fc.GetCrossoverImplementation(gFactory.CrossoverType.OnePoint);//(//new CrossoverOnePoint();
            _implmutation =fc.GetMutationImplementation(gFactory.MutationType.Default);// new Mutation1(_Pm);
            this._random = _random;
        }
        public void Crossover(ref Individual Parent1, ref Individual Parent2)
        {

            //Individual A = new Individual(Parent.A.Genotype);
            //Individual B = new Individual(Parent.B.Genotype);
            _implcrossover.Crossover(ref Parent1, ref  Parent2, _random);
           //Parent.A = A;
           //Parent.B = B;
           //return Parent ;
        }
        public Individual Mutation(Individual individual)
        {
            _implmutation.Mutation(ref individual, _random);
            return individual;
        }
        public Individual Inversion(Individual individualForInversion)
        {
            return individualForInversion;
        }
     
    }
    //public class PopulationWorker
    //{
    //    private double _Pc = 0.845;
    //    private RandomHelper _random;
    //    private GenWorker _GenWorker;

    //    public PopulationWorker(RandomHelper _random,GenWorker _GenWorker, double _Pc)
    //    {
    //        this._GenWorker = _GenWorker;
    //        this._Pc = _Pc;
    //        this._random = _random;
    //    }
    //    //public Population<Individual> getNextPopulation(Population<Individual> parentPopulation)
    //    //{
    //    //    Population<Individual> childP = new Population<Individual>();
    //    //    Population<Individual> ParentWhoNotChildP = new Population<Individual>();
    //    //    for (int k = 0; k < parentPopulation.population.Count; k += 1)
    //    //    {
    //    //        int i = 0;
    //    //        int j = 0;
    //    //        while (i == j)
    //    //        {
    //    //            var d1 = _random.nextDouble();
    //    //            var d2 = _random.nextDouble();
    //    //            i = (int)Math.Round(d1 * (parentPopulation.population.Count - 1));
    //    //            j = (int)Math.Round(d2 * (parentPopulation.population.Count - 1));
    //    //        }
    //    //        if (_Pc > _random.nextDouble())
    //    //        {
    //    //            ABcontainer<Individual> parents = new ABcontainer<Individual>(
    //    //        parentPopulation.population[i],
    //    //        parentPopulation.population[j]);


    //    //            ABcontainer<Individual> children = this._GenWorker.Crossover(parents);

    //    //            childP.Add(this._GenWorker.Mutation(children.A));
    //    //            childP.Add(this._GenWorker.Mutation(children.B));
    //    //        }
    //    //        else
    //    //        {
    //    //            ParentWhoNotChildP.Add(parentPopulation.population[i]);
    //    //            ParentWhoNotChildP.Add(parentPopulation.population[j]);
    //    //        }




    //    //    }
    //    //    childP.AddRange(ParentWhoNotChildP.population);
    //    //    if (childP.population.Count != parentPopulation.population.Count * 2)//не теряем особей!
    //    //        throw new Exception();
    //    //    return childP;
    //    //}

    //    //public Population<Individual> Mutation(Population<Individual> childrenPopulation)
    //    //{
    //    //    int gensLength = childrenPopulation.population.FirstOrDefault().GenotypeLength;
    //    //    int lengthP = childrenPopulation.population.Count;
    //    //    for (int k = 0; k < lengthP; k++)
    //    //    {
    //    //        childrenPopulation.population[k] = this._GenWorker.Mutation(childrenPopulation.population[k]);
    //    //    }
    //    //    return childrenPopulation;
    //    //}

    //    //public Population<Individual> Inversion(Population<Individual> population)
    //    //{
    //    //    return population;
    //    //}

    //}

}
