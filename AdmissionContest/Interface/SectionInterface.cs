using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Controller;
using AdmissionContest.Domain;

namespace AdmissionContest.Interface
{
   public class SectionInterface
   {
      private readonly Dictionary<String, Action> _actions;
      private readonly SectionController _sectionController;

      private void InitialiseCommands()
      {
         _actions.Add("Add Section", AddSection);
         _actions.Add("Update Section", UpdateSection);
         _actions.Add("Remove Section", RemoveSection);
         _actions.Add("Print Sections", PrintSections);
      }
      public SectionInterface(SectionController sectionController)
      {
         _sectionController = sectionController;
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
      private void ReadSectionID(out string sectionID)
      {
         GetArgument("Input section ID: ", out sectionID);
      }
      private void ReadSection(out string[] section)
      {
         section = new string[3];

         ReadSectionID(out section[0]);
         GetArgument("Input section name: ", out section[1]);
         GetArgument("Input section available slots: ", out section[2]);
      }


      private void AddSection()
      {
         string[] section;
         ReadSection(out section);
         _sectionController.AddElement(section);
      }

      private void UpdateSection()
      {
         string[] section;
         ReadSection(out section);
         _sectionController.UpdateEntity(section);
      }

      private void RemoveSection()
      {
         string sectionID;
         ReadSectionID(out sectionID);
         _sectionController.RemoveEntity(sectionID);
      }

      private void PrintSections()
      {
         List<Section> candidates = new List<Section>(_sectionController.GetAll());
         if (candidates.Count == 0) System.Console.WriteLine("Empty list!");
         candidates.ForEach(System.Console.WriteLine);
      }
   }
}
