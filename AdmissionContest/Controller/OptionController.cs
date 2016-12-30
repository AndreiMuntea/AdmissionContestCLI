using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions.ControllerExceptions;
using AdmissionContest.Helper.EventFramework;
using AdmissionContest.Repository;
using AdmissionContest.Validator;

namespace AdmissionContest.Controller
{
   public class OptionController : AbstractController<Tuple<Int32, String>, Option>, ICustomEventHandler<Candidate>, ICustomEventHandler<Section>
   {
      private readonly IRepository<Int32, Candidate> _candidateRepository;
      private readonly IRepository<String, Section> _sectionRepositoy;
      public OptionController(IRepository<Tuple<int, string>, Option> repository, 
                              IValidator<Option> validator,
                              IRepository<Int32, Candidate> candidateRepository,
                              IRepository<String, Section> sectionRepository) : base(repository, validator)
      {
         _candidateRepository = candidateRepository;
         _sectionRepositoy = sectionRepository;

         _candidateRepository.AddHandler(this);
         _sectionRepositoy.AddHandler(this);
      }

      public override Option GetEntityFromFormat(params string[] format)
      {
         return new Option(GetIDFromFormat(format));
      }

      public override void AddElement(params string[] arguments)
      {
         CheckForIntegrity(arguments);
         base.AddElement(arguments);
      }

      public override void RemoveEntity(params string[] arguments)
      {
         CheckForIntegrity(arguments);
         base.RemoveEntity(arguments);
      }
      
      public override Tuple<int, string> GetIDFromFormat(params string[] format)
      {
         Int32 candidateID;
         String sectionID;

         if (format.Length != 2) throw new ControllerException("Invalid number of arguments!\n");

         if (!Int32.TryParse(format[0], out candidateID)) throw new ControllerException("Invalid ID for candidate!\n");
         sectionID = format[1];

         return new Tuple<int, string>(candidateID, sectionID);
      }

      public void HandledEvent(CustomEvent<Candidate> eventFired, CustomEventArgs<Candidate> eventArgs)
      {
         if (eventArgs.EventDescription.Equals("Delete"))
         {
            RemoveAllCandidates(eventArgs.Parameter);
         }
      }

      public void HandledEvent(CustomEvent<Section> eventFired, CustomEventArgs<Section> eventArgs)
      {
         if (eventArgs.EventDescription.Equals("Delete"))
         {
            RemoveAllSections(eventArgs.Parameter);
         }
      }

      public List<Section> SectionsForCandidate(string candidateId)
      {
         Int32 candidateID;
         if (!Int32.TryParse(candidateId, out candidateID)) throw new ControllerException("Invalid ID for candidate!\n");

         List<Option> allOptions = new List<Option>(GetAll());
         List<Section> result = new List<Section>();

         allOptions.ForEach(o =>
         {
            if (o.GetCandidateID().Equals(candidateID)) result.Add(_sectionRepositoy.GetElement(o.GetSectionID()));
         });

         return result;
      }

      public List<Candidate> CandidatesForSection(string sectionID)
      {
         List<Option> allOptions = new List<Option>(GetAll());
         List<Candidate> result = new List<Candidate>();
         allOptions.ForEach(o =>
         {
            if (o.GetSectionID().Equals(sectionID)) result.Add(_candidateRepository.GetElement(o.GetCandidateID()));
         });

         return result;
      }

      private void RemoveAllSections(Section s)
      {
         List<Option> allOptions = new List<Option>(GetAll());
         allOptions.ForEach(o => {if (o.GetSectionID().Equals(s.ID)) _repository.RemoveElement(o.ID);});
      }

      private void RemoveAllCandidates(Candidate c)
      {
         List<Option> allOptions = new List<Option>(GetAll());
         allOptions.ForEach(o => { if (o.GetCandidateID().Equals(c.ID)) _repository.RemoveElement(o.ID); });
      }

      private void CheckForIntegrity(params string[] arguments)
      {
         Option optionID = GetEntityFromFormat(arguments);

         if (!_candidateRepository.Exists(optionID.GetCandidateID()))
            throw new ControllerException($"Candidate with ID {optionID.GetCandidateID()} doesn't exists!\n");

         if (!_sectionRepositoy.Exists(optionID.GetSectionID()))
            throw new ControllerException($"Section with ID {optionID.GetSectionID()} doesn't exists!\n");
      }
   }
}
