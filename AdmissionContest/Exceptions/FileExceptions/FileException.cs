using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Exceptions.FileExceptions
{
   class FileException : MyException
   {
      public FileException()
      {
      }

      public FileException(string message) : base(message)
      {
      }
   }
}
