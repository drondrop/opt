using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenFactory;
using opt_wfa.Methods.Gen.GenUnits;
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
    

}
