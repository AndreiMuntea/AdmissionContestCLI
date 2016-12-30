using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Exceptions;

namespace AdmissionContest.Helper.Loader
{
   public abstract class BaseLoader<E> : ILoader<E>
   {
      protected readonly char _separator;
      private static readonly char DEFAULT_SEPARATOR = '#';
      protected BaseLoader()
      {
         _separator = DEFAULT_SEPARATOR;
      }
      protected BaseLoader(char separator)
      {
         _separator = separator;
      }
      public ICollection<E> LoadData(string fileName)
      {
         var list = new List<E>();

         System.IO.StreamReader file = new System.IO.StreamReader(fileName);
         try
         {
            string line;
            while ((line = file.ReadLine()) != null)
            {
               E entity = GetFromFormat(line.Split(_separator));
               list.Add(entity);
            }
         }
         catch (MyException e)
         {
            list.Clear();
         }

         file.Close();
         return list;

      }
      public abstract E GetFromFormat(string[] format);

   }
}
