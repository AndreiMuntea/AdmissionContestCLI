using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Controller;
using AdmissionContest.Domain;

namespace AdmissionContest.Interface
{
   public class OptionInterface
   {
      private readonly Dictionary<String, Action> _actions;
      private readonly OptionController _optionController;


      private void InitialiseCommands()
      {
         _actions.Add("Register Candidate", RegisterCandidate);
         _actions.Add("Unregister Candidate", UnregisterCandidate);
         _actions.Add("Print Candidates for Section", PrintCandidatesForSection);
         _actions.Add("Print Sections for Candidate", PrintSectionsForCandidate);
      }
      public OptionInterface(OptionController optionController)
      {
         _optionController = optionController;
         _actions = new Dictionary<string, Action>();

         InitialiseCommands();
      }

      public Dictionary<String, Action> GetCommands()
      {
         return _actions;
      }


      private void GetArgument(String message, out String command)
      {
         System.Console.Write(message);
         command = System.Console.ReadLine();
      }
      private void ReadCandidateID(out string candidateID)
      {
         GetArgument("Input candidate ID: ", out candidateID);
      }

      private void ReadSectionID(out string sectionID)
      {
         GetArgument("Input section ID: ", out sectionID);
      }

      private void RegisterCandidate()
      {
         string candidateID;
         string sectionID;
         ReadCandidateID(out candidateID);
         ReadSectionID(out sectionID);
         _optionController.AddElement(candidateID, sectionID);
      }

      private void UnregisterCandidate()
      {
         string candidateID;
         string sectionID;
         ReadCandidateID(out candidateID);
         ReadSectionID(out sectionID);
         _optionController.RemoveEntity(candidateID, sectionID);
      }
   
      private void PrintSectionsForCandidate()
      {
         string candidateID;
         ReadCandidateID(out candidateID);
         List<Section> sections = new List<Section>(_optionController.SectionsForCandidate(candidateID));
         if (sections.Count == 0) System.Console.WriteLine("Empty list!");
         sections.ForEach(System.Console.WriteLine);
      }

      private void PrintCandidatesForSection()
      {
         string sectionID;
         ReadSectionID(out sectionID);
         List<Candidate> candidates = new List<Candidate>(_optionController.CandidatesForSection(sectionID));
         if (candidates.Count == 0) System.Console.WriteLine("Empty list!");
         candidates.ForEach(System.Console.WriteLine);
      }
   }
}

