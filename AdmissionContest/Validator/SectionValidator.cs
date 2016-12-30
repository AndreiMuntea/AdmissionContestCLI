using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.ValidatorExceptions;

namespace AdmissionContest.Validator
{
   class SectionValidator : IValidator<Section>
   {
      public void Validate(Section element)
      {
         var errors = "";

         if (!ValidateID(element.ID))
            errors += "ID can not be empty!\n";
         if (!ValidateName(element.Name))
            errors += "Name can not be empty!\n";
         if (!ValidateAvailableSlots((element.AvailableSlots)))
            errors += "Number of available slots should be greater than 0!\n";

         if (!errors.Equals("")) throw new ValidatorException(errors);
      }

      public Boolean ValidateID(String ID)
      {
         return !ID.Equals("");
      }

      public Boolean ValidateName(String name)
      {
         return !name.Equals("");
      }

      public Boolean ValidateAvailableSlots(Int32 slots)
      {
         return slots > 0;
      }
   }
}
