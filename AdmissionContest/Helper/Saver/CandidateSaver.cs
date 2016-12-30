using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;

namespace AdmissionContest.Helper.Saver
{
   public class CandidateSaver : BaseSaver<Candidate>
   {
      public CandidateSaver()
      {
      }

      public CandidateSaver(char separator) : base(separator)
      {
      }

      public override string CreateFormat(Candidate entity)
      {
         return String.Concat(entity.ID.ToString(), _separator,
                              entity.Name, _separator,
                              entity.PhoneNumber, _separator,
                              entity.Grade.ToString(CultureInfo.InvariantCulture), _separator,
                              entity.Address);
      }
   }
}
