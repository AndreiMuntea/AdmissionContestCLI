using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Domain
{
   public class Option : HasID<Tuple<Int32, String>>
   {
      public Option(Int32 candidateID, String sectionID) : base(new Tuple<Int32, String>(candidateID, sectionID))
      {
      }

      public Option(Tuple<Int32, String> ID) : base(ID)
      {
      }

      public Int32 GetCandidateID()
      {
         return ID.Item1;
      }

      public String GetSectionID()
      {
         return ID.Item2;
      }
   }
}
