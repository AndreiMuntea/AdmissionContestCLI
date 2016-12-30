using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.FileExceptions;

namespace AdmissionContest.Helper.Loader
{
   public class CandidateLoader : BaseLoader<Candidate>
   {
      public CandidateLoader()
      {
      }

      public CandidateLoader(char separator) : base(separator)
      {
      }

      public override Candidate GetFromFormat(string[] format)
      {
         Int32 candidateID;
         String candidateName;
         String candidatePhoneNumber;
         Double candidateGrade;
         String candidateAddress;

         if (format.Length != 5) throw new FileException("Invalid number of arguments!\n");

         if (!Int32.TryParse(format[0], out candidateID)) throw new FileException("Invalid ID for candidate!\n");
         candidateName = format[1];
         candidatePhoneNumber = format[2];
         if (!Double.TryParse(format[3], out candidateGrade)) throw new FileException("Invalid grade for candidate!\n");
         candidateAddress = format[4];

         return new Candidate(candidateID, candidateName, candidatePhoneNumber, candidateGrade, candidateAddress);
      }
   }
}
