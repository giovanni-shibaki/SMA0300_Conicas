using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conicas
{
    class FuncMatematicas
    {
        private string Name;

        // Constructor that takes one argument:
        public FuncMatematicas()
        {
            
        }

        public string Name1 { get => Name; set => Name = value; }

        public int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

    }
}
