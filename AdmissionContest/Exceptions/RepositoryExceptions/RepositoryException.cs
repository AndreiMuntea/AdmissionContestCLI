using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Exceptions.RepositoryExceptions
{
   class RepositoryException : MyException
   {
      public RepositoryException()
      {
      }

      public RepositoryException(string message) : base(message)
      {
      }
   }
}
