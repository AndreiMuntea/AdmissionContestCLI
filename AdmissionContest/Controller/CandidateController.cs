using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.ControllerExceptions;
using AdmissionContest.Repository;
using AdmissionContest.Validator;

namespace AdmissionContest.Controller
{
   public class CandidateController : AbstractController<Int32, Candidate>
   {
      public CandidateController(IRepository<int, Candidate> repository, IValidator<Candidate> validator) : base(repository, validator)
      {
      }

      public override Candidate GetEntityFromFormat(params string[] format)
      {
         Int32  candidateID;
         String candidateName;
         String candidatePhoneNumber;
         Double candidateGrade;
         String candidateAddress;

         if(format.Length != 5) throw new ControllerException("Invalid number of arguments!\n");

         if (!Int32.TryParse(format[0], out candidateID)) throw new ControllerException("Invalid ID for candidate!\n");
         candidateName = format[1];
         candidatePhoneNumber = format[2];
         if(!Double.TryParse(format[3],out candidateGrade)) throw new ControllerException("Invalid grade for candidate!\n");
         candidateAddress = format[4];

         return new Candidate(candidateID, candidateName, candidatePhoneNumber, candidateGrade, candidateAddress);
      }

      public override int GetIDFromFormat(params string[] format)
      {
         Int32 candidateID;

         if (format.Length != 1) throw new ControllerException("Invalid number of arguments!\n");
         if (Int32.TryParse(format[0], out candidateID)) throw new ControllerException("Invalid ID for candidate!\n");

         return candidateID;
      }
   }
}
