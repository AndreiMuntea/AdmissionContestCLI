using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Exceptions.ValidatorExceptions
{
   class ValidatorException : MyException
   {
      public ValidatorException()
      {
      }

      public ValidatorException(string message) : base(message)
      {
      }
   }
}
