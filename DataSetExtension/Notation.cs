using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// alphabet generate
// tests for stringTransform

namespace DataSetExtension
{
    public sealed class Notation
    {
        private int @base;
        private string alphabet;

        private const int LowerBase = 2;
        private const int UpperBase = 16;

        public int Base
        {
            get => @base;
            private set
            {
                if (value < LowerBase || value > UpperBase)
                {
                    throw new ArgumentOutOfRangeException("base is invalid");// to
                }
                @base = value;
                alphabet = Notation.GenerateAlphabet(@base);

            }
        }

        public string Alphabet => alphabet;

        public Notation(int @base)
        {
            Base = @base;

        }

        private static  string GenerateAlphabet(int @base) {

            char[] alphabet=new char[@base];

            for (int i = 0; i < @base; i++)
            {
                alphabet[i] = i < 10 ? (char)(i + 48) : (char)(i + 55);
            }
            return new string(alphabet);
            }
        }
    }
