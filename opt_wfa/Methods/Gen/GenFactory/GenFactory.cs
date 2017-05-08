using opt_wfa.Data_Types;

using System;
using System.Collections.Generic;

namespace opt_wfa.Methods.Gen.GenFactory
{
    public partial class gFactory
    {
        public enum GenType { Binary, Real };
        public enum CrossoverType { OnePoint, TwoPoint };
        public enum MutationType { Default };
        public enum InvertionType { Default };


        private GenType _GenType;
        
        public gFactory(GenType _GenType)
        {
            this._GenType = _GenType;
            
        }

        public IGenOperator GetIGenOperatorImplementation()
        {
            IGenOperator ret;
            switch (_GenType)
            {
                case GenType.Binary:
                    ret = new IntGenOperator();
                    break;
                case GenType.Real:
                    ret = new RealGenOperator();
                    break;
                default:
                    ret = new RealGenOperator();
                    break;
            }
            return ret;
        }
        public GenoType GetGenoTypeImplementation(Vector _phenotype)
        {

            GenoType ret;
            switch (_GenType)
            {
                case GenType.Binary:
                    ret = new GenoTypeInt(_phenotype.Array);
                    break;
                case GenType.Real:
                    ret = new GenoTypeDouble(_phenotype.Array);
                    break;
                default:
                    ret = new GenoTypeDouble(_phenotype.Array);
                    break;
            }
            return ret;
        }
        
        public ICrossover GetCrossoverImplementation(CrossoverType _CrossoverType)
        {
            ICrossover ret;
            switch (_CrossoverType)
            {
                case CrossoverType.OnePoint:
                    ret = new CrossoverOnePoint(this.GetIGenOperatorImplementation());
                    break;
                case CrossoverType.TwoPoint:
                    ret = new CrossoverTwoPoint(this.GetIGenOperatorImplementation());
                    break;
                default:
                    ret = new CrossoverOnePoint(this.GetIGenOperatorImplementation());
                    break;
            }
            return ret;
        }
        public IMutation GetMutationImplementation(MutationType _MutationType,double _Pm)
        {
            IMutation ret;
            switch (_MutationType)
            {
                case MutationType.Default:
                    ret = new Mutation1(this.GetIGenOperatorImplementation(), _Pm);
                    break;

                default:
                    ret = new Mutation1(this.GetIGenOperatorImplementation(), _Pm);
                    break;
            }
            return ret;
        }
        public IInvertion GetInvertionImplementation(InvertionType _InvertionType,double _Pi)
        {
            IInvertion ret;
            switch (_InvertionType)
            {
                case InvertionType.Default:
                    ret = new ConcreteInvertion(this.GetIGenOperatorImplementation(), _Pi);
                    break;

                default:
                    ret = new ConcreteInvertion(this.GetIGenOperatorImplementation(), _Pi);
                    break;
            }
            return ret;
        }
        private  class GenoTypeDouble :GenoTypeDoubleA, GenoType
        {
            public GenoTypeDouble(double[] massIn)
            {
                this.phenLength = massIn.Length;
                //  this.genoType = new List<double>(massIn);
                Coder(massIn);

            }
        }
        private class GenoTypeInt : GenoTypeIntA, GenoType
        {
        public GenoTypeInt(double[] massIn)
            {
                this.phenLength = massIn.Length;
                //  this.genoType = new List<double>(massIn);
                Coder(massIn);

            }
        }
    } 
   
}
