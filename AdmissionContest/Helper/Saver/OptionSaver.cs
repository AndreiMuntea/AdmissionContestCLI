using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;

namespace AdmissionContest.Helper.Saver
{
   class OptionSaver : BaseSaver<Option>
   {
      public OptionSaver()
      {
      }

      public OptionSaver(char separator) : base(separator)
      {
      }

      public override string CreateFormat(Option entity)
      {
         return String.Concat(entity.GetCandidateID().ToString(),
            _separator,
            entity.GetSectionID().ToString()
         );
      }
   }
}
