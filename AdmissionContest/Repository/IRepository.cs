using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContest.Helper.EventFramework;

namespace AdmissionContest.Repository
{
   public interface IRepository<ID, E> : ICustomEvent<E>
   {
      E GetElement(ID id);

      void AddElement(E element);

      void RemoveElement(ID id);

      void UpdateElement(ID id, E updatedElement);

      Boolean Exists(ID id);

      void AddAll(ICollection<E> collection);

      ICollection<E> GetAll();

   }
}
