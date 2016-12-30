using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;

namespace AdmissionContest.Repository
{
   class MemoryRepository<ID, E> : AbstractRepository<ID, E> where E:HasID<ID>
   {
      public MemoryRepository() : base()
      {
      }
   }
}
