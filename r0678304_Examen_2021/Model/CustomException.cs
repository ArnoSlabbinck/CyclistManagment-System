using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace r0678304_Examen_2021.Classes
{
    public class CustomException : Exception
    {

        private string _message;
        public CustomException(string message) : 
            base(String.Format(message))
        {
            _message = message;

        }


       
    }
}
