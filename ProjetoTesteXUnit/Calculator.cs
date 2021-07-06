using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteXUnit
{
    class Calculator
    {
        public decimal Value { get; private set; } = 0;
        
        public decimal Add(decimal value)
        {
            return Value += value;
        }

        public decimal Subtract(decimal value)
        {
            return Value -= value;
        }

        public decimal Multiply(decimal value)
        {
            if(Value == 0)
            {
                Value = 1;
            }
            return Value *= value;
        }

        public decimal Divide(decimal value)
        {
            if(Value == 0)
            {
                Value = 1;
            }
            return Value /= value;
        }
    } 
}
