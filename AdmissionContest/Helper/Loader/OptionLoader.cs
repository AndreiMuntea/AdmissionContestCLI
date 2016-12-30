using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.FileExceptions;

namespace AdmissionContest.Helper.Loader
{
   class OptionLoader :BaseLoader<Option>
   {
      public OptionLoader()
      {
      }

      public OptionLoader(char separator) : base(separator)
      {
      }

      public override Option GetFromFormat(string[] format)
      {
         Int32 candidateID;
         String sectionID;

         if (format.Length != 2) throw new FileException("Invalid number of arguments!\n");

         if (!Int32.TryParse(format[0], out candidateID)) throw new FileException("Invalid ID for candidate!\n");
         sectionID = format[1];

         return new Option(candidateID, sectionID);
      }
   }
}
