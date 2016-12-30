using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;

namespace AdmissionContest.Helper.Saver
{
   public class SectionSaver : BaseSaver<Section>
   {
      public SectionSaver()
      {
      }

      public SectionSaver(char separator) : base(separator)
      {
      }

      public override string CreateFormat(Section entity)
      {
         return String.Concat(entity.ID, _separator,
                     entity.Name, _separator,
                     entity.AvailableSlots.ToString());
      }
   }
}
