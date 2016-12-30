using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Exceptions.RepositoryExceptions
{
   class RepositoryDuplicateEntry : RepositoryException
   {
      public RepositoryDuplicateEntry()
      {
      }

      public RepositoryDuplicateEntry(string message) : base(message)
      {
      }
   }
}
