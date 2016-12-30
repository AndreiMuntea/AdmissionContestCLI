using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.ValidatorExceptions;

namespace AdmissionContest.Validator
{
   class CandidateValidator : IValidator<Candidate>
   {
      public void Validate(Candidate element)
      {
         var errors = "";

         if (!ValidateID(element.ID))
            errors += "ID should be greater than 0!\n";
         if (!ValidateName(element.Name))
            errors += "Name can not be empty!\n";
         if (!ValidateAddress(element.Address))
            errors += "Address can not be empty!\n";
         if (!ValidateGrade(element.Grade))
            errors += "Grade should be a number in [1,10]!\n";
         if (!ValidatePhoneNumber(element.PhoneNumber))
            errors += "Phone number should be a 10-digit string!\n";

         if(!errors.Equals("")) throw new ValidatorException(errors);
      }

      private Boolean ValidateName(String name)
      {
         return !name.Equals("");
      }

      private Boolean ValidateAddress(String address)
      {
         return !address.Equals("");
      }

      private Boolean ValidatePhoneNumber(String PhoneNumber)
      {
         return PhoneNumber.Length == 10 && PhoneNumber.All(char.IsDigit);
      }

      private Boolean ValidateGrade(Double grade)
      {
         return grade >= 1 && grade <= 10;
      }

      private Boolean ValidateID(Int32 ID)
      {
         return ID > 0;
      }

   }
}
