using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.FileExceptions;

namespace AdmissionContest.Helper.Loader
{
   public class SectionLoader: BaseLoader<Section>
   {
      public SectionLoader()
      {
      }

      public SectionLoader(char separator) : base(separator)
      {
      }

      public override Section GetFromFormat(string[] format)
      {
         String sectionID;
         String sectionName;
         Int32 sectionAvailableSlots;

         if (format.Length != 3) throw new FileException("Invalid number of arguments!\n");

         sectionID = format[0];
         sectionName = format[1];
         if (!Int32.TryParse(format[2], out sectionAvailableSlots)) throw new FileException("Invaild number for section slots!\n");

         return new Section(sectionID, sectionName, sectionAvailableSlots);
      }
   }
}
