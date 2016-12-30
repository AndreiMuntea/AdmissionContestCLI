using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Controller;
using AdmissionContest.Domain;
using AdmissionContest.Exceptions;

namespace AdmissionContest.Interface
{
   public class MyInterface
   {
      private readonly Dictionary<String, Action> _actions;
      private readonly CandidateInterface _candidateInterface;
      private readonly SectionInterface _sectionInterface;
      private readonly OptionInterface _optionInterface;
      private Boolean _terminate;

      private void ImportCommands(Dictionary<String, Action> candidatesActions)
      {
         foreach (var keyValuePair in candidatesActions)
         {
            _actions.Add(keyValuePair.Key, keyValuePair.Value);
         }
      }
      private void InitialiseCommands()
      {
         ImportCommands(_candidateInterface.GetCommands());
         ImportCommands(_sectionInterface.GetCommands());
         ImportCommands(_optionInterface.GetCommands());
         _actions.Add("Exit", TerminateExecution);
      }

      public MyInterface(CandidateInterface candidateInterface, SectionInterface sectionInterface, OptionInterface optionInterface)
      {
         _candidateInterface = candidateInterface;
         _sectionInterface = sectionInterface;
         _optionInterface = optionInterface;

         _actions = new Dictionary<string, Action>();
         _terminate = false;

         InitialiseCommands();
      }
      public void Run()
      {
         while (_terminate == false)
         {
            String currentCommand;

            DisplayMenu();
            GetArgument("Pick a command: ", out currentCommand);
            ProcessCommand(currentCommand);
         }
      }
      private void DisplayMenu()
      {
         System.Console.WriteLine("------------------------------------------");
         System.Console.WriteLine("Available commands:\n");
         foreach (var keyValuePair in _actions)
         {
            System.Console.WriteLine(String.Concat(" >  ", keyValuePair.Key));
         }
         System.Console.WriteLine();
      }
      private void GetArgument(String message, out String command)
      {
         System.Console.Write(message);
         command = System.Console.ReadLine();
      }

      private void ProcessCommand(String command)
      {
         if (!(_actions.ContainsKey(command)))
         {
            System.Console.WriteLine("Oooops... Invalid Command! Try again!\n");
            return;
         }
         try
         {
            _actions[command].Invoke();
         }
         catch (MyException e)
         {
            System.Console.WriteLine(e.Message);
         }
      }
      private void TerminateExecution()
      {
         _terminate = true;
         System.Console.WriteLine("Program is now closing... Byee!");
      }

   }
}