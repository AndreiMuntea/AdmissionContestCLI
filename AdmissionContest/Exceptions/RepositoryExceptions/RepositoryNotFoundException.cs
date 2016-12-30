using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Exceptions.RepositoryExceptions
{
   class RepositoryNotFoundException : RepositoryException
   {
      public RepositoryNotFoundException()
      {
      }

      public RepositoryNotFoundException(string message) : base(message)
      {
      }
   }
}
