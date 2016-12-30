using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Helper.EventFramework
{
   public interface ICustomEventHandler<E>
   {
      void HandledEvent(CustomEvent<E> eventFired, CustomEventArgs<E> eventArgs);
   }
}
