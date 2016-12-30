using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Controller;
using AdmissionContest.Domain;

namespace AdmissionContest.Interface
{
   public class CandidateInterface
   {
      private readonly Dictionary<String, Action> _actions;
      private readonly CandidateController _candidateController;


      private void InitialiseCommands()
      {
         _actions.Add("Add Candidate", AddCandidate);
         _actions.Add("Update Candidate", UpdateCandidate);
         _actions.Add("Remove Candidate", RemoveCandidate);
         _actions.Add("Print Candidates", PrintCandidates);
      }
      public CandidateInterface(CandidateController candidateController)
      {
         _candidateController = candidateController;
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
      private void ReadCandidate(out string[] candidate)
      {
         candidate = new string[5];

         ReadCandidateID(out candidate[0]);
         GetArgument("Input candidate name: ", out candidate[1]);
         GetArgument("Input candidate phone number: ", out candidate[2]);
         GetArgument("Input candidate grade: ", out candidate[3]);
         GetArgument("Input candidate address: ", out candidate[4]);

      }
      private void AddCandidate()
      {
         string[] candidate;
         ReadCandidate(out candidate);
         _candidateController.AddElement(candidate);
      }

      private void UpdateCandidate()
      {
         string[] candidate;
         ReadCandidate(out candidate);
         _candidateController.UpdateEntity(candidate);
      }

      private void RemoveCandidate()
      {
         string candidateID;
         ReadCandidateID(out candidateID);
         _candidateController.RemoveEntity(candidateID);
      }

      private void PrintCandidates()
      {
         List<Candidate> candidates = new List<Candidate>(_candidateController.GetAll());
         if (candidates.Count == 0) System.Console.WriteLine("Empty list!");
         candidates.ForEach(System.Console.WriteLine);
      }
   }
}
