using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Exceptions.ControllerExceptions
{
   class ControllerException : MyException
   {
      public ControllerException()
      {
      }

      public ControllerException(string message) : base(message)
      {
      }
   }
}
