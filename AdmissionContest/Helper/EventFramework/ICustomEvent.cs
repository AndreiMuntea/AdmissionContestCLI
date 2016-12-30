using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Helper.EventFramework
{
   public interface ICustomEvent<E>
   {
      void AddHandler(ICustomEventHandler<E> handler);
      void RemoveHandler(ICustomEventHandler<E> handler);
      void FireEvent(CustomEventArgs<E> eventArgs);
   }
}
