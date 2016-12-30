using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContest.Helper.EventFramework
{
   public class CustomEvent<E> : ICustomEvent<E>
   {
      private readonly List<ICustomEventHandler<E>> _handlers;
      public CustomEvent()
      {
         _handlers = new List<ICustomEventHandler<E>>();
      }

      public void AddHandler(ICustomEventHandler<E> handler)
      {
         if (!_handlers.Contains(handler))
         {
            _handlers.Add(handler);
         }
      }

      public void RemoveHandler(ICustomEventHandler<E> handler)
      {
         if (_handlers.Contains((handler)))
         {
            _handlers.Remove(handler);
         }
      }

      public void FireEvent(CustomEventArgs<E> eventArgs)
      {
         _handlers.ForEach(e => e.HandledEvent(this, eventArgs));
      }
   }
}
