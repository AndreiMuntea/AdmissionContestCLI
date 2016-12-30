using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Helper.Saver
{
   public abstract class BaseSaver<E> : ISaver<E>
   {
      protected readonly char _separator;
      private static readonly char DEFAULT_SEPARATOR = '#';
      protected BaseSaver()
      {
         _separator = DEFAULT_SEPARATOR;
      }

      protected BaseSaver(char separator)
      {
         _separator = separator;
      }

      public void SaveData(string fileName, ICollection<E> collection)
      {
         System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);

         foreach (var e in collection)
         {
            file.WriteLine(CreateFormat(e));
         }

         file.Close();
      }
      public abstract string CreateFormat(E entity);
   }
}
