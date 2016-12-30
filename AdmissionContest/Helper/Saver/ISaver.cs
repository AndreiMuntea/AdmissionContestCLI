using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Helper.Saver
{
   public interface ISaver<E>
   {
      void SaveData(string fileName, ICollection<E> collection);
   }
}
