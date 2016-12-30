using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Helper.Loader
{
   public interface ILoader<E>
   {
      ICollection<E> LoadData(string fileName);
   }
}
