using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenFactory;

namespace opt_wfa.Methods.Gen
{
   
    public class GenWorker
    {
        ICrossover _implcrossover;
        IMutation _implmutation;
        IInvertion _implIInvertion;
        private RandomHelper _random;
        
        public GenWorker(ICrossover   _ICrossover,IMutation    _IMutation ,
                         IInvertion   _IInvertion,RandomHelper _random)
        {
            this._implcrossover = _ICrossover;
            this._implmutation = _IMutation;
            this._implIInvertion = _IInvertion;
            this._random = _random;
        }


        public void Crossover(ref Individual Parent1, ref Individual Parent2)
        {
            _implcrossover.Crossover(ref Parent1, ref  Parent2, _random);  
        }
        public Individual Mutation(Individual individual)
        {
            _implmutation.Mutation(ref individual, _random);
            return individual;
        }
        public Individual Inversion(Individual individual)
        {
            _implIInvertion.Invert(ref individual, _random);
            return individual;
        }
     
    }
    

}
