using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Controller;
using AdmissionContest.Domain;
using AdmissionContest.Helper.Loader;
using AdmissionContest.Helper.Saver;
using AdmissionContest.Repository;
using AdmissionContest.Validator;
using AdmissionContest.Interface;

namespace AdmissionContest
{
   class Program
   {
      static void Main(string[] args)
      {
         
         ILoader<Section> sectionLoader = new SectionLoader('#');
         ISaver<Section> sectionSaver = new SectionSaver('#'); 
         IRepository<String, Section> sectionRepository = new FileRepository<String, Section>(sectionLoader, sectionSaver,"Resources/sectii.txt");
         IValidator<Section> sectionValidator = new SectionValidator();
         SectionController sectionController = new SectionController(sectionRepository, sectionValidator);

         ILoader<Candidate> candidateLoader = new CandidateLoader('#');
         ISaver<Candidate> candidateSaver = new CandidateSaver('#');
         IRepository<Int32, Candidate> candidateRepository = new FileRepository<Int32, Candidate>(candidateLoader, candidateSaver, "Resources/candidates.txt");
         IValidator<Candidate> candidateValidator = new CandidateValidator();
         CandidateController candidateController = new CandidateController(candidateRepository, candidateValidator);

         ILoader<Option> optionLoader = new OptionLoader('#');
         ISaver<Option> optionSaver = new OptionSaver('#');
         IRepository<Tuple<Int32,String>,Option> optionRepository = new FileRepository<Tuple<int, string>, Option>(optionLoader, optionSaver, "Resources/options.txt");
         IValidator<Option> optionValidator = new OptionValidator();
         OptionController optionController = new OptionController(optionRepository, optionValidator, candidateRepository, sectionRepository);

         CandidateInterface candidateInterface = new CandidateInterface(candidateController);
         SectionInterface sectionInterface = new SectionInterface(sectionController);
         OptionInterface optionInterface = new OptionInterface(optionController);
         MyInterface myInterface = new MyInterface(candidateInterface, sectionInterface, optionInterface);

         myInterface.Run();

      }
   }
}
