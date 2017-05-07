using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen
{
    public class Population
    {
        GenWorker _GenWorker;//=new GenWorker(new RandomHelper(), 0.1);
        public void Add(Individual item)
        {
            _population.Add(item);
        }
        public void AddRange(IEnumerable<Individual> collection)
        {
            _population.AddRange(collection);
        }

        public Population(gFactory fc)
        {
            _GenWorker=new GenWorker(new RandomHelper(), 0.1,fc);
            _population = new List<Individual>();
        }

        public Population(List<Individual> _population, gFactory fc)
        {
            _GenWorker = new GenWorker(new RandomHelper(), 0.1, fc);
            this._population = _population;
        }
        public Population(Population Population)
        {
            _GenWorker = Population._GenWorker;
            this._population = Population.population;
        }


        private int _populationGensLength;
        public int populationGensLength { get { return _populationGensLength; } }
        
        private List<Individual> _population;
        public List<Individual> population
        {
            get { return _population; }
        }



        public void  getNextPopulation( )
        {
            List<Individual> childP = new List<Individual>();
            List<Individual> ParentWhoNotChildP = new List<Individual>();
            var _random =new RandomHelper();
           double _Pc = 0.7;
            for (int k = 0; k < this.population.Count; k += 1)
            {
                int i = 0;
                int j = 0;
                while (i == j)
                {
                    var d1 = _random.nextDouble();
                    var d2 = _random.nextDouble();
                    i = (int)Math.Round(d1 * (this.population.Count - 1));
                    j = (int)Math.Round(d2 * (this.population.Count - 1));
                }
                if (_Pc > _random.nextDouble())
                {
                //    ABcontainer<Individual> parents = new ABcontainer<Individual>(
                //this.population[i],
                //this.population[j]);
                    Individual p1 = new Individual(population[i].Genotype);
                    Individual p2 = new Individual(population[j].Genotype);
                    this._GenWorker.Crossover(ref p1, ref p2);

                    childP.Add(this._GenWorker.Mutation(p1));
                    childP.Add(this._GenWorker.Mutation(p2));
                }
                else
                {
                    ParentWhoNotChildP.Add(this.population[i]);
                    ParentWhoNotChildP.Add(this.population[j]);
                }




            }
            childP.AddRange(ParentWhoNotChildP);
            if (childP.Count != this.population.Count * 2)//не теряем особей!
                throw new Exception();
            this._population=childP;

            
        }
        public void  Mutation()
        {
            int gensLength = this.population.FirstOrDefault().GenotypeLength;
            int lengthP =  this.population.Count;
            for (int k = 0; k < lengthP; k++)
            {
                this.population[k] = this._GenWorker.Mutation( this.population[k]);
            }
            
        }
        public void Inversion()
        {
           
        }

    }
}
