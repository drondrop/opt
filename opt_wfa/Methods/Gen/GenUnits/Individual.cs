using opt_wfa.Data_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen.GenUnits
{
    public class Individual
    {
        private GenoType _genotype;
        private double _fitness;
        private int length;
        public Individual(GenoType _GenoType)
        {
            // this._phenotype = _phenotype;
            this._genotype = _GenoType.Clone();
        }
        public double fitness { get { return _fitness; } set { _fitness = value; } }
        public Vector Phenotype
        {
            get
            {
                return _genotype.GetPhenoType();
            }
        }
        public GenoType Genotype { get { return _genotype; } set { _genotype = value; } }
        public int PhenotypeLength { get { return length; } }
        public int GenotypeLength { get { return _genotype.length; } }
    }
   
}
