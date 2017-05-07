using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenOperators;
using opt_wfa.Methods.Gen.GenUnits;
using System;

namespace opt_wfa.Methods.Gen.GenFactory
{
    public class gFactory
    {
        public enum GenType { Binary, Real };
        public enum CrossoverType { OnePoint, TwoPoint };

        public enum MutationType { Default };
        public enum InvertionType { Default };
        private GenType _GenType;
        private Type gType;
        public gFactory(GenType _GenType)
        {
            this._GenType = _GenType;
            switch (_GenType)
            {
                case GenType.Binary:
                    gType = typeof(int);
                    break;
                case GenType.Real:
                    gType = typeof(double);
                    break;
                default:
                    gType = typeof(double);
                    break;


            }
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
                    ret = new GenoTypeInt();
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
        public IMutation GetMutationImplementation(MutationType _MutationType)
        {
            IMutation ret;
            switch (_MutationType)
            {
                case MutationType.Default:
                    ret = new Mutation1(0.1, this.GetIGenOperatorImplementation());
                    break;

                default:
                    ret = new Mutation1(0.1, this.GetIGenOperatorImplementation());
                    break;
            }
            return ret;
        }
        public IInvertion GetInvertionImplementation(InvertionType _InvertionType)
        {
            IInvertion ret;
            switch (_InvertionType)
            {
                case InvertionType.Default:
                    ret = new ConcreteInvertion(this.GetIGenOperatorImplementation());
                    break;

                default:
                    ret = new ConcreteInvertion(this.GetIGenOperatorImplementation());
                    break;
            }
            return ret;
        }
    } 
   
}
