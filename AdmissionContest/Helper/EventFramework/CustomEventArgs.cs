using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Helper.EventFramework
{
   public class CustomEventArgs<E>
   {
      public String EventDescription { get; set; }
      public E Parameter { get; set; }

      public CustomEventArgs(string eventDescription, E parameter)
      {
         EventDescription = eventDescription;
         Parameter = parameter;
      }
   }
}
