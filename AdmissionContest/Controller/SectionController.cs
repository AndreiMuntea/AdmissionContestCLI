using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.ControllerExceptions;
using AdmissionContest.Repository;
using AdmissionContest.Validator;

namespace AdmissionContest.Controller
{
   public class SectionController : AbstractController<String, Section>
   {
      public SectionController(IRepository<string, Section> repository, IValidator<Section> validator) : base(repository, validator)
      {
      }

      public override Section GetEntityFromFormat(params string[] format)
      {
         String sectionID;
         String sectionName;
         Int32 sectionAvailableSlots;

         if (format.Length != 3) throw new ControllerException("Invalid number of arguments!\n");

         sectionID = format[0];
         sectionName = format[1];
         if(!Int32.TryParse(format[2],out sectionAvailableSlots)) throw new ControllerException("Invaild number for section slots!\n");
   
         return new Section(sectionID, sectionName, sectionAvailableSlots);
      }

      public override string GetIDFromFormat(params string[] format)
      {
         String sectionID;

         if (format.Length != 1) throw new ControllerException("Invalid number of arguments!\n");
         sectionID = format[0];

         return sectionID;
      }
   }
}
