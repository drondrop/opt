using opt_wfa.Data_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen.GenOperators
{
   public  class GenOperatorBase
   {
       
       protected IGenOperator _GenOperator;//=new RealGenOperator();
       protected    GenOperatorBase(IGenOperator _IGenOperator)
        {
          _GenOperator=_IGenOperator;
        }
   }
  public interface IGenOperator
   {
      void Mutate(ref Individual A, double _Pm, RandomHelper rnd);
      
     //  public void Invert();

      void Cross(ref Individual A, ref Individual B, double Position);
   }
    public class RealGenOperator:IGenOperator
    {
        public void Cross(ref Individual A, ref Individual B, double Position)
        {
            int gensLength = A.GenotypeLength;
            int genPoint = (int)Math.Round(Position * gensLength);
            for (int i = 0; i < A.GenotypeLength; i++)
            {
                if (i < genPoint)
                {
                  ((GenoTypeDouble)  A.Genotype).GenoType[i] =  ((GenoTypeDouble) A.Genotype).GenoType[i];
                  ((GenoTypeDouble)B.Genotype).GenoType[i] = ((GenoTypeDouble)B.Genotype).GenoType[i];
                }
                else
                {
                    ((GenoTypeDouble)A.Genotype).GenoType[i] = ((GenoTypeDouble)B.Genotype).GenoType[i];
                    ((GenoTypeDouble)B.Genotype).GenoType[i] = ((GenoTypeDouble)A.Genotype).GenoType[i];
                }
            }
        }

        public void Mutate(ref Individual A, double _Pm, RandomHelper rnd)
        {
            int gensLength = A.Genotype.length;
            for (int i = 0; i < gensLength; i++)
            {
                if (_Pm > rnd.nextDouble())
                {
                    ((GenoTypeDouble)A.Genotype).GenoType[i] += rnd.nextDouble() - 0.5;
                }
            }
        }
    }

    public class IntGenOperator : IGenOperator
    {
        public void Cross(ref Individual A, ref Individual B, double Position)
        {
            int genLength = 12;
            int gensLength = A.GenotypeLength;
            int genPointIngen = (int)Math.Round(Position * genLength);
            int genPoint = (int)Math.Round(Position * gensLength);
            for (int i = 0; i < A.GenotypeLength; i++)
            {
                //if (i == genPoint)
                //{
                //    A.Genotype[i] = A.Genotype[i];
                //    B.Genotype[i] = B.Genotype[i];


                //    int mask = (int)Math.Round(Math.Pow(2, i + 1) - 1); // какие биты менять, а какие нет (1-обмениваем битами, 0-оставляем)
                //    int swapMask = ((int)A.Genotype[i] ^ (int)B.Genotype[i]) & mask;

                //    int res1 = (int)A.Genotype[i];
                //    int res2 = (int)B.Genotype[i];

                //    res1 ^= swapMask;
                //    res2 ^= swapMask;
                //    A.Genotype[i] = res1;
                //    B.Genotype[i] = res2;

                //}
                //if (i < genPoint)
                //{
                //    A.Genotype[i] = A.Genotype[i];
                //    B.Genotype[i] = B.Genotype[i];
                //}
                //if (i > genPoint)
                //{
                //    A.Genotype[i] = B.Genotype[i];
                //    B.Genotype[i] = A.Genotype[i];
                //}
            }
        }

        public void Mutate()
        {
            throw new NotImplementedException();
        }

        public void Mutate(ref Individual A, double _Pm, RandomHelper rnd)
        {
            throw new NotImplementedException();
        }
    }




    public class gFactory
    {
        public enum GenType { Binary, Real };
        public enum CrossoverType { OnePoint, TwoPoint };

        public enum MutationType { Default };
        public enum InvertionType { Default};
        private GenType _GenType;
        private Type gType;
        public gFactory(GenType _GenType)
        {
            this._GenType = _GenType;
            switch (_GenType)
            {
                case GenType.Binary :
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
                default :
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
