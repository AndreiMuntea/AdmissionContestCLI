using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Exceptions
{
   class MyException : Exception
   {
      public MyException()
      {
      }

      public MyException(string message) : base(message)
      {
      }
   }
}
